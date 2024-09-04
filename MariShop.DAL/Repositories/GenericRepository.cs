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
    public class GenericRepository<TModel> :IGenericRepository<TModel> where TModel : class
    {
        private readonly YourDbContextName _dbContextName;

        public GenericRepository(YourDbContextName dbContextName)
        {
            _dbContextName = dbContextName;
        }

        public Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Crear(TModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(TModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(TModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }

    }
}
