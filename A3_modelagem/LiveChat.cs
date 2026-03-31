namespace A3_modelagem
{
    internal class LiveChat
    {
        //classe para representar o chat ao vivo durante a transmissão de um vídeo provavelmente vai ter apenas metodos
        public string Message { get; set; }
        public User Sender { get; set; }
        public Editor Sender2 { get; set; }
        public DateTime Timestamp { get; set; }
        

        public LiveChat(User sender, string message, DateTime timestamp) 
        {
            Sender = sender;
            Message = message;
            Timestamp = timestamp;
        }
        public LiveChat(Editor sender, string message, DateTime timestamp)
        {
            Sender2 = sender;
            Message = message;
            Timestamp = timestamp;
        }
        public void ListarMensagens(List<LiveChat> mensagens)
        {
            if (mensagens == null || mensagens.Count == 0)
            {
                Console.WriteLine("Nenhuma mensagem no chat.");
                return;
            }
            foreach (var msg in mensagens)
            {
                Console.WriteLine("\n-------------------------");
                if (msg.Sender != null)
                {
                    Console.WriteLine($"[{msg.Timestamp}] {msg.Sender.UserName}: {msg.Message}");
                }
                
                else if (msg.Sender2 != null)
                {
                    Console.WriteLine($"[{msg.Timestamp}] {msg.Sender2.UserName}: {msg.Message}");
                }
            }
        }     
        public void SendMessage(string message, User sender)
        {
            Message = message;
            Sender = sender;
            Timestamp = DateTime.Now;
            
        }
        public void SendMessage(string message, Editor sender)
        {
            Message = message;
            Sender2 = sender;
            Timestamp = DateTime.Now;
        }
        }
}
