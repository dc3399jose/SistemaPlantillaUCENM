using Microsoft.AspNetCore.Mvc;
using SistemaPlanillaUCENM.Data; // Importante
using SistemaPlanillaUCENM.Models;

namespace SistemaPlanillaUCENM.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inyectamos la base de datos
        public PrestamoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Cotizar(Prestamo p)
        {
            // --- 1. Tu Lógica de Cálculos (Mantenla igual) ---
            if (p.TipoCliente == "Nuevo") p.TasaInteres = 0.18m;
            else if (p.TipoCliente == "Frecuente") p.TasaInteres = 0.12m;
            else if (p.TipoCliente == "Preferencial") p.TasaInteres = 0.08m;

            p.InteresTotal = p.Monto * p.TasaInteres;
            p.TotalPagar = p.Monto + p.InteresTotal;
            p.CuotaMensual = p.TotalPagar / p.Meses;

            if (p.Monto > 200000) p.NivelRiesgo = "Alto";
            else if (p.Monto >= 100000) p.NivelRiesgo = "Medio";
            else p.NivelRiesgo = "Bajo";

            if (p.TipoCliente == "Preferencial")
            {
                if (p.NivelRiesgo == "Alto") p.NivelRiesgo = "Medio";
                else if (p.NivelRiesgo == "Medio") p.NivelRiesgo = "Bajo";
            }

            // --- 2. GUARDAR EN LA BASE DE DATOS ---
            _context.Prestamos.Add(p);
            _context.SaveChanges();

            return View("ResultadoPrestamo", p);
        }

        // Acción para ver el historial de préstamos
        public IActionResult Historial()
        {
            var lista = _context.Prestamos.ToList();
            return View(lista);
        }
    }
}