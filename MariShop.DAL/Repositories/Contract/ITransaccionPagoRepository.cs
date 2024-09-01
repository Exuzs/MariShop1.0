using MariShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariShop.DAL.Repositories.Contract
{
    public interface ITransaccionPagoRepository : IGenericRepository<Transaccionespago>
    {
        Task<Transaccionespago> ObtenerPorIdTransaccion(string transaccionId);
    }
}
