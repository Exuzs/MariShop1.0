using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Detallespedido
{
    public int DetalleId { get; set; }

    public int? PedidoId { get; set; }

    public int? ProductoId { get; set; }

    public int? VarianteId { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Pedidos? Pedido { get; set; }

    public virtual Productos? Producto { get; set; }

    public virtual Variantesproducto? Variante { get; set; }
}
