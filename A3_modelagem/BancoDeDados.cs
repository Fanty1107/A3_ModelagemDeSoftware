namespace A3_modelagem
{
    using System.Collections.Generic;
    internal class BancoDeDados
    {

        //enquanto não temos um banco de dados real, vamos usar listas para armazenar os dados
        public List<Editor> Editores { get; set; }
        public List<Videos> Videos { get; set; }
        public List<User> Usuarios { get; set; }
        public List<LiveChat> Chats { get; set; }
        public BancoDeDados()
        {
            Editores = new List<Editor>();
            Videos = new List<Videos>();
            Usuarios = new List<User>();
            Chats = new List<LiveChat>();  
        }
    }
}
