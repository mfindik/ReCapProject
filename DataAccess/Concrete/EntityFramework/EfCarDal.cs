using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
        
                var result = from cr in context.Cars
                             join br in context.Barands 
                             on cr.BrandId equals br.BrandId
                             join cl in context.Colors
                             on cr.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = cr.CarId,
                                 CarName = cr.CarName,
                                 BrandName = br.BrandName,
                                 ColorName = cl.ColorName
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetais()
        {
            throw new NotImplementedException();
        }
    }
}
