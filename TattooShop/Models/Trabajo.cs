//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TattooShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trabajo
    {
        public int id { get; set; }
        public System.DateTime fecha { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> cita_id { get; set; }
        public Nullable<int> artista_id { get; set; }
        public Nullable<int> pago_id { get; set; }
    
        public virtual Artista Artista { get; set; }
        public virtual Cita Cita { get; set; }
        public virtual Pago Pago { get; set; }
    }
}