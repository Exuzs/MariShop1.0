using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Direccionesenvio
{
    public int DireccionEnvioId { get; set; }

    public int? UserId { get; set; }

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string CodigoPostal { get; set; } = null!;

    public virtual ICollection<Envios> Envios { get; set; } = new List<Envios>();

    public virtual Usuarios? User { get; set; }
}
