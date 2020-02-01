using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Frontend.Models;
using System;
using Newtonsoft.Json;
using ToastNotifications.Messages;

namespace Frontend.Helpers
{
    class SwapOfferMessageBroker : ViewModelBase
    {
        const string TOPIC_NAME_PUBLIC_SWAP = "SwapOfferTopic";
        const string TOPIC_NAME_PERSONAL_SWAP = "SwapMessagePersonalTopic";
        const string TOPIC_NAME_NEWS = "NewsMessageTopic";
        private IConnection connection;
        private IConnectionFactory connectionFactory;
        private ISession session;
        private IMessageConsumer messageConsumerPublic;
        private IMessageConsumer messageConsumerPersonal;
        private IMessageConsumer messageConsumerNews;
        private string currentBrokerURL = "tcp://localhost:61616";
        private SwapOfferListModel swapOffers = SwapOfferListModel.Instance;

        public SwapOfferMessageBroker()
        {
            UpdateConnection();
        }
       
        public void UpdateConnection()
        {
            try
            {
                // Verbindung / Session / MessageProducer und -Consumer instanziieren
                if (connectionFactory == null) connectionFactory = new ConnectionFactory(currentBrokerURL);
                connection = connectionFactory.CreateConnection();
                connection.Start();
                session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
                messageConsumerPublic = session.CreateConsumer(new ActiveMQTopic(TOPIC_NAME_PUBLIC_SWAP));
                messageConsumerPersonal = session.CreateConsumer(new ActiveMQTopic(TOPIC_NAME_PERSONAL_SWAP));
                messageConsumerNews = session.CreateDurableConsumer(new ActiveMQTopic(TOPIC_NAME_NEWS),"news",null,false);


                // MessageListener-Methode für eingehende Nachrichten registrieren
                messageConsumerPublic.Listener += OnSwapOfferPublicReceive;
                messageConsumerNews.Listener += OnNewsListReceive;
                messageConsumerPersonal.Listener += OnPersonalSwapOfferAccept;

                // Thread zum Empfang eingehender Nachrichten starten
               

            }
            catch (Exception e)
            {
                throw new MessageBrokerCommunicationException("updateConnection(): " + e.Message);
            }
        }

        private void PullInitialNews()
        {
            var message = (ActiveMQTextMessage)messageConsumerNews.Receive(TimeSpan.FromTicks(DateTime.Now.Ticks));
            Console.WriteLine(message.Text);
        }

        // OnMessageReceived - beim messageConsumer registrierte Callback-Methode,
        // wird bei Empfang einer neuen Nachricht vom messageConsumer aufgerufen.
        // Textnachrichten werden zur Kommandoausführung an parseCommand() weitergegeben
        public void OnPersonalSwapOfferAccept(IMessage msg)
        {

            if (msg is ITextMessage)
            {
                ITextMessage textmessage = msg as ITextMessage;
                PersonalNewsMessage jmsg = JsonConvert.DeserializeObject<PersonalNewsMessage>(textmessage.Text);
                if(jmsg.userid == UserInformation.Instance.UserId)
                {
                    News news = new News
                    {
                        Message = jmsg.message,
                        Timestamp = jmsg.timestamp
                    };
                    NewsListModel.Instance.NewsList.Add(news);
                    App.notifier.ShowSuccess(jmsg.message);
                }
                
                //ParseCommand(textmessage.Text);
                
            }
        }

        /// <summary>
        /// this method reacts to the message (msg) and depending wether the action equals "add" or "delete" it creates a new SwapOffer or deletes an existing one.
        /// </summary>
        /// <param name="msg">the message contains different parameters, action that defines the type and data that contains a JSon</param>
        public void OnSwapOfferPublicReceive(IMessage msg) //neues hinzufügen oder löschen
        {
            if (msg is ITextMessage)
            {
                ITextMessage textmessage = msg as ITextMessage;
                ParseCommand(textmessage.Text);
                PublicSwapMessage psmsg = JsonConvert.DeserializeObject<PublicSwapMessage>(textmessage.Text);
                if (psmsg.action.Equals("add")){
                    SwapOfferFrontendModel newjmsg = JsonConvert.DeserializeObject<SwapOfferFrontendModel>(psmsg.data);
                    swapOffers.AddSwapOffer(newjmsg,true);
                }
                else if (psmsg.action.Equals("delete")){
                    swapOffers.RemoveById(long.Parse(psmsg.data));
                }
            }
        }

        /// <summary>
        /// This method reacts on an incoming message, reads the JSon and creates a new news object and puts it into the NewsList.
        /// </summary>
        /// <param name="msg">the message that^contains a JSon and a timestamp. This information will be shown in the newslist. </param>
        public void OnNewsListReceive(IMessage msg)
        {
            if (msg is ITextMessage)
            {
                ITextMessage textmessage = msg as ITextMessage;
                //ParseCommand(textmessage);
                JsonMessage jmsg = JsonConvert.DeserializeObject<JsonMessage>(textmessage.Text);
                News news = new News
                {
                    Message = jmsg.message,
                    Timestamp = jmsg.timestamp,
                };
                NewsListModel.Instance.NewsList.Add(news);
            }
        }


        /// <summary>
        /// outdated method, not used anymore
        /// </summary>
        /// <param name="cmd"></param>
        void ParseCommand(string cmd)
        {
            var fields = cmd.Split();
            if (fields.Length < 2 || fields[0] != "swapoffer")
            {
                return;
            }
            try
            {
                var command = fields[1];
                var id = long.Parse(fields[2]);

                if (command == "remove")
                {
                    //swapOffers.RemoveById(id);
                    return;
                }

                if (command == "add")
                {
                    //swapOffers.AddById(id);
                    return;
                }
            }
            catch (Exception e)
            {
                //SendMessage("Exception: " + e.ToString());
            }
        }
    }

    class MessageBrokerCommunicationException : Exception
    {
        public MessageBrokerCommunicationException(string msg) : base(msg) { }
    }

}

