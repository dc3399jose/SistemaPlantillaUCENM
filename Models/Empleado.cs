using System.ComponentModel.DataAnnotations; // 1. IMPORTANTE: Agrega esta línea

namespace SistemaPlanillaUCENM.Models
{
    public class Empleado
    {
        [Key] // 2. Esto le dice a la base de datos que este es el ID único
        public int Id { get; set; }

        public string Nombre { get; set; }
        public int HorasTrabajadas { get; set; }
        public decimal PagoPorHora { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal Impuesto { get; set; }
        public decimal SalarioNeto { get; set; }
        public string Clasificacion { get; set; }
    }
}