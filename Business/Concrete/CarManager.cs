using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }


        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Add(Car c)
        {
            if (c.DailyPrice > 0 && c.CarName.Length > 1)
            {
                _carDal.Add(c);
            }
            else
            {
                Console.WriteLine("Kiralama bedili 0'dan büyük ve araba model bölümü en az iki karakter olmalı...");
            }

        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
