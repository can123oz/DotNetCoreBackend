using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService 
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<List<UserDto>> GetAllUsers();
        IDataResult<User> GetById(int id);
    }
}