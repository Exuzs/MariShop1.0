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
        private
    }
}
