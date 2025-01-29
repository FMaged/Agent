
using Domain.Entities;
using Domain.user.Aggregate;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {

        User GetById(int userId);
        void Add(User user);
        void Update(User user);
        void Delete(int userId);






    }
}
