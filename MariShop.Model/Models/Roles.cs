using System;
using System.Collections.Generic;

namespace MariShop.Model.Models;

public partial class Roles
{
    public int RolId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuarios> Users { get; set; } = new List<Usuarios>();
}
