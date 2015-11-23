namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class categorias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categorias()
        {
            evaluaciones = new HashSet<evaluaciones>();
        }

        public int id { get; set; }

        public int id_padre { get; set; }

        [Required]
        [StringLength(115)]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        [StringLength(45)]
        public string audiencia { get; set; }

        [StringLength(45)]
        public string escala { get; set; }

        [StringLength(45)]
        public string formula { get; set; }

        public int orden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evaluaciones> evaluaciones { get; set; }
    }
}
