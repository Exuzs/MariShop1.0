using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariShop.Model.Models
{
    public partial class UsuarioRoles
    {
        public int UserId { get; set; }
        public int RolId { get; set; }

        public virtual Usuarios Usuario { get; set; } = null!;
        public virtual Roles Rol { get; set; } = null!;
    }   
}
