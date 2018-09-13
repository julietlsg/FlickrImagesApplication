<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FlickrImages._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center">
      <table cellpadding="5" cellspacing="0" style="border: 2px solid #0066CC; width: 60%;">
         <tr>
            <td style="width: 40%;">
               Search:
               <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
               <asp:Button ID="GoButton" runat="server" Text="GO" 
                  OnClick="GoButton_Click" />
            </td>
<%--             <td style="width: 40%;">
               Search:
               <asp:TextBox ID="txtLocationSearch" runat="server"></asp:TextBox>
               <asp:Button ID="btnSearchLoc" runat="server" Text="GO" 
                  OnClick="btnSearchLoc_Click" />
            </td>--%>
            <td style="vertical-align: top">
               <asp:Label ID="PhotoMetadata" runat="server"></asp:Label>
            </td>
         </tr>
         <tr>
            <td style="vertical-align: top">
               <asp:DataList ID="ThumbnailsList" runat="server" HorizontalAlign="Center" 
                  RepeatColumns="3" Width="100%" 
                  OnSelectedIndexChanged="ThumbnailsList_SelectedIndexChanged">
                  
                  <ItemStyle HorizontalAlign="Center" />
                  <ItemTemplate>

                     <asp:ImageButton ID="ThumbnailImage" runat="server" 
                        ImageUrl='<%# Eval("SquareThumbnailUrl") %>'
                        AlternateText='<%# Eval("Title") %>' 
                        ToolTip='<%# Eval("Title") %>' 
                        CommandName="Select">
                     </asp:ImageButton>

                     <asp:Literal ID="HiddenPhotoId" runat="server" 
                        Text='<%# Eval("PhotoId") %>' Visible="false" />
                     <asp:Literal ID="HiddenPhotoUrl" runat="server" 
                        Text='<%# Eval("MediumUrl") %>' Visible="false" />

                  </ItemTemplate>
               </asp:DataList>
            </td>
            <td style="vertical-align: top">
               <asp:Image ID="PreviewImage" runat="server" />
            </td>
         </tr>
         <tr>
            <td style="vertical-align: top">&nbsp;</td>
            <td style="vertical-align: top">
               <asp:Label ID="PhotoDescription" runat="server"></asp:Label>
            </td>
         </tr>
      </table>
</div>
</asp:Content>
