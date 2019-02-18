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
    public partial class DepartmentMaster : System.Web.UI.Page
    {
        Department model = new Department();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                DataGvProperties();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.DepttName = txtDepttName.Text;
         
            DepartmentServices.Insert(model);
            Clear();
            DataGvProperties();
            lblError.Text = "Record Inserted.";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Id = Convert.ToInt32(txtId.Text);

            model.DepttName = txtDepttName.Text;
            
            DepartmentServices.Update(model);

            lblError.Text = "Department Successfully Updated.";
            Clear();
            DataGvProperties();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            DepartmentServices.Delete(Id);
            lblError.Text = "Department Deleted.";
            DataGvProperties();
            Clear();
        }
        void Clear()
        {
            txtDepttName.Text = "";
            BtnDelete.Enabled = false;
        }
        void DataGvProperties()
        {
            GridViewDeptt.DataSource = DepartmentServices.GetAll();
            GridViewDeptt.DataBind();
        }

        protected void GridViewDeptt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridViewDeptt.SelectedRow.RowIndex != -1)
            {


                GridViewRow row = GridViewDeptt.SelectedRow;

                txtId.Text = row.Cells[1].Text;
                txtDepttName.Text = row.Cells[2].Text;
                


                BtnDelete.Enabled = true;

            }
        }
    }
}