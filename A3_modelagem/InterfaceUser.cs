namespace A3_modelagem
{
    internal class InterfaceUser
    {
        //retorna uma tupla
        public virtual (string, string) InterfaceLogin()
        {
            string username, password;
            Console.WriteLine("\n---------------------");
            Console.WriteLine("Insira seu usuário: ");
            username = Console.ReadLine()!;
            Console.WriteLine("Insira sua senha: ");
            password = Console.ReadLine()!;
            return (username, password);
        }
        public static void InterfaceMenu()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine("1 - Ver vídeos");
            Console.WriteLine("2 - Acessar chat ao vivo com editor");
            Console.WriteLine("0 - Sair");
        }
        public static void InterfaceVideos(Videos video)
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine($"Título: {video.Title}");
            Console.WriteLine($"Descrição: {video.Description}");
            Console.WriteLine($"URL: {video.Url}");
            Console.WriteLine($"Visualizações: {video.Views}");
        }
        public static void InterfaceChat(LiveChat chat)
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine($"[{chat.Timestamp}] {chat.Sender.UserName}: {chat.Message}");
        }
        public void InterfacePagamento()
        {
            Console.WriteLine("Insira os dados do cartão de crédito para pagamento:");
            Console.WriteLine("Número do cartão: ");
            string cardNumber = Console.ReadLine()!;
            Console.WriteLine("Data de validade (MM/AA): ");
            string expirationDate = Console.ReadLine()!;
            Console.WriteLine("Código de segurança (CVV): ");
            string cvv = Console.ReadLine()!;
            Console.WriteLine("Pagamento realizado com sucesso!");
        }
    }
}
