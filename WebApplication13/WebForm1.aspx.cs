using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication13
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-7G0P5Q8; initial catalog=koko; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpGetData();
        }
        public void blank()
        {
            txtage.Text = "";
            txtname.Text = "";
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if(btninsert.Text=="Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into emp(name,age) values('" + txtname.Text + "','" + txtage.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
                else
                    {
                con.Open();
                SqlCommand cmd = new SqlCommand("update emp set name='"+txtname.Text+"', age='"+txtage.Text+"' where id='"+ ViewState["id"] + "'", con);
                cmd.ExecuteNonQuery();
                btninsert.Text = "Save";
                con.Close();
               
            }
            EmpGetData();
            blank();
        }
        public void EmpGetData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from emp", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            if(e.CommandName=="A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete  from emp where id='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                EmpGetData();
            }
            else
            {
                con.Open();
               
                    SqlCommand cmd = new SqlCommand("select *  from emp where id='" + e.CommandArgument + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                     
                     txtname.Text = dt.Rows[0]["name"].ToString();
                    txtage.Text = dt.Rows[0]["age"].ToString();
                    btninsert.Text = "Update";
                ViewState["id"] = e.CommandArgument;
                con.Close();

            }
        }

    }
}