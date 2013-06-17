<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/siteadmin.master" AutoEventWireup="true" CodeFile="BannerDetails.aspx.cs" Inherits="Admin_BannerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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
  
            $("#form1").validate({

                rules: {

                    <%=txtTitle.UniqueID %>: {
                        required: true,
                        minlength: 2
                    },

                    <%=txtDescriptions.UniqueID %>: {
                        required: true,
                        minlength: 2
                    }
                
                },
                messages: {
                  
                },


                focusCleanup: false,

                highlight: function (label) {
                    $(label).closest('.control-group').removeClass('success').addClass('error');
                },
                success: function (label) {
                    label
                        .text('OK!').addClass('valid')
                        .closest('.control-group').addClass('success');
                },
                errorPlacement: function (error, element) {
                    error.appendTo(element.parents('.controls'));
                },
                messages: {

                },

                onsubmit: false
            });

            $('.validationGroup .causesValidation').click(Validate);

            $('.validationGroup :text').keydown(function (evt) {
                if (evt.keyCode == 13) {
                    var $nextInput = $(this).nextAll(':input:first');

                    if ($nextInput.is(':submit')) {
                        Validate(evt);
                    }
                    else {
                        evt.preventDefault();
                        $nextInput.focus();
                    }
                }
            });

        }
        //}); Hide due to Update panel

        function Validate(evt) {

            var $group = $(this).parents('.validationGroup');
            var isValid = true;

            $group.find(':input').each(function (i, item) {
                if (!$(item).valid())
                    isValid = false;
            });

            if (!isValid)
                evt.preventDefault();
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">

        <div class="container">

            <div id="page-title" class="clearfix">

                <ul class="breadcrumb">
                    <li>
                        <a href="DashBoard.aspx">Lookups</a> <span class="divider">/</span>
                    </li>
                    <li>
                        <a href="Banner.aspx">Banner</a> <span class="divider">/</span>
                    </li>
                    <li class="active">Banner Details</li>
                </ul>

            </div>
            <!-- /.page-title -->

            <div class="row">

                <div class="span8">


                    <div id="appendprepend" class="widget widget-form">

                        <div class="widget-header">
                            <h3>
                                <i class="icon-pencil"></i>
                                Minimum requirements				
                            </h3>
                        </div>
                        <!-- /widget-header -->

                        <div class="widget-content">

                            <div class="form-horizontal">

                                <fieldset class="validationGroup">


                                    <asp:HiddenField ID="hfEdit" runat="server" />
                                    <div class="control-group">
                                        <label class="control-label" for="txtTitle">Title :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtTitle" placeholder="Title Name" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <!-- /control-group -->

                                    <div class="control-group">
                                        <label class="control-label" for="txtDescriptions">Descriptions :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtDescriptions" TextMode="MultiLine" Rows="5" placeholder="Descriptions" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <!-- /control-group -->

                                    <div class="control-group">
                                        <label class="control-label" for="txtPackageValue">Display Order :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtDisplayOrder" placeholder="Display Order" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <!-- /control-group -->

                                    <div class="control-group">

                                        <label class="control-label" for="FUImage">Image :</label>
                                        <div class="controls">
                                            <asp:FileUpload ID="FUImage" runat="server" />
                                            &nbsp;
                                            <asp:HyperLink ID="hlImage" Target="_blank" runat="server"></asp:HyperLink>

                                            <p class="help-block">logo size up to 5 MB – preferable formats on .pdf and .eps</p>
                                        </div>
                                    </div>
                                    <!-- /control-group -->


                                    <div class="form-actions">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary causesValidation" Text="Save changes" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

                                    </div>

                                </fieldset>
                            </div>


                        </div>
                        <!-- /widget-content -->

                    </div>
                    <!-- /.widget -->

                </div>
                <!-- /span6 -->

            </div>
            <!-- /row -->

        </div>

        <!-- /.container -->

    </div>

    <!-- /#content -->
</asp:Content>

