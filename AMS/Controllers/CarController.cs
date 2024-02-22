using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AMS.Controllers;

public class CarController : Controller
{
    private readonly ApplicationDbContext cardata;

    public CarController(ApplicationDbContext cardata)
    {
        this.cardata = cardata;
    }
    public async Task<IActionResult> CarList()
    {
        var car = await cardata.Set<Car>().AsNoTracking().ToListAsync();
        return View(car);
    }
    [HttpGet]

    public async Task<IActionResult> CreateEdit(int id)
    {
        if (id == 0)
        {
            return View(new Car());

        }
        else
        {
            var car = await cardata.Set<Car>().FindAsync(id);
            return View(car);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateEdit(int id, Car car)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                await cardata.Set<Car>().AddAsync(car);
                await cardata.SaveChangesAsync();

                TempData["Massage"] = "Succesfully Save Car Details";
                return Json(new { success = true, message = $"{car.Name}'s Data added Successfuly" });

            }
        }
        else
        {

            cardata.Set<Car>().Update(car);
            cardata.SaveChanges();
            TempData["Massage"] = "Succesfully Update Car Details";
            return Json(new { success = true, message = $"{car.Name}'s Data Update Successfuly" });
        }

        return Json(new { success = false, message = $"Data added Fail" });

    }

    public async Task<IActionResult> Delete(int id)
    {
        if (id != 0)
        {
            var data = await cardata.Set<Car>().FindAsync(id);
            if (data != null)
            {
                cardata.Set<Car>().Remove(data);
                await cardata.SaveChangesAsync();
                TempData["Massage"] = "Succesfully Delete Car Details";

            }

        }

        return RedirectToAction("CarList");

    }

    public async Task<IActionResult> Details(int id)
    {
        var car = await cardata.Set<Car>().FindAsync(id);
        return View(car);
    }

    public async Task<IActionResult> Search(string name)
    {
       var data=await cardata.Set<Car>().FindAsync(name);
        return View(data);
    }

    public async Task<IActionResult> GetResult(string name)
    {
        if (GetResult !=null)
        {
            await cardata.Set<Car>().FindAsync(name);
        }
        return View(GetResult);
    }
}