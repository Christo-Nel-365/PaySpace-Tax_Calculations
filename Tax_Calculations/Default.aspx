<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tax_Calculations._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="row">
        <div >
            <h2>Tax Calculator</h2>
             <div>
                 <asp:Label Text="Enter Postal Code" runat="server" />
                <asp:TextBox ID="txtPostCode" runat="server" AutoPostBack="true" />            
                <asp:Label Text="Enter Annual Salary" runat="server" />
                <asp:TextBox ID="txtSalary" runat="server" AutoPostBack="true" />
            </div>
            <br />
            <asp:Label Text="" runat="server" ID="txtResult" ForeColor="Red"/>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
        
        
    </div>

</asp:Content>
