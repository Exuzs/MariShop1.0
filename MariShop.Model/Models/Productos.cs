using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Productos
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int? Stock { get; set; }

    public string? ImagenUrl { get; set; }

    public int? CategoriaId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Categorias? Categoria { get; set; }

    public virtual ICollection<Detallespedido> Detallespedidos { get; set; } = new List<Detallespedido>();

    public virtual ICollection<Variantesproducto> Variantesproductos { get; set; } = new List<Variantesproducto>();
}
