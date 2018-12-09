using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories.Data
{
    public class KinShipRepository : IKinShipRepository
    {
        private DataContext dataContext;
        public KinShipRepository(DataContext dataContext)
        {           
            this.dataContext = dataContext;
        }

        public void Create(KinShip ks)
        {
            dataContext.Entry(ks).State = EntityState.Added;
            dataContext.SaveChanges();
        }
        public List<KinShip> GetAll()
        {
            return dataContext.KinShip.ToList();
        }
        
        public void Update(KinShip ks)
        {            
            dataContext.Entry(ks).State = EntityState.Modified;           
            dataContext.SaveChanges();
        }
        public KinShip GetById(int id)
        {
            return dataContext.KinShip.SingleOrDefault(x=>x.id == id);
        }
        
        public void Delete(int id)
        {
            dataContext.Remove(GetById(id));
            dataContext.SaveChanges();
        }
        public Task<List<KinShip>> GetAllAsync()
        {
            return dataContext.KinShip.ToListAsync();
        }

         public Task<KinShip> GetByIdAsync(int id)
        {
            return dataContext.KinShip.SingleOrDefaultAsync(x => x.id == id);
        }
    }
}