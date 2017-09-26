using System.Collections.Generic;
using MyAngularAplication.Model;

namespace MyAngularAplication.Repositories
{
    public interface IUserRepository
    {
        User GetSingle(int id);
        User Add(User item);
        void Delete(int id);
        User Update(int id, User item);
        ICollection<User> GetAll();
        int Count();
    }
}
