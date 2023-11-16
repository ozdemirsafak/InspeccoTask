using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Response;

namespace BusinessLayer.Abstract
{
    public interface IUserService:IGenericService<User>
    {
        public IList<User> GetAllActiveUserAndRoles();
        public Result<User> Get(int Id);
        public Result<User> Register(User user);
		public Result<User> Update(User user);
		public Result<User> Remove(int Id);
        public Result<User> Login(string email,string password);
    }
}
