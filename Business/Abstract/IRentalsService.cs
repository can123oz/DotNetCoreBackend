using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IResult GetById(int id);
        IResult AddRental(RentalDto rentalDto);
        IResult DeleteRental(int id);
        IResult UpdateRental(Rentals rentals);
        IResult ReturnCar(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
