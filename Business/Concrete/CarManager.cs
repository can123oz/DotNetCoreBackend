using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTO;
using FluentValidation.Results;
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
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [ValidationAspect(typeof(CarValidator))]
        //[SecuredOperation("admin,moderator")]
        [CacheRemoveAspect("ICarService.Get")] //deletes all cache which includes get keyword
        public IResult AddCar(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car); //no need to validate like this.
            
            //CarValidator validator = new(); //the way in the documents
            //ValidationResult resultFluent = validator.Validate(car);

            var result = BusinessRules.Run(CheckIfNameTaken(car.Name), CheckIfCarCountOfBrandCorrect(car.BrandId, 100));
            if (result == null)
            {
                _carDal.Add(car);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult();
        }

        [CacheRemoveAspect("ICarService.GetAll")]
        public IResult DeleteCar(int id)
        {
            _carDal.Delete(p => p.Id == id);
            return new Result(true);
        }


        //[SecuredOperation("admin,moderator")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //this is the badway.....
            //if (_cacheManager.IsAdd("GetAll()"))
            //{
            //    var result1 = _cacheManager.Get<List<Car>>("GetAll()");
            //    return new SuccessDataResult<List<Car>>(result1, Message.DataSuccessMessage);
            //}
            //else
            //{
            //    var result2 = _carDal.GetAll();
            //    _cacheManager.Add("GetAll()", result2, 5);
            //    return new SuccessDataResult<List<Car>>(result2, Message.DataSuccessMessage);
            //}

            var result = _carDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Car>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<Car>>(Message.DataErrorMessage);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            var result = _carDal.GetCarDetails().Where(p => p.BrandId == id).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Message.DataErrorMessage);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id)
        {
            var result = _carDal.GetCarDetails().Where(p => p.ColorId == id).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Message.DataErrorMessage);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(p => p.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result, Message.SuccessMessage);
            }
            return new ErrorDataResult<Car>(result, Message.DataErrorMessage);
        }

        [CacheAspect]
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
            var result = _carDal.GetAll(p => p.BrandId == brandId);
            if (result.Count > maxNumber)
            {
                return new ErrorResult(Message.GeneralErrorMessage);
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")] //deletes all cache which includes get keyword
        //[CacheRemoveAspect("ICarService.GetById")]
        public IResult UpdateCar(Car car)
        {
            var updatedCar = _carDal.Get(p => p.Id == car.Id);
            if (updatedCar != null)
            {
                #region
                //updatedCar.BrandId = car.BrandId;
                //updatedCar.ColorId = car.ColorId;
                //updatedCar.ColorId = car.ColorId;
                //updatedCar.DailyPrice = car.DailyPrice;
                //updatedCar.Description = car.Description;
                //updatedCar.ModelYear = car.ModelYear;
                //updatedCar.Name = car.Name;
                #endregion 

                _carDal.Update(car);
                return new SuccessResult(Message.SuccessMessage);
            }
            return new ErrorResult(Message.GeneralErrorMessage);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandName(string brand)
        {
            var cars = _carDal.GetCarDetails().Where(p => p.BrandName == brand).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(cars);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColor(string color)
        {
            var cars = _carDal.GetCarDetails().Where(p => p.ColorName == color).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(cars);
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int id)
        {
            var car = _carDal.GetCarDetailByCarId(id);
            if (car != null)
            {
                return new SuccessDataResult<CarDetailDto>(car);
            }
            return new ErrorDataResult<CarDetailDto>(car, Message.DataErrorMessage);
        }

        public IDataResult<List<CarImage>> GetCarImagesById(int id)
        {
            var result = _carImageService.GetByCarId(id).Data;
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<CarImage>>(result, Message.DataErrorMessage);
        }

        public IDataResult<List<CarDetailDto>> GetFilteredCars(int colorId, int brandId)
        {
            var result = _carDal.GetCarDetails().Where(p => p.ColorId == colorId && p.BrandId == brandId).ToList();
            if (result != null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result, Message.DataSuccessMessage);
            }
            return new ErrorDataResult<List<CarDetailDto>>(result, Message.GeneralErrorMessage);
        }
    }
}
