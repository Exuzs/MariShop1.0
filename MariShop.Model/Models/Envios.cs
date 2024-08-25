using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Envios
{
    public int EnvioId { get; set; }

    public int? PedidoId { get; set; }

    public int? DireccionEnvioId { get; set; }

    public int? EstadoEnvioId { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public virtual Direccionesenvio? DireccionEnvio { get; set; }

    public virtual Estadosenvio? EstadoEnvio { get; set; }

    public virtual Pedidos? Pedido { get; set; }
}
