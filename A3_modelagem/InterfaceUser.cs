namespace A3_modelagem
{
    internal class InterfaceUser
    {
        
        public User InterfaceCadastroUser()
        {
            string username, password, email;
            Console.WriteLine("\n---------------------");
            Console.WriteLine("ID enquanto não tem banco de dados: ");
            string idString = Console.ReadLine()!;
            if (!int.TryParse(idString, out int id))
            {
                Console.WriteLine("ERRO de parse");
            }
            Console.WriteLine("Insira seu email: ");
            email = Console.ReadLine()!;
            Console.WriteLine("Insira seu usuário: ");
            username = Console.ReadLine()!;
            Console.WriteLine("Insira sua senha: ");
            password = Console.ReadLine()!;

            return new User(id, username, email, password);
        }
        public virtual (string, string) InterfaceLogin()
        {
            string username, password;
            Console.WriteLine("Digite seu usuario: ");
            username = Console.ReadLine()!;
            Console.WriteLine("Digite sua senha: ");
            password = Console.ReadLine()!;
            return (username, password);
        }

        public void InterfaceMenu()
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
