using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace A3_modelagem
{
    internal class AppDbContext : DbContext
    {
        // O EF Core vai usar a herança (Editor herda de User) para criar uma tabela só chamada "Usuarios"
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Editor> Editores { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<LiveChat> Chats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sistema_video.db");
        }
    }
}
