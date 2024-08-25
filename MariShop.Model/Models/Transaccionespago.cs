using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Transaccionespago
{
    public int TransaccionId { get; set; }

    public int? PedidoId { get; set; }

    public int? MetodoPagoId { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaTransaccion { get; set; }

    public string Estado { get; set; } = null!;

    public string PayPalTransactionId { get; set; } = null!;

    public virtual Metodospago? MetodoPago { get; set; }

    public virtual Pedidos? Pedido { get; set; }
}
