﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReposityModule.Reposity1
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> All()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return All().FirstOrDefault(expression);
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where<TEntity>(predicate).AsQueryable<TEntity>();
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0,
                                               int size = 50)
        {
            var skipCount = index * size;
            var resetSet = filter != null
                                ? Context.Set<TEntity>().Where<TEntity>(filter).AsQueryable()
                                : Context.Set<TEntity>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public virtual void Create(TEntity TObject)
        {
            Context.Set<TEntity>().Add(TObject);
        }

        //public virtual void AddOrUpdate(Expression<Func<TEntity, object>> identifierExpression, params TEntity[] entities)
        //{
        //    Context.Set<TEntity>().AddOrUpdate(identifierExpression, entities);
        //}

        public virtual void Update(TEntity TObject)
        {
            try
            {
                var entry = Context.Entry(TObject);
                Context.Set<TEntity>().Attach(TObject);
                entry.State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //catch (OptimisticConcurrencyException ex)
            //{
            //    throw ex;
            //}
        }

        public virtual void Delete(TEntity TObject)
        {
            Context.Set<TEntity>().Remove(TObject);
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                Context.Set<TEntity>().Remove(obj);
            return Context.SaveChanges();
        }

        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }

        public virtual TEntity Find(params object[] keys)
        {
            return Context.Set<TEntity>().Find(keys);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault<TEntity>(predicate);
        }
    }
}
