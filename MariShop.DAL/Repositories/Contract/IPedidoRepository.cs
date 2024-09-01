using MariShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariShop.DAL.Repositories.Contract
{
    public interface IPedidoRepository : IGenericRepository<Pedidos>
    {
        Task<IEnumerable<Pedidos>> ObtenerPedidosPorUsuario(int usuarioId);
        Task<Pedidos> ObtenerPedidoConDetalles(int pedidoId);
    }
}
