namespace A3_modelagem
{
    internal class User
    {
        //classe para representar todos os usuarios do sistema
        public int Id { get;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(int id,string username, string email, string password)
        {
            UserName = username;
            Email = email;
            Password = password;
            Id = id;
        }
        public User() { }
        public virtual void login(string username, string password)
        {
            if(UserName.Equals(username) && Password.Equals(password))
            {
                Console.WriteLine("Usuário logado com sucesso");
            }
            else
            {
                Console.WriteLine("Email ou senha incorretos");
            }
        }
    }
}
