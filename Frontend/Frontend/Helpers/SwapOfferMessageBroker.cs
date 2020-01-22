using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Frontend.Models;
using System;

namespace Frontend.Helpers
{
    class SwapOfferMessageBroker : ViewModelBase
    {
        const string TOPIC_NAME = "SwapOfferTopic";
        private IConnection connection;
        private IConnectionFactory connectionFactory;
        private ISession session;
        private IMessageProducer messageProducer;
        private IMessageConsumer messageConsumer;
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
                session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
                messageProducer = session.CreateProducer(new ActiveMQTopic(TOPIC_NAME));
                messageConsumer = session.CreateConsumer(new ActiveMQTopic(TOPIC_NAME));

                // MessageListener-Methode für eingehende Nachrichten registrieren
                messageConsumer.Listener += OnMessageReceived;

                // Thread zum Empfang eingehender Nachrichten starten
                connection.Start();
                Console.WriteLine("\n*** Starting connection: " + TOPIC_NAME + "@" + currentBrokerURL + "\n");
            }
            catch (Exception e)
            {
                throw new MessageBrokerCommunicationException("updateConnection(): " + e.Message);
            }
        }

        // OnMessageReceived - beim messageConsumer registrierte Callback-Methode,
        // wird bei Empfang einer neuen Nachricht vom messageConsumer aufgerufen.
        // Textnachrichten werden zur Kommandoausführung an parseCommand() weitergegeben
        public void OnMessageReceived(IMessage msg)
        {
            if (msg is ITextMessage)
            {
                ITextMessage textmessage = msg as ITextMessage;
                Console.WriteLine("\nreceived: " + textmessage.Text + "\n");
                ParseCommand(textmessage.Text);
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                IMessage msg = session.CreateTextMessage(message.Trim());
                messageProducer.Send(msg);
            }
            catch (Exception exc)
            {
                throw new MessageBrokerCommunicationException("Error sending message: " + exc.Message);
            }
        }

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
                    swapOffers.RemoveById(id);
                    return;
                }

                if (command == "add")
                {
                    swapOffers.AddById(id);
                    return;
                }
            }
            catch (Exception e)
            {
                SendMessage("Exception: " + e.ToString());
            }
        }
    }

    class MessageBrokerCommunicationException : Exception
    {
        public MessageBrokerCommunicationException(string msg) : base(msg) { }
    }
}