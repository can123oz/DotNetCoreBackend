using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalDal;
        ICarService _carService;

        public RentalsManager(IRentalsDal rentalsDal, ICarService carService)
        {
            _rentalDal = rentalsDal;
            _carService = carService;
        }

        public IResult AddRental(RentalDto rentalDto)
        {
            var result = BusinessRules.Run(CarStatus(rentalDto.carId));
            if (result != null)
            {
                return result;
            }
            Rentals rent = new Rentals()
            {
                CarId = rentalDto.carId,
                ReturnDate = null,
                RentDate = DateTime.Now,
                CustomerId = rentalDto.userId,
            };
            _rentalDal.Add(rent);
            return new SuccessDataResult<Rentals>(rent, Message.RentCreated);
        }

        public IResult DeleteRental(int id)
        {
            _rentalDal.Delete(p => p.Id == id);
            return new Result(true);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Rentals>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<Rentals>>(result, Message.DataSuccessMessage);
        }

        public IResult GetById(int id)
        {
            var result = _rentalDal.Get(p => p.Id == id);
            if (result.Id > 0)
            {
                return new SuccessDataResult<Rentals>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<Rentals>(result, Message.DataSuccessMessage);
        }

        public IResult UpdateRental(Rentals rentals)
        {
            _rentalDal.Update(rentals);
            return new Result(Message.SuccessMessage, true);
        }

        public IResult ReturnCar(int rentalId)
        {
            var rental = _rentalDal.Get(p => p.CarId == rentalId);   
            if (rental != null)
            {
                if (rental.ReturnDate < DateTime.Now)
                {
                    return new ErrorResult("Already Returned deneme");
                }
                if (rental.ReturnDate == null)
                {
                    rental.ReturnDate = DateTime.Now;
                    _rentalDal.Update(rental);
                    return new SuccessResult("Car Returned Successfuly");
                }
                return new ErrorResult("Car return date not come.");
            }
            return new ErrorResult(Message.RentNotFound);
        }




        private IResult CarStatus(int carId)
        {
            var rental = _rentalDal.Get(p => p.CarId == carId);
           
            if (rental != null)
            {
                if (rental.ReturnDate == null)
                {
                    return new ErrorResult(Message.CarNotReturnYet);
                }
                int result = DateTime.Compare(rental.RentDate, Convert.ToDateTime(rental.ReturnDate));
                if (result >= 0)
                {
                    return new SuccessResult(Message.CarIsReadyToRent);
                }
                else
                {
                    return new ErrorResult(Message.CarNotReturnYet);
                }
            }
            return new SuccessResult(Message.CarIsReadyToRent);
        }
    }
}
