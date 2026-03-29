using A3_modelagem;

public class Program
{
    //variaveis globais
    static BancoDeDados bd = new BancoDeDados();
    static InterfaceEditor interfaceEditor = new InterfaceEditor();
    static InterfaceUser interfaceUsuario = new InterfaceUser();
    static bool isRun = true;
    public static void Main()
    {
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
                    Editor editor = interfaceEditor.InterfaceCadastroEditor();
                    bd.Editores.Add(editor);
                    break;
                case 3:
                    if (bd.Editores.Count == 0) break;
                    (string user, string password) = interfaceEditor.InterfaceLogin();
                    foreach (Editor ed in bd.Editores)
                    {
                        if (ed.UserName == user && ed.Password == password)
                        {
                            Console.WriteLine("Login bem-sucedido como editor!");
                            //logica depois do login ->
                            interfaceEditor.InterfaceMenuEditor();
                        }
                        else { Console.WriteLine("Usuario ou senha incorretos"); }
                    } 
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
