using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Categorias
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
