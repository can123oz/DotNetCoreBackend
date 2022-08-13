using Business.Abstract;
using Business.Constants;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult AddCar(Car car)
        {
            if (car.Description != null)
            {
                _carDal.Add(car);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.ErrorMessage);
        }

        public IResult DeleteCar(int id)
        {
            _carDal.Delete(p=>p.Id == id);
            return new Result(true);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result, Message.DataSuccessMessage);
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            var result = _carDal.GetAll(p => p.BrandId == id);
            return new SuccessDataResult<List<Car>>(result,Message.DataSuccessMessage);
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            var result = _carDal.GetAll(p => p.Id == id);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(p => p.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result, Message.SuccessMessage);
            }
            return new ErrorDataResult<Car>(result,Message.DataErrorMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }
    }
}
