namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proyectos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proyectos()
        {
            evaluaciones = new HashSet<evaluaciones>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(75)]
		  [Display(Name = "Nombre:")]
        public string nombre { get; set; }

		[Display(Name = "Descripción:")]
		public string descripcion { get; set; }

        [Required]
        [StringLength(85)]
		  [Display(Name ="Evaluador:")]
        public string evaluador { get; set; }

      [Column(TypeName = "date")]
		[Display(Name = "Fecha:")]
		public DateTime? fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evaluaciones> evaluaciones { get; set; }
    }
}
