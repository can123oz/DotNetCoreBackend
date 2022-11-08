using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        public CarDetailDto GetCarDetailByCarId(int Id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from p in context.Car
                             join c in context.Color on p.ColorId equals c.Id
                             join b in context.Brand on p.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 Describtion = p.Description,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 CarName = p.Name,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice
                             };
                return result.FirstOrDefault(p => p.Id == Id);
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from p in context.Car
                             join c in context.Color on p.ColorId equals c.Id
                             join b in context.Brand on p.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 Id = p.Id,
                                 BrandId = b.Id,
                                 Describtion = p.Description,
                                 ColorId = c.Id,
                                 CarName = p.Name,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = p.DailyPrice
                             };
                return result.ToList();
            }
        }


    }
}
