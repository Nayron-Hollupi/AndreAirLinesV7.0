using System.Collections.Generic;
using AndreAirlinesDomain.Model;

namespace UserAPI.Service
{
    public interface IUserService
    {
        List<User> Get();

        User Get(string id);
        User Create(User user);
        void Update(string id, User userIn);
        void Remove(User userIn);
        void Remove(string id);
    }
}
