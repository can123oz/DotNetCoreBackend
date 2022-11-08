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
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<CarDetailDto> GetCarDetailsById(int id);
        IDataResult<List<CarImage>> GetCarImagesById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id);
        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
