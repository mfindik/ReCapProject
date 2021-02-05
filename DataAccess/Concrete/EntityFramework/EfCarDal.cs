using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //using : Bildiğimiz using degildir IDissposable patern implementation of c#
            using (CarContext context=new CarContext())//using nesnesine yazdığımız bilgiler işi bitince atılır. sadece new lesekde olur ama bu şekild dah performanslı çalışacaktır
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarContext context = new CarContext())//using nesnesine yazdığımız bilgiler işi bitince atılır. sadece new lesekde olur ama bu şekild dah performanslı çalışacaktır
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarContext context = new CarContext())
            {
                //Burada sadece filterden gelen id ye göre tek bir kayıt getireceğiz
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                // filter boşsa ? ilk bölüm çalışacak
                //DbSet'deki Car'a yerleş yani ben Cars tablosuyla çalışacağım
                //Veritabanındaki Cars tablosunu tamamını Listeye çevir ve döndür
                // filter doluysa : şimdi ikinci bölüm çalışacak
                //DBSet'daki Car'a yerleş Cars tablosundaki filter de istediğim bilgileri getir ve liste olarak geri döndür

                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarContext context = new CarContext())//using nesnesine yazdığımız bilgiler işi bitince atılır. sadece new lesekde olur ama bu şekild dah performanslı çalışacaktır
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
