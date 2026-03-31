using A3_modelagem;

public class Program
{
    //variaveis globais
    static BancoDeDados bd = new BancoDeDados();
    static InterfaceEditor interfaceEditor = new InterfaceEditor();
    static InterfaceUser interfaceUsuario = new InterfaceUser();

    public static void Main()
    {

        bool isLoggedIn = true;
        bool isRun = true;
        while (isRun)
        {
            MenuDeEntrada();
            string escolha = Console.ReadLine()!;
            int escolhaInt = ParsearEscolha(escolha);

            switch (escolhaInt)
            {
                case 0:
                    Console.WriteLine("Saindo do sistema...");
                    isRun = false;
                    break;

                case 1:
                    Editor editorT = interfaceEditor.InterfaceCadastroEditor();
                    bd.Editores.Add(editorT);
                    break;

                case 2:
                    User userT = interfaceUsuario.InterfaceCadastroUser();
                    bd.Usuarios.Add(userT);
                    break;

                case 3:
                    if (bd.Editores.Count == 0) break;
                    (string user, string password) = interfaceEditor.InterfaceLogin();
                    foreach (Editor ed in bd.Editores)
                    {
                        if (ed.UserName == user && ed.Password == password)
                        {                            
                            Console.WriteLine("Login bem-sucedido como editor!");
                            do { 
                            interfaceEditor.InterfaceMenuEditor();
                            string escolhastr = Console.ReadLine()!;
                            int escolhaEditor = ParsearEscolha(escolhastr);           
                                switch (escolhaEditor)
                                {
                                case 0:
                                    Console.WriteLine("Saindo do menu de editor...");
                                    isLoggedIn = false;
                                    break;
                                case 1:
                                    Videos video = interfaceEditor.InterfaceUploadVideo(ed);
                                    bd.Videos.Add(video);
                                    Console.WriteLine("\n Video upado com sucesso");
                                    break;
                                case 2:                               
                                        Console.WriteLine("\nDigite a mensagem que deseja enviar para o usuário");
                                        string mensagem = Console.ReadLine()!;
                                        LiveChat liveChat = new LiveChat(ed, mensagem, DateTime.Now);
                                        liveChat.SendMessage(mensagem, ed);                                       
                                        bd.Chats.Add(liveChat);
                                        Console.WriteLine("---------------------");
                                        Console.WriteLine("Historico de mensagens");
                                        liveChat.ListarMensagens(bd.Chats);
                                        break;
                                default:
                                    Console.WriteLine("Escolha inválida. Saindo do menu de editor...");
                                    isLoggedIn = false;
                                    break;
                                }
                            }while(isLoggedIn);
                        }
                        else { Console.WriteLine("Usuario ou senha incorretos"); }
                    } 
                    break;
                case 4:
                    if(bd.Usuarios.Count == 0) break;
                    (string userU, string passwordU) = interfaceUsuario.InterfaceLogin();
                    foreach (User us in bd.Usuarios)
                    {
                        if (us.UserName == userU && us.Password == passwordU)
                        {
                            Console.WriteLine("Login bem-sucedido como usuário!");
                            do
                            {
                                interfaceUsuario.InterfaceMenu();
                                string escolhastr = Console.ReadLine()!;
                                int escolhaUsuario = ParsearEscolha(escolhastr);
                                switch (escolhaUsuario)
                                {
                                    case 0:
                                        Console.WriteLine("Saindo do menu de usuário...");
                                        isLoggedIn = false;
                                        break;
                                    case 1:
                                        
                                        if(bd.Videos.Count == 0)
                                        {
                                            Console.WriteLine("Nenhum video disponivel");
                                            break;
                                        }
                                        else { interfaceUsuario.InterfaceVideos(bd.Videos); }                                          
                                        break;
                                    case 2:                                        
                                        Console.WriteLine("\nDigite a mensagem que deseja enviar para o editor");
                                        string mensagem = Console.ReadLine()!;
                                        LiveChat liveChat = new LiveChat(us, mensagem, DateTime.Now);
                                        liveChat.SendMessage(mensagem, us);
                                        bd.Chats.Add(liveChat);
                                        Console.WriteLine("---------------------");
                                        Console.WriteLine("Historico de mensagens");
                                        liveChat.ListarMensagens(bd.Chats);
                                        break;
                                    default:
                                        Console.WriteLine("Escolha inválida. Saindo do menu de usuário...");
                                        isLoggedIn = false;
                                        break;
                                }
                            } while(isLoggedIn);

                        }
                        else { Console.WriteLine("Usuario ou senha incorretos"); }
                    }

                    break;

                default:
                    Console.WriteLine("CRITICAL ERROR");
                    isRun = false;
                    break;
            }
        }
    }
    public static void MenuDeEntrada()
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Bem-vindo ao sistema de venda de edição de vídeo!");
        Console.WriteLine("1 - Cadastrar editor");
        Console.WriteLine("2 - Cadastrar usuário");
        Console.WriteLine("3 - Login como editor");
        Console.WriteLine("4 - Login como usuário");
        Console.WriteLine("0 - Sair");
        Console.WriteLine("-----------------------------------------------");
    }
    public static int ParsearEscolha(string escolha)
    {
        if (int.TryParse(escolha, out int escolhaInt))
        {
            if(escolhaInt == 1 || escolhaInt == 2 || escolhaInt == 3 || escolhaInt == 4 || escolhaInt == 0)
            {
                return escolhaInt;
            }
            else
            {
                Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                return 0;
            }
        }
        else return 0;
    }
}
