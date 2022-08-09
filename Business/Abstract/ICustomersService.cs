using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomersService
    {
        IDataResult<List<Customers>> GetAll();
        IDataResult<Customers> GetById(int id);
        IResult AddCustomer(Customers customers);
        IResult DeleteCustomer(int id);
        IResult UpdateCustomer(Customers customers);
    }
}
