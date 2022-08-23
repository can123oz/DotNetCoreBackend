using Core.Utilities.Results;
using Entity.Concrete;
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
        IResult GetByCarId(int Id);
        IResult Add(CarImage carImage);
        IResult Delete(int Id);
        IResult Update(CarImage carImage);
    }
}
