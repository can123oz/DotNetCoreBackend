using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult AddUser(User user);
        IResult DeleteUser(int id);
        IResult UpdateUser(User user);
    }
}
