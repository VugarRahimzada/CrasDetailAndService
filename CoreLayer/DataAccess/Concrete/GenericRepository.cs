using CoreLayer.DataAccess.Abstract;
using CoreLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CoreLayer.DataAccess.Concrete
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                if (entity.Delete==0)
                {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Modified;
                entity.Delete = entity.Id;
                entity.UpdateTime = DateTime.Now;
                }
                else
                {
                    var deleteEntity = context.Entry(entity);
                    deleteEntity.State = EntityState.Modified;
                    entity.Delete = 0;
                    entity.UpdateTime = DateTime.Now;
                }
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void HardDelete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<TEntity> GetActiv()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(x=>x.Delete == 0).ToList();
            }
        }



        //public TEntity FristOrDefault(Expression<Func<TEntity, bool>> filter)
        //{
        //    using (TContext context = new TContext())
        //    {
        //        return context.Set<TEntity>().FirstOrDefault(filter);
        //    }
        //}
    }
}
