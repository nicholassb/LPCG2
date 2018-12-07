using ToDoList.Domain;

namespace ToDoList.Repositories.Interfaces
{
    public interface IUserRepository   
            : IRepositoryBase<User>
    {
        User AuthUser(User user);
    }
}
