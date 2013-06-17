

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SYSTEKNIKCMSConnectionString"].ConnectionString;
    
    protected void lbLogin_Click(object sender, EventArgs e)
    {
        // string RESULT = "";
        string AUTH_URL = "";


        try
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "ValidateUser";
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", txtLoginName.Text);
            command.Parameters.AddWithValue("@Password", txtPassword.Text);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlDataReader Reader = command.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Session["UserID"] = this.txtLoginName.Text;
                    AUTH_URL = "DashBoard.aspx";
                    Response.Redirect(AUTH_URL, false);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "hwa", "jQueryErrorMessage('Your data is not available in Database, Please contact IT HelpDesk');", true);
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "hwa", "jQueryErrorMessage('" + ex.Message + "');", true);
        }

    }

}