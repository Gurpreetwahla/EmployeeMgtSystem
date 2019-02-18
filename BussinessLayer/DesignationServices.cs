using DataLayer;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DesignationServices
    {
        static DesignationRepository repository;
        static DesignationServices()
        {
            repository = new DesignationRepository();
        }
        public static Design Insert(Design obj)
        {
            return repository.Insert(obj);
        }
        public static List<Design> GetAll()
        {
            return repository.GetAll();
        }
        public static void Update(Design obj)
        {
            repository.Update(obj);
        }
        public static void Delete(int Id)
        {
            repository.Delete(Id);
        }
    }
}
