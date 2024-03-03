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
    public partial class kayit3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKayit_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string sorgu = "Insert into web(nick,email,sifre) Values(@Nick,@Email,@Password)";
            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cnn.Open();
            try
            {
                cmd.Parameters.AddWithValue("@Nick", Nick.Text);
                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
                Nick.Text = "";
                Email.Text = "";
                Password.Text = "";
                lbl_kayit_sonuc.Text = "Başarıyla kayıt yapılmıştır.";
            }
            catch
            {
                lbl_kayit_sonuc.Text = "Kaydınız yapılamadı";
            }
        }
    }
}