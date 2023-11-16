using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;
using Utilities.Response;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetActiveAll()
        {
            return _userDal.GetAll();
        }

        public IList<User> GetAllActiveUserAndRoles()
        {
            return _userDal.GetAll(x=>x.Status == (int)Status.Online, x=>x.Include(x=>x.UserRole));
        }

		public Result<User> Register(User user)
		{
            Result<User> result = new Result<User>();
            User userControl = _userDal.Get(x => x.Email != user.Email);
            if (userControl!=null)
            {
				result.SetStatus(false).SetMessage($"{user.Email} zaten kullanılıyor !");
                return result;
			}
			  
            if (user!=null)
            {
                User addUser = _userDal.Add(user);
                if (addUser != null)
                    result.SetData(addUser).SetStatus(true);
                else
                    result.SetStatus(false).SetMessage("Beklenmedik bir problem yaşandı !");
            }
            else
            {
                result.SetMessage("Lütfen bir kullanıcı gönderiniz !").SetStatus(false);
			}

            return result;
		}


		public Result<User> Update(User user)
		{
			Result<User> result = new Result<User>();
			User userControl = _userDal.Get(x => x.Id == user.Id);
			if (userControl==null)
			{
				result.SetStatus(false).SetMessage($"ID = {user.Id} kullanıcı bulunamadı !");
				return result;
			}

			if (user != null)
			{
				User addUser = _userDal.Update(user);
				if (addUser != null)
					result.SetData(addUser).SetStatus(true);
				else
					result.SetStatus(false).SetMessage("Beklenmedik bir problem yaşandı !");
			}
			else
			{
				result.SetMessage("Lütfen bir kullanıcı gönderiniz !").SetStatus(false);
			}

			return result;
		}

		public Result<User> Remove(int Id)
		{
			Result<User> result = new Result<User>();
			User userControl = _userDal.Get(x => x.Id == Id);
			if (userControl == null)
			{
				result.SetStatus(false).SetMessage($"ID = {Id} kullanıcı bulunamadı !");
				return result;
			}

			if (userControl != null)
			{
				userControl.Status = 2;
				User addUser = _userDal.Update(userControl);
				if (addUser != null)
					result.SetData(addUser).SetStatus(true);
				else
					result.SetStatus(false).SetMessage("Beklenmedik bir problem yaşandı !");
			}
			else
			{
				result.SetMessage("Lütfen bir kullanıcı gönderiniz !").SetStatus(false);
			}

			return result;
		}

        public Result<User> Login(string email, string password)
        {
            Result<User> result = new Result<User>();
            User userControl = _userDal.Get(x => x.Email == email && x.Password == password);

			if (userControl != null)
				result.SetData(userControl).SetStatus(true);
			else
				result.SetMessage("Kullanıcı bulunamadı !").SetStatus(false);

			return result;
        }

        public Result<User> Get(int Id)
        {
            Result<User> result = new Result<User>();
            User userControl = _userDal.Get(x => x.Id == Id);

            if (userControl != null)
                result.SetData(userControl).SetStatus(true);
            else
                result.SetMessage("Kullanıcı bulunamadı !").SetStatus(false);

            return result;
        }
    }
}
