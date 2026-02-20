using System.ComponentModel.DataAnnotations; // 1. Agrega esta referencia

namespace SistemaPlanillaUCENM.Models
{
    public class Prestamo
    {
        [Key] // 2. Indica que esta es la llave primaria
        public int Id { get; set; }

        public string Nombre { get; set; }
        public decimal Monto { get; set; }
        public int Meses { get; set; }
        public string TipoCliente { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal InteresTotal { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal CuotaMensual { get; set; }
        public string NivelRiesgo { get; set; }
    }
}