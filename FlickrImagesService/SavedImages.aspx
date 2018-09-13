<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SavedImages.aspx.cs" Inherits="FlickrImagesService.SavedImages" %>

<link href="Content/bootstrap.css" rel="stylesheet" />
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<link href="Content/Site.css" rel="stylesheet" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Saved Images</title>
    <style type="text/css">
        .auto-style1 {
            width: 418px;
        }
        .auto-style2 {
            width: 650px;
            margin-left: 91.66666666666666%;
        }
        .auto-style3 {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <table>
<tr>
                    <td class="auto-style1" >Search:

               <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
               <asp:Button ID="searchLoc" runat="server" Text="GO" OnClick="searchLoc_Click" />
                    </td>
                </tr>
                </table>
            </div>
            <table  >
                
                <tr>
                    <td style="border-style: solid; border-width: inherit; border-color: #003366;" class="auto-style2" colspan="2">
                        <asp:DataList ID="ThumbnailsList" runat="server" HorizontalAlign="Center"
                            RepeatColumns="4" BorderStyle="Solid" CssClass="auto-style3" Height="355px" Width="648px" >

                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <img src="<%# Eval("ImageData") %>" height="300" width="300" />
                                        </td>

                                    </tr>
                                </table>

                            </ItemTemplate>
                        </asp:DataList>
                    </td>

                </tr>
                <tr>
                    <td style="border-style: solid; border-width: inherit; border-color: #003366;" class="auto-style2" colspan="2">&nbsp;</td>
                    <td style="vertical-align: top">
                        <asp:Label ID="PhotoMetadata" runat="server"></asp:Label>
                        <asp:Label ID="PhotoDescription" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblErrors" class="label label-info" runat="server" Visible="false"></asp:Label>

        </div>
    </form>
</body>
</html>
