using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1, BrandId=1, ModelYear=2020, ColorId=2, DailyPrice=10200, Description="volvo"},
                new Car{Id=2, BrandId=1, ModelYear=2021, ColorId=3, DailyPrice=14200, Description="vw-golf"},
                new Car{Id=3, BrandId=2, ModelYear=2022, ColorId=1, DailyPrice=21140, Description="bmw"},
                new Car{Id=4, BrandId=3, ModelYear=2019, ColorId=2, DailyPrice=31550, Description="merso"},
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Expression<Func<Car, bool>> filter)
        {


        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            var selectedCar = _car.SingleOrDefault(p => p.Id == id);
            return selectedCar;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updatedCar = _car.SingleOrDefault(p => p.Id == car.Id);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.ColorId = car.ColorId;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.Description = car.Description;
        }

    }
}
