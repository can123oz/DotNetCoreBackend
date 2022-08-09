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
    public class CustomersManager : ICustomersService
    {
        ICustomersDal _customersDal;

        public CustomersManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }
        public IResult AddCustomer(Customers customers)
        {
            _customersDal.Add(customers);
            return new Result(Message.SuccessMessage, true);
        }

        public IResult DeleteCustomer(int id)
        {
            _customersDal.Delete(p => p.Id == id);
            return new SuccessResult(Message.SuccessMessage);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            var result = _customersDal.GetAll();
            return new DataResult<List<Customers>>(result,Message.DataSuccessMessage,true);
        }

        public IDataResult<Customers> GetById(int id)
        {
            var result = _customersDal.Get(p => p.Id == id);
            return new DataResult<Customers>(result, true);
        }

        public IResult UpdateCustomer(Customers customers)
        {
            var updatedCustomer = _customersDal.Get(p => p.Id == customers.Id);
            _customersDal.Update(updatedCustomer);
            return new SuccessResult();
        }
    }
}