using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Usuarios
{
    public int UserId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public string? CodigoPostal { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? UltimoAcceso { get; set; }

    public virtual ICollection<Direccionesenvio> Direccionesenvios { get; set; } = new List<Direccionesenvio>();

    public virtual ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();

    public virtual ICollection<Roles> Rols { get; set; } = new List<Roles>();
}
