using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult GetById(int Id);
        IDataResult<List<CarImage>> GetByCarId(int Id);
        IResult Add(CarImage carImage, IFormFile formFile);
        IResult Delete(int Id);
        IResult Update(CarImage carImage, IFormFile formFile);
    }
}
