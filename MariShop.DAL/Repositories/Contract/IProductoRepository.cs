using MariShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariShop.DAL.Repositories.Contract
{
    public interface IProductoRepository : IGenericRepository<Productos>
    {
        Task<IEnumerable<Productos>> ObtenerProductosPorCategoria(int categoriaId);
        Task<IEnumerable<Productos>> ObtenerProductosEnOferta();
    }
}
