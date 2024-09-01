using MariShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariShop.DAL.Repositories.Contract
{
    public interface IEnvioRepository : IGenericRepository<Envios>
    {
        Task<Envios> ObtenerEnvioPorPedido(int pedidoId);
    }
}


