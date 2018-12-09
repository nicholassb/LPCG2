using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories.Data
{
    public class MaritalStatusRepository : IStatusRepository
    {
        private DataContext dataContext;
        public MaritalStatusRepository(DataContext dataContext)
        {           
            this.dataContext = dataContext;
        }

        public void Create(MaritalStatus ms)
        {
            dataContext.Entry(ms).State = EntityState.Added;
            dataContext.SaveChanges();
        }
        public List<MaritalStatus> GetAll()
        {
            return dataContext.MaritalStatus.ToList();
        }
        
        public void Update(MaritalStatus ms)
        {            
            dataContext.Entry(ms).State = EntityState.Modified;           
            dataContext.SaveChanges();
        }
        public MaritalStatus GetById(int id)
        {
            return dataContext.MaritalStatus.SingleOrDefault(x=>x.id == id);
        }
        
        public void Delete(int id)
        {
            dataContext.Remove(GetById(id));
            dataContext.SaveChanges();
        }

        public Task<List<MaritalStatus>> GetAllAsync()
        {
            return dataContext.MaritalStatus.ToListAsync();
        }

         public Task<MaritalStatus> GetByIdAsync(int id)
        {
            return dataContext.MaritalStatus.SingleOrDefaultAsync(x => x.id == id);
        }
    }
}