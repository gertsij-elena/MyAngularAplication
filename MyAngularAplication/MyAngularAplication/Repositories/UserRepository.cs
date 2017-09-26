using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MyAngularAplication.Model;

namespace MyAngularAplication.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ConcurrentDictionary<int, User> _db = new ConcurrentDictionary<int, User>();
        public User GetSingle(int id)
        {
            User user;
            return _db.TryGetValue(id, out user) ? user : null;

        }
        public User Add(User item)
        {
            item.Id = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;

            if (_db.TryAdd(item.Id, item))
            {
                return item;
            }

            throw new Exception("Item could not be added");

        }
        public void Delete(int id)
        {
            User user;
            if (!_db.TryRemove(id, out user))
            {
                throw new Exception("Item could not be removed");
            }

        }
        public User Update(int id, User item)
        {
            _db.TryUpdate(id, item, GetSingle(id));
            return item;
        }
        public ICollection<User> GetAll()
        {
            return _db.Values;
        }
        public int Count()
        {
            return _db.Count;
        }
    }
}
