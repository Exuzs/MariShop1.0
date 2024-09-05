using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MariShop.DAL.Repositories.Contract;
using MariShop.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MariShop.DAL.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly YourDbContextName _dbContextName;

        public GenericRepository(YourDbContextName dbContextName)
        {
            _dbContextName = dbContextName;
        }

        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel model = await _dbContextName.Set<TModel>().FirstOrDefaultAsync(filtro);
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Crear(TModel modelo)
        {
            try
            {
                _dbContextName.Set<TModel>().Add(modelo);
                await _dbContextName.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModel modelo)
        {
            try
            {
                _dbContextName.Set<TModel>().Update(modelo);
                await _dbContextName.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModel modelo)
        {
            try
            {
                _dbContextName.Set<TModel>().Remove(modelo);
                await _dbContextName.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModel> query = filtro == null ? _dbContextName.Set<TModel>() : _dbContextName.Set<TModel>().Where(filtro);
                return query;
            }
            catch
            {
                throw;
            }
        }
    }
}