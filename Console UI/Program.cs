using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using System;
using System.Collections.Generic;

namespace Console_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.Description);
            //}

            //DatabaseContext _context = new DatabaseContext();
            //CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.Description);
            //}
            //Console.WriteLine("-----------------------------------");
            //foreach (var item in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(item.Description);
            //}
            //Console.WriteLine("-----------------------------------");

            //Car car1 = new Car { BrandId=1,ColorId=1,DailyPrice=200,Description="s",ModelYear=1992 };
            //Car car2 = new Car { BrandId=2,ColorId=2,DailyPrice=-200,Description="bentley",ModelYear=2020 };
            //List<Car> _car = new List<Car>
            //{
            //    new Car{BrandId=1, ModelYear=2020, ColorId=2, DailyPrice=10200, Description="v"},
            //    new Car{BrandId=1, ModelYear=2021, ColorId=3, DailyPrice=14200, Description="vw-golf"},
            //    new Car{BrandId=2, ModelYear=2022, ColorId=1, DailyPrice=-123, Description="bmw"},
            //    new Car{BrandId=3, ModelYear=2019, ColorId=2, DailyPrice=31550, Description="merso"},
            //};
            //foreach (var item in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(item.Description);
            //}
            //Console.WriteLine("-----------------------------------");,

            CarManager carManager = new CarManager(new EfCarDal());

            //Car car = new Car()
            //{
            //    Name = "Son Eklenen",
            //    BrandId = 1,
            //    ModelYear = 1992,
            //    DailyPrice = 120000,
            //    Description = "son denemedim",
            //};
            //carManager.AddCar(car);

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Name);

            }
            Console.WriteLine("-----------------------------------");

            foreach (var item in carManager.GetCarDetails())
            {
                Console.Write(item.BrandName + " :  " + item.CarName);
            }

            Car car2 = new Car()
            {
                Name = "Son Eklenen",
                BrandId = 1,
                ModelYear = 1992,
                DailyPrice = 120000,
                Description = "son denemedim"
            };
            Console.WriteLine("-----------------------------------");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("-----------------------------------");
            foreach (var item in carManager.GetByColorId(2))
            {
                Console.WriteLine(item.Description);
            }
            Console.ReadLine();
        }
    }
}
