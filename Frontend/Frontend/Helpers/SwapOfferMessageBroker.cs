//using Apache.NMS;
//using Frontend.Models;
//using Apache.NMS.ActiveMQ.Commands;
//using Apache.NMS.ActiveMQ;
//using System;


//namespace Frontend.Helpers
//{
//    class SwapOfferMessageBroker : ViewModelBase
//    {
//        const string TOPIC_NAME_PUBLIC_SWAP = "SwapOfferTopic";
//        const string TOPIC_NAME_PERSONAL_SWAP = "SwapMessageQueue";
//        const string TOPIC_NAME_NEWS = "NewsMessageTopic";
//        private IConnection connection;
//        private IConnectionFactory connectionFactory;
//        private ISession session;
//        private IMessageConsumer messageConsumerPublic;
//        private IMessageConsumer messageConsumerPersonal;
//        private IMessageConsumer messageConsumerNews;
//        private string currentBrokerURL = "tcp://localhost:61616";
//        private SwapOfferListModel swapOffers = SwapOfferListModel.Instance;

//        public SwapOfferMessageBroker()
//        {
//            //UpdateConnection();
//        }
       
//        public void UpdateConnection()
//        {
//            try
//            {
//                // Verbindung / Session / MessageProducer und -Consumer instanziieren
//                if (connectionFactory == null) connectionFactory = new ConnectionFactory(currentBrokerURL);
//                connection = connectionFactory.CreateConnection();
//                session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
//                messageConsumerPublic = session.CreateConsumer(new ActiveMQTopic(TOPIC_NAME_PUBLIC_SWAP));
//                messageConsumerPersonal = session.CreateConsumer(new ActiveMQTopic(TOPIC_NAME_PERSONAL_SWAP));
//                messageConsumerNews = session.CreateConsumer(new ActiveMQTopic(TOPIC_NAME_NEWS));

//                // MessageListener-Methode für eingehende Nachrichten registrieren
//                messageConsumerPublic.Listener += OnSwapOfferPublicReceive;
//                messageConsumerNews.Listener += OnNewsListReceive;
//                messageConsumerPersonal.Listener += OnPersonalSwapOfferAccept;

//                // Thread zum Empfang eingehender Nachrichten starten
//                connection.Start();
                
//            }
//            catch (Exception e)
//            {
//                throw new MessageBrokerCommunicationException("updateConnection(): " + e.Message);
//            }
//        }

//        // OnMessageReceived - beim messageConsumer registrierte Callback-Methode,
//        // wird bei Empfang einer neuen Nachricht vom messageConsumer aufgerufen.
//        // Textnachrichten werden zur Kommandoausführung an parseCommand() weitergegeben
//        public void OnPersonalSwapOfferAccept(IMessage msg)
//        {
//            if (msg is ITextMessage)
//            {
//                ITextMessage textmessage = msg as ITextMessage;
//                Console.WriteLine("\nreceived: " + textmessage.Text + "\n");
//                ParseCommand(textmessage.Text);
                
//            }
//        }

//        public void OnSwapOfferPublicReceive(IMessage msg)
//        {
//            if (msg is ITextMessage)
//            {
//                ITextMessage textmessage = msg as ITextMessage;
//                Console.WriteLine("\nreceived: " + textmessage.Text + "\n");
//                ParseCommand(textmessage.Text);

//            }
//        }

//        public void OnNewsListReceive(IMessage msg)
//        {
//            if (msg is IMapMessage)
//            {
//                IMapMessage textmessage = msg as IMapMessage;
//                Console.WriteLine("\nreceived: " + textmessage + "\n");
//                //ParseCommand(textmessage);
//                Console.WriteLine(textmessage.Properties);

//            }
//        }

//        void ParseCommand(string cmd)
//        {
//            var fields = cmd.Split();
//            if (fields.Length < 2 || fields[0] != "swapoffer")
//            {
//                return;
//            }
//            try
//            {
//                var command = fields[1];
//                var id = long.Parse(fields[2]);

//                if (command == "remove")
//                {
//                    //swapOffers.RemoveById(id);
//                    return;
//                }

//                if (command == "add")
//                {
//                    //swapOffers.AddById(id);
//                    return;
//                }
//            }
//            catch (Exception e)
//            {
//                //SendMessage("Exception: " + e.ToString());
//            }
//        }
//    }

//    class MessageBrokerCommunicationException : Exception
//    {
//        public MessageBrokerCommunicationException(string msg) : base(msg) { }
//    }

//}

