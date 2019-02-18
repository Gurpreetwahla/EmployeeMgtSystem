using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class DesignationRepository
    {
        public Design Insert(Design obj)
        {
            using (EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities())
            {
                db.Designs.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }
        public List<Design> GetAll()
        {
            using (EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities())
            {
                return db.Designs.ToList();
            }
        }
        public void Update(Design obj)
        {
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            Design design = db.Designs.Single(u => u.Id == obj.Id);
            design.DesignationName = obj.DesignationName;
            
            db.Designs.Attach(design);
            db.Entry(design).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            Design design = db.Designs.Single(u => u.Id == Id);
            db.Designs.Attach(design);
            db.Designs.Remove(design);
            db.SaveChanges();
        }
    }
}
