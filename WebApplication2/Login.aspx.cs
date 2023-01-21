using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {

        public static int loggedInUserId = 0;
        public static string prefferedLanguage = "en";
        public static string userName = "";
        public static int translateCount = 0;
        public static int speechCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button clicked");

            string usernameInput = Request.Form["Username"];
            string passwordInput = Request.Form["Password"];

            Debug.WriteLine(usernameInput+ " " + passwordInput);

            string connectionString =
            "Server=tcp:team9-server.database.windows.net,1433;Initial Catalog=team9;Persist Security Info=False;User ID=sqladmin;Password=Team9Sql;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * from dbo.user_t where username = '" + usernameInput + "' and password = '" + passwordInput + "' ;";

            // Specify the parameter value.
            int paramValue = 5;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.

                bool isLoginSuccessful = false;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Debug.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);

                        if (reader[1].Equals(usernameInput) && reader[2].Equals(passwordInput))
                        {
                            isLoginSuccessful = true;
                            Debug.WriteLine("Login successful");
                            Debug.WriteLine(isLoginSuccessful);

                            loggedInUserId = (int) reader[0];
                            userName= reader[1].ToString();
                            prefferedLanguage = reader[3].ToString();
                            translateCount = (int) reader[4];
                            speechCount = (int) reader[5];
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                if(isLoginSuccessful)
                {
                    Response.Redirect("Default.aspx");
                } else
                {
                    lblError.Visible = true;
                    lblError.Text = "Login failed";
                }
            
            }
            
        }
    }
}