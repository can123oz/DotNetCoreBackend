using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Add(formFile);
            if (!imageResult.Success)
            {
                return new ErrorResult(Message.ErrorMessage);
            }
            carImage.Name = imageResult.Message;
            carImage.Date = DateTime.Now;
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);

            return new SuccessResult(Message.ImageAdded);
        }

        public IResult Delete(int Id)
        {
            var delete = _carImageDal.Get(c => c.Id == Id);
            if (delete == null)
            {
                return new ErrorResult("Car Image Not Found.");
            }
            FileHelper.Delete(delete.ImagePath);
            _carImageDal.Delete(p => p.Id == Id);
            return new Result(true);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result,Message.SuccessMessage);
        }

        public IDataResult<List<CarImage>> GetByCarId(int Id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == Id);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result, result.Count + " " + Message.DataSuccessMessage);
            }
            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = Id, ImagePath = "/Uploads/Images/default.jpg"});
            return new SuccessDataResult<List<CarImage>>(images, "Default Image Returned.");
        }

        public IResult GetById(int Id)
        {
            var result = _carImageDal.Get(p => p.Id == Id);
            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }
            return new ErrorDataResult<CarImage>();
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult(Message.ImageNotFound);
            }

            var updated = FileHelper.Update(isImage.ImagePath, formFile);
            if (!updated.Success)
            {
                return new ErrorResult(Message.ImageError);
            }
            carImage.Date = DateTime.Now;
            carImage.ImagePath = (updated.Message);
            _carImageDal.Update(carImage);
            return new SuccessResult(Message.ImageUpdated);
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult("Max Car Image Reached.");
            }
            return new SuccessResult();
        }

    }
}
