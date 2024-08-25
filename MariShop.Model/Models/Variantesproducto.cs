using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Variantesproducto
{
    public int VarianteId { get; set; }

    public int? ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? PrecioAdicional { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<Detallespedido> Detallespedidos { get; set; } = new List<Detallespedido>();

    public virtual Productos? Producto { get; set; }
}
