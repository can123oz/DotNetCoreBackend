using Business.Abstract;
using Core.Utilities.Results;
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
        public IResult AddRental(Rentals rentals)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteRental(int id)
        {
            throw new NotImplementedException();
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
