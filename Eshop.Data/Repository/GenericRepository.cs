using Eshop.Data.Context;
using Eshop.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {

        #region constructor

        private EshopBackendDBContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(EshopBackendDBContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<TEntity>();
        }

        #endregion

        public void AddEntity(TEntity entity)
        {
            entity.CreationDateTime = DateTime.Now;
            entity.ModificationDateTime = DateTime.Now; 
            _dbSet.Add(entity); 
        }

        public IQueryable<TEntity> GetEntitiesQuery()
        {
            return _dbSet.AsQueryable();
        }



        public TEntity GetEntityById(long entityId)
        {
            return _dbSet.SingleOrDefault(e=>e.Id== entityId);
        }

        public void UpdateEntity(TEntity entity)
        {
            entity.ModificationDateTime = DateTime.Now;
            _dbSet.Update(entity);
        }



        public void RemoveEntity(TEntity entity)
        {
            entity.IsDeleted=true;
            UpdateEntity(entity);
        }



        public void RemoveEntity(long entityId)
        {
            var entity = GetEntityById(entityId);
            _dbSet.Remove(entity);
        }



        public void SaveChanges()
        {
            _context.SaveChanges();  
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
