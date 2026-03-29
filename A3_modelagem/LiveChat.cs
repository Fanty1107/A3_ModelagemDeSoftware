namespace A3_modelagem
{
    internal class LiveChat
    {
        //classe para representar o chat ao vivo durante a transmissão de um vídeo provavelmente vai ter apenas metodos
        public string Message { get; set; }
        public User Sender { get; set; }
        public DateTime Timestamp { get; set; }
        public LiveChat(string message, User sender, DateTime timestamp)
        {
            Message = message;
            Sender = sender;
            Timestamp = timestamp;
        }
    }
}
