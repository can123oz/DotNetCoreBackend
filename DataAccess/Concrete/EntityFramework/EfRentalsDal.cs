using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rentals, DatabaseContext>, IRentalsDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Car on rental.CarId equals car.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.User on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 BrandName = car.Name
                             };
                return result.ToList();
            }
        }
    }
}
