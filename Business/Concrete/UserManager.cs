using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult AddUser(User user)
        {
            if (user.FirstName != null)
            {
                _userDal.Add(user);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.ErrorMessage);
        }

        public IResult DeleteUser(int id)
        {
            _userDal.Delete(p => p.Id == id);
            return new SuccessResult(Message.SuccessMessage);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new DataResult<List<User>>(result, true);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            return new SuccessDataResult<User>(result, Message.DataSuccessMessage);
        }

        public IResult UpdateUser(User user)
        {
            var updatedUser = _userDal.Get(p => p.Id == user.Id);
            if (updatedUser.FirstName != null)
            {
                _userDal.Update(updatedUser);
                return new SuccessResult();
            }
            return new ErrorResult(Message.ErrorMessage);
        }
    }
}
