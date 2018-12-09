using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories.Data
{
    public class DependentRepository : IDependentRepository
    {
        private DataContext dataContext;
        public DependentRepository(DataContext dataContext)
        {           
            this.dataContext = dataContext;
        }

        public void Create(Dependent dep)
        {
            dep.associated = dataContext.Associated.Find(dep.associatedid);
            dep.kinShip = dataContext.KinShip.Find(dep.kinshipid);
            dataContext.Entry(dep).State = EntityState.Added;
            dataContext.SaveChanges();
        }
        public List<Dependent> GetAll()
        {
            return dataContext.Dependent.ToList();
        }
        
        public void Update(Dependent dep)
        {            
            dataContext.Entry(dep).State = EntityState.Modified;           
            dataContext.SaveChanges();
        }
        public Dependent GetById(int id)
        {
            return dataContext.Dependent.SingleOrDefault(x=>x.id == id);
        }
        
        public void Delete(int id)
        {
            dataContext.Remove(GetById(id));
            dataContext.SaveChanges();
        }

        public Task<List<Dependent>> GetAllAsync()
        {
            return dataContext.Dependent.ToListAsync();
        }

         public Task<Dependent> GetByIdAsync(int id)
        {
            return dataContext.Dependent.Include(e => e.kinShip).Include(e => e.associated).SingleOrDefaultAsync(x => x.id == id);
        }
    }
}