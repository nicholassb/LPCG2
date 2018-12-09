using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;

namespace ToDoList.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {}

        public DbSet<User> User { get; set; }
        public DbSet<Associated> Associated { get; set; }
        public DbSet<Dependent> Dependent { get; set; }
        public DbSet<KinShip> KinShip { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
    }
}