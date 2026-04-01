namespace A3_modelagem
{
    internal class Editor : User
    {
        
        public Editor(string name, string email, string password)
            : base(name, email, password) { }
   
        public Editor() : base() { }
        public override void login(string username, string password)
        {
            base.login(username, password);
        }
        public void MostrarInformacoesEspecificas(Editor editor)
        {
            Console.WriteLine($"ID: {editor.Id}");
            Console.WriteLine($"Nome: {editor.UserName}");
            Console.WriteLine($"Email: {editor.Email}");
            Console.WriteLine($"Senha: {editor.Password}");
        }
    }
}
