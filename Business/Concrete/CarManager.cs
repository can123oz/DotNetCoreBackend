using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation]
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car); //no need to validate like this.
            var result = BusinessRules.Run(CheckIfNameTaken(car.Name), CheckIfCarCountOfBrandCorrect(car.BrandId,10));
            if (result.Success)
            {
                _carDal.Add(car);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult();
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

        private IResult CheckIfNameTaken(string name)
        {
            var result = _carDal.GetAll(p => p.Name == name).Any();
            if (result)
            {
                return new ErrorResult(Message.NameTakenError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId, int maxNumber)
        {
            var result = _carDal.GetAll(p => p.BrandId == brandId).Any();
            if (result)
            {
                return new ErrorResult(Message.GeneralErrorMessage);
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult UpdateCar(Car car)
        {
            var updatedCar = _carDal.Get(p => p.Id == car.Id);
            if (updatedCar != null)
            {
                updatedCar.BrandId = car.BrandId;
                updatedCar.ColorId = car.ColorId;
                updatedCar.ColorId = car.ColorId;
                updatedCar.DailyPrice = car.DailyPrice;
                updatedCar.Description = car.Description;
                updatedCar.ModelYear = car.ModelYear;
                updatedCar.Name = car.Name;
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.GeneralErrorMessage);
        }
    }
}
