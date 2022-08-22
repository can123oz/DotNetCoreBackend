using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {

            //ValidationTool.Validate(new CarValidator(), car); //no need to validate like this.
            
            _carDal.Add(car);
            return new SuccessResult(Message.SuccessMessage);
            //return new ErrorResult(Message.ErrorMessage);
        }

        public IResult DeleteCar(int id)
        {
            _carDal.Delete(p => p.Id == id);
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
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Car>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<Car>>(Message.DataErrorMessage);
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            var result = _carDal.GetAll(p => p.ColorId == id);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Car>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<Car>>(Message.DataErrorMessage);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(p => p.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result, Message.SuccessMessage);
            }
            return new ErrorDataResult<Car>(result, Message.DataErrorMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();
            if (result != null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<CarDetailDto>>(result, Message.DataErrorMessage);
        }
    }
}
