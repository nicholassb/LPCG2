using System.Threading.Tasks;
using ToDoList.Domain;

namespace ToDoList.Repositories.Interfaces
{
    public interface IDependentRepository : IRepositoryBase<Dependent>
    {
        Task<Dependent> GetByIdAsync(int id);
    }
}