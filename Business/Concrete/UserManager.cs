using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Message.SuccessMessage);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result,Message.SuccessMessage);
        }


        public IDataResult<List<UserDto>> GetAllUsers()
        {
            var result = _userDal.GetAllUserDtos();
            return new SuccessDataResult<List<UserDto>>(result, Message.SuccessMessage);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(p => p.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>(Message.UserNotFound);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>("User not found");
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return result;
        }
    }
}
