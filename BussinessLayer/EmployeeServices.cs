using DataLayer;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class EmployeeServices
    {
        static EmployeeRepository repository;
        static EmployeeServices()
        {
            repository = new EmployeeRepository();
        }
        public static Employee Insert(Employee obj)
        {
            return repository.Insert(obj);
        }
        public static List<Employee> GetAll()
        {
            return repository.GetAll();
        }
        public static void Update(Employee obj)
        {
            repository.Update(obj);
        }
        public static void Delete(int Id)
        {
            repository.Delete(Id);
        }
    }
}
