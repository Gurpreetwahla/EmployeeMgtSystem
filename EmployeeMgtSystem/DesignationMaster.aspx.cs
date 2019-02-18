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
    public partial class DesignationMaster : System.Web.UI.Page
    {
        Design model = new Design();
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
            model.DesignationName = txtDesignationName.Text;

            DesignationServices.Insert(model);
            Clear();
            DataGvProperties();
            lblError.Text = "Record Inserted.";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Id = Convert.ToInt32(txtId.Text);

            model.DesignationName = txtDesignationName.Text;

            DesignationServices.Update(model);

            lblError.Text = "Designation Successfully Updated.";
            Clear();
            DataGvProperties();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            DepartmentServices.Delete(Id);
            lblError.Text = "Designation Deleted.";
            DataGvProperties();
            Clear();
        }
        void Clear()
        {
            txtDesignationName.Text = "";
            BtnDelete.Enabled = false;
        }
        void DataGvProperties()
        {
            GridViewDesignation.DataSource = DesignationServices.GetAll();
            GridViewDesignation.DataBind();
        }

        protected void GridViewDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridViewDesignation.SelectedRow.RowIndex != -1)
            {


                GridViewRow row = GridViewDesignation.SelectedRow;

                txtId.Text = row.Cells[1].Text;
                txtDesignationName.Text = row.Cells[2].Text;



                BtnDelete.Enabled = true;

            }
        }
    }
}