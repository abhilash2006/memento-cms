using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_siteadmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        //Session["UserID"] = "athomas";


        if (Session["UserID"] == null)
        {
            Response.Redirect("signout.aspx");
        }
        else
        {
            lblUserName.Text = Session["UserID"].ToString();
        }
        // Me.lblCount.Text = Session["MessageCount"]

        if (!Page.IsPostBack)
        {
            try
            {
                this.dsrcSelectAccessibleMenus.SelectParameters["UserID"].DefaultValue = Session["UserID"].ToString();
                this.dsrcSelectAccessibleMenus.SelectParameters["MenuApp"].DefaultValue = "CMS";
                this.rptMainMenu.DataBind();

            }
            catch (Exception )
            {
                // Me.lblUser.Text = ex.ToString
            }
        }
    }

    private DataTable getDataTableforSubMenu(string _MenuParent)
    {
        SqlConnection _SQLConnection = new SqlConnection();
        _SQLConnection.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SYSTEKNIKCMSConnectionString"].ConnectionString;

        SqlCommand _SQLCommand = new SqlCommand();
        {
            _SQLCommand.Connection = _SQLConnection;
            _SQLCommand.CommandType = CommandType.StoredProcedure;
            _SQLCommand.CommandText = "SelectSubMenus";
            _SQLCommand.Parameters.Add(new SqlParameter("@MenuParent", _MenuParent));
            _SQLCommand.Parameters.Add(new SqlParameter("@UserID",Session["UserID"].ToString()));
        }

        DataTable _DataTable = new DataTable();
        SqlDataAdapter _SQLAdapter = new SqlDataAdapter();

        _SQLAdapter.SelectCommand = _SQLCommand;
        _SQLAdapter.Fill(_DataTable);

        return _DataTable;
    }

    protected void rptMainMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptSubMenu = e.Item.FindControl("rptSubMenu") as Repeater;
            string _MenuParent = DataBinder.Eval(e.Item.DataItem, "MenuName").ToString();

            if ((_MenuParent.ToString() != null))
            {
                DataTable _DataTable = getDataTableforSubMenu(_MenuParent);
                if (_DataTable.Rows.Count > 0)
                {
                    rptSubMenu.DataSource = _DataTable;
                    rptSubMenu.DataBind();
                }
            }
        }

    } 
}
