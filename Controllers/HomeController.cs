using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Data;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Controllers;

public class HomeController : Controller
{
    private readonly AppDBContext _appDBContext;

    public HomeController(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Reg_Gastos(Gasto gasto)
    {
        if (ModelState.IsValid)
        {
            await _appDBContext.Gastos.AddAsync(gasto);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction("Gastos");
        }
        return View(gasto);
    }

    [HttpPost]
    public async Task<IActionResult> Add_Ingresos(Ingreso ingreso)
    {
        if (ModelState.IsValid)
        {
            await _appDBContext.Ingresos.AddAsync(ingreso);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction("Ingresos");
        }
        return View(ingreso);
    }

    public async Task<IActionResult> Gastos()
    {
        List<Gasto> Lista_Gastos = await _appDBContext.Gastos.ToListAsync();
        return View(Lista_Gastos);
    }

    public async Task<IActionResult> Ingresos()
    {
        List<Ingreso> Lista_Ingresos = await _appDBContext.Ingresos.ToListAsync();
        return View(Lista_Ingresos);
    }

    public IActionResult Reg_Ingresos()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
