using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using ToastNotifications.Messages;
using Frontend.Helpers;

namespace Frontend.Models
{
    class SwapOfferCommunication : ObservableModelBase
    {
        const string TOPIC_NAME = "SampleSubscriptionTopic";

        private IConnection connection;
        private IConnectionFactory connectionFactory;
        private ISession session;
        private IMessageProducer messageProducer;
        private IMessageConsumer messageConsumer;
        private string currentBrokerURL = "tcp://localhost:61616";     // TODO: ggf. anpassen

        public SwapOfferCommunication()
        {
            UpdateConnection();
        }


        #region Kommunikation/Messaging

        // Verbindung zum  Messaging-Server aktualisieren
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
                throw new SwapOfferCommunicationException("updateConnection(): " + e.Message);
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
                App.notifierSO.ShowSuccess(textmessage.Text);
            }
        }

        public void SendMessage(string nachricht)
        {
            try
            {
                IMessage msg = session.CreateTextMessage(nachricht.Trim());
                messageProducer.Send(msg);
            }
            catch (Exception exc)
            {
                throw new SwapOfferCommunicationException("Senden fehlgeschlagen: " + exc.Message);
            }
        }

        #endregion



        #region EigeneExceptions
        /*
         * Model signalisiert Unzufriedenheit nach "außen", z.B. dem ViewModel
        */
        class SwapOfferCommunicationException : Exception
        {
            public SwapOfferCommunicationException(string msg) : base(msg) { }
        }

        #endregion
    }
}
