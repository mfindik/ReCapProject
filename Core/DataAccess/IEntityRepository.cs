using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //1: T üzerinde yapabilinecekler
    //1:where : generic constraint generek kısıt
    //1:class : referans tip (bildiğimiz class değil yani)
    //1:IEntitiy : IEntity olabilir veya IEntitiy implemente edilen bir nesne olabilr
    //1:new() : new'lenebilir olmalı
    //2:Expression<Func<T,bool>> : filtreleme yapısı Linq ile beraber gelir
    public interface IEntityRepository<T> where T : class, IEntity, new()//1
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//2:filter isteğe bağlı
        T Get(Expression<Func<T, bool>> filter);//2:filter zorunlu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
