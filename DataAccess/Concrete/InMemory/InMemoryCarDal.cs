using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear="2016", Description="Hasarsız, manuel, dizel", DailyPrice=13000},
                new Car{CarId=2, BrandId=1, ColorId=1, ModelYear="2018", Description="Hasarsız, otomatik, dizel", DailyPrice=16000},
                new Car{CarId=3, BrandId=2, ColorId=4, ModelYear="2011", Description="Hasarsız, manuel, benzin", DailyPrice=16000},
                new Car{CarId=4, BrandId=6, ColorId=3, ModelYear="2019", Description="Hasarsız, manuel, benzin", DailyPrice=21000},
                new Car{CarId=5, BrandId=6, ColorId=5, ModelYear="2017", Description="Hasarsız, van, manuel, dizel", DailyPrice=19000},
                new Car{CarId=6, BrandId=4, ColorId=2, ModelYear="2015", Description="Hasarsız, van, otomatik, dizel", DailyPrice=11000}
            
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetais()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
           
        }
    }
}
