namespace A3_modelagem
{
    internal class InterfaceEditor : InterfaceUser
    {
        public override (string, string) InterfaceLogin()
        {
            return base.InterfaceLogin();
        }
        public Videos InterfaceUploadVideo(Editor editor)
        {
            string title, description, url;
            Console.WriteLine("\n---------------------");
            Console.WriteLine("Insira o título do vídeo: ");
            title = Console.ReadLine()!;
            Console.WriteLine("Insira a descrição do vídeo: ");
            description = Console.ReadLine()!;
            Console.WriteLine("Insira a URL do vídeo: ");
            url = Console.ReadLine()!;
            return new Videos(editor, title, description, url, 0);
        }
        public void InterfaceMenuEditor()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine("1 - Upload de vídeo");
            Console.WriteLine("2 - Acessar chat ao vivo com usuário");
            Console.WriteLine("0 - Sair");
        }
        public Editor InterfaceCadastroEditor()
        {
            string username, password, email; 
            Console.WriteLine("\n---------------------");
            Console.WriteLine("Insira seu email: ");
            email = Console.ReadLine()!;
            Console.WriteLine("Insira seu usuário: ");
            username = Console.ReadLine()!;
            Console.WriteLine("Insira sua senha: ");
            password = Console.ReadLine()!;
        
            return new Editor(username, email, password);
        }
    }
}
