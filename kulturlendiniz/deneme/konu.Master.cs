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
    public partial class konu : System.Web.UI.MasterPage
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            NewMethod1();
            NewMethod2();

            string id = Request.QueryString["konuID"];

            SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string sorgu = "Select * from basliklar inner join yorumlar on konuID=id where id = @ID";

            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            

            if (dr.Read())
            {
                image.ImageUrl = dr["resim"].ToString();
                Baslik.Text = dr["baslik"].ToString();
                Aciklama.Text = dr["aciklama"].ToString();
                Kategori.Text = dr["kategori"].ToString();
               

            }

            cnn.Close();

            object kullanici = Session["nick"];
            if (kullanici != null)
            {
                pnlGiris.Visible = false;
                pnlKullanici.Visible = true;
                
            }
            else
            {
                pnlKullanici.Visible = false;
                pnlGiris.Visible = true;
                

            }

        }
       

        protected void cikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnY_Click(object sender, EventArgs e)
        {
            object kullanici = Session["nick"];
            if (kullanici != null)
            {
                string id = Request.QueryString["konuID"];
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

                string sorgu = "Insert into yorumlar(yorum,konuID) Values(@yorum,(select id from basliklar where id=@ID))";
                SqlCommand cmd = new SqlCommand(sorgu, cnn);
                cmd.Parameters.AddWithValue("@ID", id);
                cnn.Open();
                cmd.Parameters.AddWithValue("@yorum", yorum.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();

                yorum.Text = "";
                lbl_yorum.Text = "yorumunuz eklendi";
            }
            else
            {
                yorum.Text = "";
                lbl_yorum.Text = "giriş yapınız";

            }
        }
        private void NewMethod2()
        {
            string id = Request.QueryString["konuID"];

            SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string sorgu = "Select yorumlar=yorum from yorumlar inner join basliklar on konuID=id where id = @ID";

            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            yorumlar.DataSource = dr;
            yorumlar.DataBind();
            cnn.Close();
        }

        private void NewMethod1()
        {
            SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string sorgu = "select top(5) id,baslik, y_sayisi=Count(yorumID) From yorumlar inner join basliklar on konuID=id Group by baslik,id order by y_sayisi desc ";

            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            popüler.DataSource = dr;
            popüler.DataBind();
            cnn.Close();
        }

    }
}

