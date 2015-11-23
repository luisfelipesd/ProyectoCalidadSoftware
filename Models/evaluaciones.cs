namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class evaluaciones
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int proyectos_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int categorias_id { get; set; }

        [StringLength(45)]
        public string a { get; set; }

        [StringLength(45)]
        public string b { get; set; }

        [StringLength(45)]
        public string c { get; set; }

        [StringLength(45)]
        public string resultado { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? fecha { get; set; }

        public virtual categorias categorias { get; set; }

        public virtual proyectos proyectos { get; set; }
    }
}
