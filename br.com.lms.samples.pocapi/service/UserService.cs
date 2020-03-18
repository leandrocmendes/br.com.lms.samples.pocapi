using br.com.lms.samples.pocapi.core.model;
using br.com.lms.samples.pocapi.core.repository.interfaces;
using br.com.lms.samples.pocapi.service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace br.com.lms.samples.pocapi.service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<User> Create(User user)
        {
            var success = await _repository.CreateAsync(user);

            if (success)
                return user;
            else
                return null;
        }

        public async Task<bool> Delete(string id)
        {
            var success = await _repository.Delete(id);

            return success;
        }

        public User Get(string id)
        {
            var result = _repository.Get(id);

            return result;
        }

        public IOrderedQueryable<User> GetAll()
        {
            var result = _repository.GetAll();

            return result;
        }

        public async Task<User> Update(User user)
        {
            var success = await _repository.Update(user);

            if (success)
                return user;
            else
                return null;
        }
    }
}
