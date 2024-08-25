using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Estadosenvio
{
    public int EstadoEnvioId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Envios> Envios { get; set; } = new List<Envios>();
}
