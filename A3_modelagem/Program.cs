using A3_modelagem;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    // Substituindo a lista em memória pelo contexto do banco
    static AppDbContext db = new AppDbContext();
    static InterfaceEditor interfaceEditor = new InterfaceEditor();
    static InterfaceUser interfaceUsuario = new InterfaceUser();

    public static void Main()
    {
        // Garante que o arquivo do banco de dados seja criado ao rodar
        db.Database.EnsureCreated();

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
                    db.Editores.Add(editorT);
                    db.SaveChanges(); // Salva no SQLite!
                    Console.WriteLine("Editor cadastrado com sucesso!");
                    break;

                case 2:
                    User userT = interfaceUsuario.InterfaceCadastroUser();
                    db.Usuarios.Add(userT);
                    db.SaveChanges(); // Salva no SQLite!
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                    break;

                case 3:
                    if (!db.Editores.Any()) break;

                    (string user, string password) = interfaceEditor.InterfaceLogin();

                    // Busca no banco se existe um editor com essas credenciais
                    var ed = db.Editores.FirstOrDefault(e => e.UserName == user && e.Password == password);

                    if (ed != null)
                    {
                        Console.WriteLine("Login bem-sucedido como editor!");
                        isLoggedIn = true;
                        do
                        {
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
                                    db.Videos.Add(video);
                                    db.SaveChanges(); // Salva o vídeo no banco
                                    Console.WriteLine("\nVideo upado com sucesso");
                                    break;
                                case 2:
                                    Console.WriteLine("\nDigite a mensagem que deseja enviar para o usuário:");
                                    string mensagem = Console.ReadLine()!;
                                    LiveChat liveChat = new LiveChat(ed, mensagem, DateTime.Now);
                                    db.Chats.Add(liveChat);
                                    db.SaveChanges(); // Salva a mensagem no banco

                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("Histórico de mensagens");
                                    // Include(c => c.Sender) traz os dados do usuário junto com a mensagem
                                    var historico = db.Chats.Include(c => c.Sender).ToList();
                                    liveChat.ListarMensagens(historico);
                                    break;
                                default:
                                    Console.WriteLine("Escolha inválida. Saindo do menu de editor...");
                                    isLoggedIn = false;
                                    break;
                            }
                        } while (isLoggedIn);
                    }
                    else { Console.WriteLine("Usuario ou senha incorretos"); }
                    break;

                case 4:
                    if (!db.Usuarios.Any()) break;

                    (string userU, string passwordU) = interfaceUsuario.InterfaceLogin();

                    // Busca no banco se existe um usuário com essas credenciais
                    var us = db.Usuarios.FirstOrDefault(u => u.UserName == userU && u.Password == passwordU);

                    if (us != null)
                    {
                        Console.WriteLine("Login bem-sucedido como usuário!");
                        isLoggedIn = true;
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
                                    if (!db.Videos.Any())
                                    {
                                        Console.WriteLine("Nenhum video disponivel");
                                        break;
                                    }
                                    else
                                    {
                                        var listaVideos = db.Videos.ToList();
                                        interfaceUsuario.InterfaceVideos(listaVideos);
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("\nDigite a mensagem que deseja enviar para o editor");
                                    string mensagem = Console.ReadLine()!;
                                    LiveChat liveChat = new LiveChat(us, mensagem, DateTime.Now);
                                    db.Chats.Add(liveChat);
                                    db.SaveChanges();

                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("Histórico de mensagens");
                                    var historico = db.Chats.Include(c => c.Sender).ToList();
                                    liveChat.ListarMensagens(historico);
                                    break;
                                default:
                                    Console.WriteLine("Escolha inválida. Saindo do menu de usuário...");
                                    isLoggedIn = false;
                                    break;
                            }
                        } while (isLoggedIn);
                    }
                    else { Console.WriteLine("Usuario ou senha incorretos"); }
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
            if (escolhaInt == 1 || escolhaInt == 2 || escolhaInt == 3 || escolhaInt == 4 || escolhaInt == 0)
                return escolhaInt;
            else
            {
                Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                return 0;
            }
        }
        else return 0;
    }
}