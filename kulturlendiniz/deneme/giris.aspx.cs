using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace deneme
{
    public partial class giris2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
           

        }

        protected void Giris_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "Select * from web where email = @email and sifre = @sifre";
            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cmd.Parameters.AddWithValue("@email", username.Text);
            cmd.Parameters.AddWithValue("@sifre", password.Text);

            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session.Timeout = 300;
                Session.Add("nick", dr["nick"].ToString());
                Response.Redirect(Request.RawUrl);
            }
            else
            {

            }

            cnn.Close();
        }
    }
}