using System.Collections.Generic;
using System.Threading.Tasks;
using datingapp.api.Models;

namespace datingapp.api.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<System.Collections.Generic.IEnumerable<User>> GetUsers();
        Task<User> GetUser(int Id);
    }
}