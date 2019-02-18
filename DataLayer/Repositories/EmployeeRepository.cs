using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EmployeeRepository
    {
        public Employee Insert(Employee obj)
        {
            using (EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities())
            {
                db.Employees.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }
        public List<Employee> GetAll()
        {
            using (EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities())
            {
                return db.Employees.ToList();
            }
        }
        public void Update(Employee obj)
        {
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            Employee employee = db.Employees.Single(u => u.Id == obj.Id);
            employee.Name = obj.Name;
            employee.Email = obj.Email;
            employee.Address = obj.Address;
            employee.Mobile = obj.Mobile;
            employee.DepttId = obj.DepttId;
            employee.DesigId = obj.DesigId;
            db.Employees.Attach(employee);
            db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            Employee employee = db.Employees.Single(u => u.Id == Id);
            db.Employees.Attach(employee);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
