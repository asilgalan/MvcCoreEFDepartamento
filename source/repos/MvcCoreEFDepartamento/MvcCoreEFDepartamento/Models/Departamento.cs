using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEFDepartamento.Models
{
    [Table("DEPT")]
    public class Departamento
    {

        [Key]
        [Column("DEPT_NO")]
        public int idDepartamento { get; set; }

        [Column("DNOMBRE")]
        public string? DNombre { get; set; }
        [Column("LOC")]
        public string? Loc { get; set; }
    }
}
