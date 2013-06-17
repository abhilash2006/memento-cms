<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/siteadmin.master" AutoEventWireup="true" CodeFile="Banner.aspx.cs" Inherits="Admin_Banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="js/plugins/datatables/DT_bootstrap.css" rel="stylesheet">
    <link href="js/plugins/responsive-tables/responsive-tables.css" rel="stylesheet">

    <script src="js/plugins/datatables/jquery.dataTables.js"></script>
    <script src="js/plugins/datatables/DT_bootstrap.js"></script>
    <script src="js/plugins/responsive-tables/responsive-tables.js"></script>

    <script type="text/javascript">
        function jQueryErrorMessage(e, terror) {
            $.msgAlert({
                type: terror,
                title: 'sysTEKNIK | Koinonia Shrajah',
                text: e
            });
        }
    </script>

    <script type="text/javascript">
        // $(document).ready(function() { //Update Panel added so document ready hided[abhi: http://encosia.com/document-ready-and-pageload-are-not-the-same/]

        //Sys.Application.add_init(function() { 
        function pageLoad() {

            $('#example').dataTable({
                sDom: "<'row'<'span6'l><'span6'f>r>t<'row'<'span6'i><'span6'p>>",
                sPaginationType: "bootstrap",
                oLanguage: {
                    "sLengthMenu": "_MENU_ records per page"
                }
            });


        }
        //}); Hide due to Update panel


    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div id="content">

                <div class="container">

                    <div id="page-title" class="clearfix">

                        <ul class="breadcrumb">
                            <li>
                                <a href="./">Lookups</a> <span class="divider">/</span>
                            </li>

                            <li class="active">Banner</li>
                        </ul>

                    </div>
                    <!-- /.page-title -->

                    <div class="row">

                        <div class="span12">

                            <div class="widget widget-table">

                                <div class="widget-header">
                                    <h3>
                                        <i class="icon-th-list"></i>
                                        Banner						
                                    </h3>

                                    <div class="widget-actions">
                                        <asp:HyperLink ID="hlAddNew" CssClass="btn btn-small btn-primary" runat="server" NavigateUrl="~/Admin/BannerDetails.aspx">Add New Package</asp:HyperLink>
                                        <asp:HyperLink ID="hlRefresh" CssClass="btn btn-small btn-primary" runat="server">Refresh</asp:HyperLink>


                                    </div>
                                    <!-- /.widget-actions -->

                                </div>
                                <!-- /widget-header -->

                                <div class="widget-content">

                                    <asp:Repeater ID="rptPackages" runat="server" OnItemCommand="rptBanner_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-bordered table-highlight" id="example">
                                                <thead>
                                                    <tr>
                                                        <th>Show</th>
                                                        <th>Delete</th>
                                                        <th>Banner ID</th>
                                                        <th>Title</th>
                                                         <th>Description</th>
                                                        <th>Image </th>
                                                         <th>Modified By</th> 
                                                        <th>Display Order</th>
                                                        <th>Is Active</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BannerID") %>'><img src="img/silk/page_white_go.png"  title="View" /></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BannerID") %>'><img src="img/silk/delete.png" alt="Delete" rel="tooltip" title="Delete this Position !" /></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBannerID" runat="server" Text='<%# Eval("BannerID")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title")%>'></asp:Label>
                                                </td>
                                               <td>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Descriptions")%>'></asp:Label>
                                                </td> 
                                                <td>
                                                    <asp:Label ID="lblImage" runat="server" Text='<%# Eval("UploadImage")%>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblModifiedBy" runat="server" Text='<%# Eval("ModifiedBy")%>'></asp:Label>
                                                </td> 
                                                <td>
                                                    <asp:Label ID="lblDisplayOrder" runat="server" Text='<%# Eval("DisplayOrder")%>'></asp:Label>
                                                </td>
                                                <td>

                                                    <asp:LinkButton ID="lnkActiveInactive" runat="server" CommandName="ActiveInActive"
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BannerID") %>'>
                                                        <%# Eval("IsActive").ToString() == "1" ? "<img src='img/silk/chekbox_on.png'  title='Click to Finalize'/>" : "<img src='img/silk/chekbox_off.png'    title='Click to not Finalized !'/>" %>
                                                    </asp:LinkButton>

                                                    <div style="display: none;">
                                                        <asp:CheckBox ID="cbxIsActive" runat="server" Checked='<%# Eval("IsActive").ToString() == "1" ? true : false %>' />
                                                    </div>

                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                    </table>
                                        </FooterTemplate>
                                    </asp:Repeater>


                                </div>
                                <!-- /widget-content -->

                            </div>
                            <!-- /widget -->

                        </div>
                        <!-- /.span6 -->

                    </div>
                    <!-- /row -->

                </div>

                <!-- /.container -->

            </div>
        </ContentTemplate>

    </asp:UpdatePanel>

    <!-- /#content -->
</asp:Content>


