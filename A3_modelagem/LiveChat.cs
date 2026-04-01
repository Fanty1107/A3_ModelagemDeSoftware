namespace A3_modelagem
{
    internal class LiveChat
    {
        public int Id { get; set; } // O BANCO EXIGE ISSO!
        public string Message { get; set; }

        public int SenderId { get; set; } // Chave estrangeira
        public User Sender { get; set; }  // Serve tanto para User quanto para Editor!

        public DateTime Timestamp { get; set; }

        public LiveChat() { }

        
        public LiveChat(User sender, string message, DateTime timestamp)
        {
            Sender = sender;
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
                // Como unificamos, a impressão fica em apenas uma linha
                Console.WriteLine($"[{msg.Timestamp}] {msg.Sender?.UserName}: {msg.Message}");
            }
        }
    }
}