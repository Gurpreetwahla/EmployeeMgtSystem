using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Repositories;

namespace BussinessLayer
{
    public class DepartmentServices
    {
        static DepartmentRepository repository;
        static DepartmentServices()
        {
            repository = new DepartmentRepository();
        }
        public static Department Insert(Department obj)
        {
            return repository.Insert(obj);
        }
        public static List<Department> GetAll()
        {
            return repository.GetAll();
        }
        public static void Update(Department obj)
        {
            repository.Update(obj);
        }
        public static void Delete(int Id)
        {
            repository.Delete(Id);
        }
    }
}
