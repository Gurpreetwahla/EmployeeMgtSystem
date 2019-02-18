using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class DepartmentRepository
    {
        public Department Insert(Department obj)
        {
            using (EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities())
            {
                db.Departments.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }
        public List<Department> GetAll()
        {
            using (EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities())
            {
                return db.Departments.ToList();
            }
        }
        public void Update(Department obj)
        {
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            Department department = db.Departments.Single(u => u.Id == obj.Id);
            department.DepttName = obj.DepttName;
            
            db.Departments.Attach(department);
            db.Entry(department).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            Department department = db.Departments.Single(u => u.Id == Id);
            db.Departments.Attach(department);
            db.Departments.Remove(department);
            db.SaveChanges();
        }
    }
}
