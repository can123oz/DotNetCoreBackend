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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int Id)
        {
            _carImageDal.Delete(p => p.Id == Id);
            return new Result(true);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result,Message.SuccessMessage);
        }

        public IResult GetByCarId(int Id)
        {
            var result = _carImageDal.Get(p => p.CarId == Id);
            if (result != null)
            {
                return new SuccessDataResult<CarImage>(result);
            }
            return new ErrorDataResult<CarImage>();
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

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}
