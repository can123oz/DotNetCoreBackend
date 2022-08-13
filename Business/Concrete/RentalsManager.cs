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
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalDal;

        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalDal = rentalsDal;
        }

        public IResult AddRental(Rentals rentals)
        {
            _rentalDal.Add(rentals);
            return new Result(Message.SuccessMessage, true);
        }

        public IResult DeleteRental(int id)
        {
            _rentalDal.Delete(p => p.Id == id);
            return new Result(true);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateRental(Rentals rentals)
        {
            throw new NotImplementedException();
        }
    }
}
