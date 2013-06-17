 

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BannerDetails : System.Web.UI.Page
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SYSTEKNIKCMSConnectionString"].ConnectionString;

    private void DisplayAlert(string message, string status)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "jQueryErrorMessage", "jQueryErrorMessage('" + message.Replace("'", @"\'") + "','" + status + "');", true);
    }

    private void fSetData(string BannerID)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SelectBannerWID";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@BannerID", BannerID);

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            SqlDataReader SQLReader;
            SQLReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            SQLReader.Read();
            hfEdit.Value = "Edit";

            txtTitle.Text = SQLReader["Title"].ToString();
            txtDescriptions.Text = SQLReader["Descriptions"].ToString();
            txtDisplayOrder.Text = SQLReader["DisplayOrder"].ToString();
            hlImage.NavigateUrl = "..\\images\\slider-thumbnails\\" + SQLReader["UploadImage"].ToString();
            hlImage.Text = SQLReader["UploadImage"].ToString();  

        }
        catch (Exception ex)
        {
            DisplayAlert(ex.Message, "error");
        }
        finally
        {
            connection.Close();
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request["BannerID"] != null)
            {
                fSetData(Request["BannerID"]);
            }

        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        SqlConnection connection = new SqlConnection(connectionString);
        try
        {

            if (hfEdit.Value == "Edit")
            { 
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UpdateBanner";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BannerID", Request["BannerID"].ToString());
                command.Parameters.AddWithValue("@Title", txtTitle.Text);
                command.Parameters.AddWithValue("@Descriptions", txtDescriptions.Text);
                command.Parameters.AddWithValue("@DisplayOrder", txtDisplayOrder.Text);
                string fn = "";
                if (FUImage.HasFile)
                { 
                     fn = System.IO.Path.GetFileName(FUImage.PostedFile.FileName);
                     string SaveLocation = Server.MapPath("..\\images\\slider-thumbnails\\") + "\\" + fn;
                    try
                    {
                        FUImage.PostedFile.SaveAs(SaveLocation);
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert(ex.Message, "error");
                    }
                    
                } 
               command.Parameters.AddWithValue("@UploadImage", fn);
                command.Parameters.AddWithValue("@ModifiedBy", Session["UserID"]);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.ExecuteNonQuery();

                Response.Redirect("Banner.aspx", false);

            }
            else
            {


                SqlCommand command = connection.CreateCommand();
                command.CommandText = "InsertBanner";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Title", txtTitle.Text);
                command.Parameters.AddWithValue("@Descriptions", txtDescriptions.Text);
                command.Parameters.AddWithValue("@DisplayOrder", txtDisplayOrder.Text);
                string fn = "";

                if (FUImage.HasFile)
                {
                    fn = System.IO.Path.GetFileName(FUImage.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("..\\images\\slider-thumbnails\\") + "\\" + fn;
                    try
                    {
                        FUImage.PostedFile.SaveAs(SaveLocation);
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert(ex.Message, "error");
                    }
                  
                } 
                command.Parameters.AddWithValue("@UploadImage", fn);
                command.Parameters.AddWithValue("@ModifiedBy", Session["UserID"]);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.ExecuteNonQuery();
                Response.Redirect("Banner.aspx", false);
            }


        }
        catch (Exception ex)
        {
            DisplayAlert(ex.Message, "error");

        }
        finally
        {
            connection.Close();

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Banner.aspx", false);
    }
}