using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Metodospago
{
    public int MetodoPagoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Transaccionespago> Transaccionespagos { get; set; } = new List<Transaccionespago>();
}
