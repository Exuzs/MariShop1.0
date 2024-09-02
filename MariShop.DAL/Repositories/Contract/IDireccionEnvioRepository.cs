using MariShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariShop.DAL.Repositories.Contract
{
    internal interface IDireccionEnvioRepository : IGenericRepository<Direccionesenvio>
    {
        Task<IEnumerable<Direccionesenvio>> ObtenerDireccionesPorUsuario(int usuarioId);
    }
}
