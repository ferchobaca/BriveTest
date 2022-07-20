using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BriveTest.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            ProdDeta = new HashSet<ProdDeta>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ProdDeta> ProdDeta { get; set; }
    }
}
