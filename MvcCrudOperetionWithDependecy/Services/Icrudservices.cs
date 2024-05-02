using Microsoft.AspNetCore.Mvc;
using MvcCrudOperetionWithDependecy.Entities;
using MvcCrudOperetionWithDependecy.Models;
using System.Security.Cryptography.X509Certificates;

namespace MvcCrudOperetionWithDependecy.Services
{
    public interface Icrudservices
    {
        Task<List<Car>> Get();
        
        List<Carmodel> ConvertToCarModels(List<Car> cars);

        Task<string>post(Carmodel car);
        Task<string> Put(int id, Carmodel car);
        Task<string> Delete(int id);
    }
}
