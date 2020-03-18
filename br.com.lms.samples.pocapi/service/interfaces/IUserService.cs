using br.com.lms.samples.pocapi.core.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace br.com.lms.samples.pocapi.service.interfaces
{
    public interface IUserService
    {
        Task<User> Create(User user);

        Task<User> Update(User user);

        User Get(string id);

        IOrderedQueryable<User> GetAll();

        Task<bool> Delete(string id);
    }
}
