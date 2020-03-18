using br.com.lms.samples.pocapi.core.model;
using System.Linq;
using System.Threading.Tasks;

namespace br.com.lms.samples.pocapi.core.repository.interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(User user);

        Task<bool> Update(User user);

        User Get(string id);

        IOrderedQueryable<User> GetAll();

        Task<bool> Delete(string id);
    }
}
