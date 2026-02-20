using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPlanillaUCENM.Models;
using SistemaPlanillaUCENM.Data; // <-- ASEGÚRATE DE TENER ESTA LÍNEA

namespace SistemaPlanillaUCENM.Controllers
{
    public class PlanillaController : Controller
    {
        // CAMBIO 1: Debe ser de tipo ApplicationDbContext, no 'object'
        private readonly ApplicationDbContext _context;

        // CAMBIO 2: Agregar el Constructor (esto conecta la base de datos)
        public PlanillaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Esta es la pantalla del formulario
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Calcular(Empleado emp)
        {
            // 1. Cálculo Base
            emp.SalarioBruto = emp.HorasTrabajadas * emp.PagoPorHora;

            // 2. Lógica de Impuestos
            decimal tasa = (emp.SalarioBruto > 15000) ? 0.12m : 0.08m;
            emp.Impuesto = emp.SalarioBruto * tasa;
            emp.SalarioNeto = emp.SalarioBruto - emp.Impuesto;

            // 3. Clasificación
            if (emp.SalarioNeto > 25000) emp.Clasificacion = "Nivel Alto";
            else if (emp.SalarioNeto >= 15000) emp.Clasificacion = "Nivel Medio";
            else emp.Clasificacion = "Nivel Básico";

            // CAMBIO 3: Guardar en la base de datos antes de mostrar resultados
            _context.Empleados.Add(emp);
            _context.SaveChanges();

            // 4. Redirigir a la vista de resultados
            return View("Resultado", emp);
        }

        public IActionResult Historial()
        {
            // Ahora _context ya sabe qué es Empleados porque ya no es un 'object'
            var lista = _context.Empleados.ToList();
            return View(lista);
        }
    }
}