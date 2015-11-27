namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class evaluaciones
    {
        public int id { get; set; }

        public int proyectos_id { get; set; }

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
