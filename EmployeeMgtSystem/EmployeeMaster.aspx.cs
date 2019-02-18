using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using BussinessLayer;

namespace EmployeeMgtSystem
{
    public partial class EmployeeMaster : System.Web.UI.Page
    {
        Employee model = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    dropdownlistData();
                    dropdownlistDataForDesign();
                    DataGvProperties();
                }


            }
            else
            {

            }
            DataGvProperties();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Name = txtEmployeeName.Text;
            model.Email = txtEmail.Text;
            model.Mobile = txtMobile.Text;
            model.Address = txtAddress.Text;
            model.DepttId = Convert.ToInt32(ddDepartment.SelectedItem.Value);
            model.DesigId = Convert.ToInt32(ddDesignation.SelectedItem.Value);
            model.Status = Convert.ToByte(ddStatus.SelectedItem.Value);

            EmployeeServices.Insert(model);
            lblError.Text = "Employee Successfully Added.";
            DataGvProperties();
            //Clear();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Id = Convert.ToInt32(txtId.Text);
            model.Name = txtEmployeeName.Text;
            model.Email = txtEmail.Text;
            model.Mobile = txtMobile.Text;
            model.Address = txtAddress.Text;
            model.DepttId = Convert.ToInt32(ddDepartment.SelectedItem.Value);
            model.DesigId = Convert.ToInt32(ddDesignation.SelectedItem.Value);
            model.Status = Convert.ToByte(ddStatus.SelectedItem.Value);

            EmployeeServices.Update(model);

            lblError.Text = "Employee Successfully Updated.";
            //Clear();
            DataGvProperties();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            EmployeeServices.Delete(Id);
            lblError.Text = "Employee Deleted.";
            DataGvProperties();
           // Clear();
        }
        void dropdownlistData()
        {
            //Teacher teacher = new Teacher();
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            ddDepartment.DataSource = db.Departments.ToList();

            ddDepartment.DataTextField = "DepttName";
            ddDepartment.DataValueField = "Id";
            ddDepartment.DataBind();
        }
        void dropdownlistDataForDesign()
        {
            //Teacher teacher = new Teacher();
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            ddDesignation.DataSource = db.Designs.ToList();

            ddDesignation.DataTextField = "DesignationName";
            ddDesignation.DataValueField = "Id";
            ddDesignation.DataBind();
        }
        void DataGvProperties()
        {
            EmployeeMgtSystemEntities db = new EmployeeMgtSystemEntities();
            var test1 = (from e in db.Employees
                         join d in db.Departments
                             on e.DepttId equals d.Id
                         join ds in db.Designs
                         on e.DesigId equals ds.Id
                         

                         select new
                         {
                             Id = e.Id,
                             Name = e.Name,
                             EmailId = e.Email,
                             mob = e.Mobile,
                             Add = e.Address,
                             DepttName = d.DepttName,
                             Designation = ds.DesignationName,
                             Status=e.Status,

                         }).ToList();
            //GridView1.DataSource = StudentServices.GetAll();
            GridView1.DataSource = test1;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow.RowIndex != -1)
            {



                GridViewRow row = GridView1.SelectedRow;

                txtId.Text = row.Cells[1].Text;
                txtEmployeeName.Text = row.Cells[2].Text;
                txtEmail.Text = row.Cells[3].Text;
                txtMobile.Text = row.Cells[4].Text;
                txtAddress.Text = row.Cells[5].Text;
                //ddDepartment.Items.Clear();
                //ddDepartment.Items.Add(GridView1.SelectedRow.Cells[6].Text);
                //ddDesignation.Items.Clear();
                //ddDesignation.Items.Add(GridView1.SelectedRow.Cells[7].Text);
                // ddCourse.Text = row.Cells[5].Text;
                // ddTeacher.Text = row.Cells[6].Text;

                BtnDelete.Enabled = true;

            }
        }
    }
}