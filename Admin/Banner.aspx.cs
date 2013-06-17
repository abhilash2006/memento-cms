
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Banner : System.Web.UI.Page
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SYSTEKNIKCMSConnectionString"].ConnectionString;

    public static string EncodeJsString(string s)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("\"");
        foreach (char c in s)
        {
            switch (c)
            {
                case '\"':
                    sb.Append("\\\"");
                    break;
                case '\\':
                    sb.Append("\\\\");
                    break;
                case '\b':
                    sb.Append("\\b");
                    break;
                case '\f':
                    sb.Append("\\f");
                    break;
                case '\n':
                    sb.Append("\\n");
                    break;
                case '\r':
                    sb.Append("\\r");
                    break;
                case '\t':
                    sb.Append("\\t");
                    break;
                case '\'':
                    sb.Append(" ");
                    break;
                default:
                    int i = (int)c;
                    if (i < 32 || i > 127)
                    {
                        sb.AppendFormat("\\u{0:X04}", i);
                    }
                    else
                    {
                        sb.Append(c);
                    }
                    break;
            }
        }
        sb.Append("\"");

        return sb.ToString();
    }

    private void DisplayAlert(string message, string status)
    {
        message = EncodeJsString(message);

        ScriptManager.RegisterStartupScript(Page, this.GetType(), "jQueryErrorMessage", "jQueryErrorMessage('" + message + "','" + status + "');", true);
    }

    private void fSetData()
    {

        SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SelectBanner";
            command.CommandType = CommandType.StoredProcedure;

            DataSet dSet = new DataSet();
            SqlDataAdapter sqlAdapter;
            sqlAdapter = new SqlDataAdapter();

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            sqlAdapter.SelectCommand = command;
            sqlAdapter.Fill(dSet);

            rptPackages.DataSource = dSet;
            rptPackages.DataBind();

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

    private void fDelete(string BannerID)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DeleteBanner";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@BannerID", BannerID);
            command.Parameters.AddWithValue("@UserID", Session["UserID"]);

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            command.ExecuteNonQuery();

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
        Session["UserID"] = "athomas";
        if (!Page.IsPostBack)
        {

            if (Session["UserID"] != null)
            {

                fSetData();
            }
            else
            {
                Response.Redirect("signout.aspx", false);
            }

        }
    }

    protected void rptBanner_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("BannerDetails.aspx?BannerID=" + e.CommandArgument.ToString(), false);
        }
        else if (e.CommandName == "Delete")
        {
            fDelete(e.CommandArgument.ToString());
            fSetData();
        } 
        else if (e.CommandName == "ActiveInActive")
        {

            RepeaterItem _Item = e.Item;
            CheckBox _CheckBox = (CheckBox)_Item.FindControl("cbxIsActive");
            
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "InActiveBanner";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BannerID", e.CommandArgument.ToString());
                command.Parameters.AddWithValue("@ModifiedBy", Session["UserID"]);

                if (_CheckBox.Checked == true)
                {
                    command.Parameters.AddWithValue("@IsActive", "0");

                }
                else
                {
                    command.Parameters.AddWithValue("@IsActive", "1");

                }

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                DisplayAlert(ex.Message, "error");
            }
            finally
            {
                connection.Close();
            }

            fSetData(); 
        } 
    }

    protected void hlAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("BannerDetails.aspx");
    }
}