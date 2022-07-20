using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BriveTest.Models
{
    public partial class ProdDeta
    {
        public int IdDetalle { get; set; }
        public int? CodBarr { get; set; }
        public string Nombre { get; set; }
        public int? Cantidad { get; set; }
        public double? PrecUnit { get; set; }
        public int? IdSucursal { get; set; }

        public virtual Producto CodBarrNavigation { get; set; }
        public virtual Sucursal IdSucursalNavigation { get; set; }
    }
}
