namespace A3_modelagem
{
    internal class User
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { } 

        public User(string username, string email, string password)
        {
            UserName = username;
            Email = email;
            Password = password;
        }

        public virtual void login(string username, string password)
        {
            if (UserName.Equals(username) && Password.Equals(password))
                Console.WriteLine("Usuário logado com sucesso");
            else
                Console.WriteLine("Email ou senha incorretos");
        }
    }
}