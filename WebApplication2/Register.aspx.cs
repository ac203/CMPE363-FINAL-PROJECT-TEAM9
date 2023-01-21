using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usernameInput = Request.Form["Username"];
            string passwordInput = Request.Form["Password"];
            string prefLangInput = DropDownList1.SelectedValue;

            string connectionString = "Server=tcp:team9-server.database.windows.net,1433;Initial Catalog=team9;Persist Security Info=False;User ID=sqladmin;Password=Team9Sql;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            // Provide the query string with a parameter placeholder.
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO user_t (username, password, preferred_language,translate_count, speech_count) VALUES (@username, @password, @preferred_language, @translate_count, @speech_count)", connection))
                {
                    command.Parameters.AddWithValue("@username", usernameInput);
                    command.Parameters.AddWithValue("@password", passwordInput);
                    command.Parameters.AddWithValue("@preferred_language", prefLangInput);
                    command.Parameters.AddWithValue("@translate_count", 0);
                    command.Parameters.AddWithValue("@speech_count", 0);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            Response.Redirect("Login.aspx");

        }
    }
}