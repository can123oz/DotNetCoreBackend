using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text.Json;

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




          //  string myJson = "{departman:" + contactForm.Departman + ", ad: " + contactForm.Name + ", soyad: "
          //+ contactForm.Surname + ", cinsiyet: " + "Belirtilmemiş" + ", eposta: "
          //+ contactForm.Email + ", telefon: " + phone + ", il: "
          //+ il + ", ilce:" + ilce + ", mesaj: "
          //+ ilce + "urun_adi: " + contactForm.ProductName
          //+ ", siparis_no: " + contactForm.OrderNo
          //+ ", kvkk_onay: " + "X"
          //+ ", kvkk_onay_tarih: " + kvkk_tarih
          //+ ", arama_onay: " + "X"
          //+ ", arama_onay_tarih: " + kvkk_tarih
          //+ ", sms_onay: " + "X"
          //+ ", sms_onay_tarih: " + kvkk_tarih
          //+ ", email_onay: " + "X"
          //+ ", email_onay_tarih: " + kvkk_tarih
          //+ "}";
            //carManager.AddCar(car);

            //Car car2 = new Car()
            //{
            //    //Name = "Son 2. araba denenen",
            //    //BrandId = 1,
            //    //ModelYear = 2022,
            //    //DailyPrice = 120000,
            //    //Description = "son denemedim",
            //};
            //var result = carManager.AddCar(car2);
            //Console.WriteLine(result.Message);
            //DatabaseContext context = new DatabaseContext();
            //context.Car.Add(car2);
            //context.SaveChanges();

            //foreach (var item in carManager.GetAll().Data)
            //{
            //    Console.WriteLine(item.Name);

            //}
            //Console.WriteLine("-----------------------------------");

            //foreach (var item in carManager.GetCarDetails().Data)
            //{
            //    Console.Write(item.BrandName + " :  " + item.CarName);
            //}

            //Console.WriteLine("-----------------------------------");
            //foreach (var item in carManager.GetAll().Data)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("-----------------------------------");
            //foreach (var item in carManager.GetByColorId(2).Data)
            //{
            //    Console.WriteLine(item.Description);
            //}

            //DatabaseContext context = new DatabaseContext();

            //foreach (var item in context.User)
            //{
            //    Console.WriteLine(item.FirstName);
            //}
            //Console.WriteLine("-----------------------------------");

            //User user = new User()
            //{
            //    FirstName = "denemeDal",
            //    LastName = "ozdmr",
            //    Email = "can@gas.com",
            //    Password = "q132asd",
            //};

            //UserManager users = new UserManager(new EfUserDal());

            ////users.AddUser(user);

            //foreach (var item in users.GetAll().Data)
            //{
            //    Console.WriteLine(item.FirstName);
            //}



            Console.WriteLine("-----------------------------------");


            Console.ReadLine();
        }
    }



}
