using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCrudOperetionWithDependecy.Entities;
using MvcCrudOperetionWithDependecy.Models;

namespace MvcCrudOperetionWithDependecy.Services
{
    public class Cudservices : Icrudservices
    {
        //Context
        private readonly carcontext _context;

        public Cudservices(carcontext carcontext)
        {
            _context = carcontext;
        }

        //Get
        public async Task<List<Car>> Get()
        {
            return await _context.cars.ToListAsync();
        }

        public List<Carmodel> ConvertToCarModels(List<Car> cars)
        {
            return cars.Select(car => new Carmodel
            {
                Id = car.Id,
                FirstName = car.FirstName,
                LastName = car.LastName,
                Email = car.Email,
                Phone = car.Phone,
                Brand = car.Brand,
                Model = car.Model,
                CarYear = car.CarYear
            }).ToList();
        }


        //Post
        public async Task<string> post(Carmodel car)
        {

            if (_context.cars.Any(c => c.Email == car.Email))
            {
                // Hata mesajı
                return "Bu e-posta adresi zaten kullanılıyor.";
            }
            var newCar = new Car
            {
                FirstName = car.FirstName,
                LastName = car.LastName,
                Email = car.Email,
                Phone = car.Phone,
                Brand = car.Brand,
                Model = car.Model,
                CarYear = car.CarYear
            };

            _context.cars.Add(newCar);
            await _context.SaveChangesAsync();


            return "";
        }
        

        //put
        public async Task<string> Put(int id, Carmodel car)
        {
            var existingCar = await _context.cars.FindAsync(id);

            if (existingCar == null)
            {
                return "Araba bulunamadı.";
            }


            existingCar.FirstName = car.FirstName;
            existingCar.LastName = car.LastName;
            existingCar.Email = car.Email;
            existingCar.Phone = car.Phone;
            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
            existingCar.CarYear = car.CarYear;

            try
            {
                await _context.SaveChangesAsync();
                return ""; // Başarılı
            }
            catch (DbUpdateConcurrencyException)
            {
                // Eş zamanlılık hatası
                return "Erorr";
            }
        }

        //delete
        public async Task<string> Delete(int id)
        {
            var existingCar = await _context.cars.FindAsync(id);

            if (existingCar == null)
            {
                return "Araba bulunamadı.";
            }

            _context.cars.Remove(existingCar);

            try
            {
                await _context.SaveChangesAsync();
                return ""; // Başarılı
            }
            catch (DbUpdateConcurrencyException)
            {
                // Eş zamanlılık hatası
                return "Erorr";
            }
        }
    }


    }


