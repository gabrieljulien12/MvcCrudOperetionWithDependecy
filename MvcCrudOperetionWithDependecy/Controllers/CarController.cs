using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCrudOperetionWithDependecy.Entities;
using MvcCrudOperetionWithDependecy.Models;
using MvcCrudOperetionWithDependecy.Services;

namespace MvcCrudOperetionWithDependecy.Controllers
{
    public class CarController : Controller
    {
        private readonly carcontext _carcontext;

        private readonly Icrudservices _crudServices;

        public CarController(Icrudservices crudServices, carcontext carcontext)
        {
            _crudServices = crudServices;
            _carcontext = carcontext;
        }
        //Get
        public async Task<IActionResult> Index()
        {
            var cars = await _crudServices.Get();
            var carModels = _crudServices.ConvertToCarModels(cars);
            return View(carModels);
        }

        //Post
        public async Task<IActionResult> Create(Carmodel car)
        {
            if (ModelState.IsValid)
            {

                await _crudServices.post(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }



        //Put

        public async Task<IActionResult> Put(int id)
        {
            var car = await _carcontext.cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var carModel = new Carmodel
            {
                Id = car.Id,
                FirstName = car.FirstName,
                LastName = car.LastName,
                Email = car.Email,
                Phone = car.Phone,
                Brand = car.Brand,
                Model = car.Model,
                CarYear = car.CarYear
            };

            return View(carModel);
        }

        // POST: Car/Put/5
        [HttpPost]
        public async Task<IActionResult> Put(int id, Carmodel car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _crudServices.Put(id, car);
                if (string.IsNullOrEmpty(result))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result);
                    return View(car);
                }
            }

            return View(car);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _crudServices.Delete(id);
            if (string.IsNullOrEmpty(result))
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Hata durumunda uygun işlem yapılabilir, örneğin hata mesajını göstermek
                ModelState.AddModelError("", result);
                return View();
            }
        }

    }
}





