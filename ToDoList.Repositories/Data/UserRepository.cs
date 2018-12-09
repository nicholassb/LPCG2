using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext dataContext;
        public UserRepository(DataContext dataContext)
        {           
            this.dataContext = dataContext;
        }

        public void Create(User user)
        {
            dataContext.Entry(user).State = EntityState.Added;
            dataContext.SaveChanges();
        }
        public List<User> GetAll()
        {
            return dataContext.User.ToList();
        }
        
        public void Update(User user)
        {            
            dataContext.Entry(user).State = EntityState.Modified;           
            dataContext.SaveChanges();
        }
        public User GetById(int id)
        {
            return dataContext.User.SingleOrDefault(x=>x.id == id);
        }
        
        public void Delete(int id)
        {
            dataContext.Remove(GetById(id));
            dataContext.SaveChanges();
        }

        public User AuthUser(User user)
        {
            return dataContext
                    .User
                    .SingleOrDefault(i => i.name == user.name && 
                                i.password == user.password);
        }

        public Task<List<User>> GetAllAsync()
        {
            return dataContext.User.ToListAsync();
        }

         public Task<User> GetByIdAsync(int id)
        {
            return dataContext.User.SingleOrDefaultAsync(x => x.id == id);
        }
    }
}