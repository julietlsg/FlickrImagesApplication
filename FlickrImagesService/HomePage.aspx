<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FlickrImagesService.HomePage" %>

<link href="Content/bootstrap.css" rel="stylesheet" />
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<link href="Content/Site.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 181px;
        }
        .auto-style2 {
            width: 68%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <asp:Label ID="lblErrors" class="label label-info" runat="server"></asp:Label>
          &nbsp;</div>
        <div style="text-align: inherit">
            <table cellspacing="0" cellpadding="0" style="border: 4px solid #0066CC; " class="auto-style2">
                <tr>
                    <td style="width: 40%;">Search:
               <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
                        <asp:Button ID="GoButton" runat="server" Text="GO"
                            OnClick="GoButton_Click" />
                    </td>
                    <td style="vertical-align: bottom" class="auto-style1">
          <a class="btn btn-link pull-right" href="SavedImages.aspx" style="height: 35px">Saved Images</a></td>
                </tr>
                <tr>
                    <td style="vertical-align: bottom">
                        <asp:DataList ID="ThumbnailsList" runat="server" HorizontalAlign="Justify"
                            RepeatColumns="5" Width="80px"
                            OnSelectedIndexChanged="ThumbnailsList_SelectedIndexChanged">

                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>

                                <asp:ImageButton ID="ThumbnailImage" runat="server"
                                    ImageUrl='<%# Eval("SquareThumbnailUrl") %>'
                                    AlternateText='<%# Eval("Title") %>'
                                    ToolTip='<%# Eval("Title") %>'
                                    CommandName="Select"></asp:ImageButton>

                                <asp:Literal ID="HiddenPhotoId" runat="server"
                                    Text='<%# Eval("PhotoId") %>' Visible="false" />
                                <asp:Literal ID="HiddenPhotoUrl" runat="server"
                                    Text='<%# Eval("MediumUrl") %>' Visible="false" />

                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td style="vertical-align: central" class="auto-style1">
                        <asp:Image ID="PreviewImage" runat="server" Width="440px" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">&nbsp;</td>
                    <td style="vertical-align: top" class="auto-style1">
                        <asp:Label ID="PhotoDescription" runat="server"></asp:Label>
                        <asp:Label ID="PhotoMetadata" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
