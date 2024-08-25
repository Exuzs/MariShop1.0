using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Pedidos
{
    public int PedidoId { get; set; }

    public int? UserId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string Estado { get; set; } = null!;

    public decimal Total { get; set; }

    public virtual ICollection<Detallespedido> Detallespedidos { get; set; } = new List<Detallespedido>();

    public virtual ICollection<Envios> Envios { get; set; } = new List<Envios>();

    public virtual ICollection<Transaccionespago> Transaccionespagos { get; set; } = new List<Transaccionespago>();

    public virtual Usuarios? User { get; set; }
}
