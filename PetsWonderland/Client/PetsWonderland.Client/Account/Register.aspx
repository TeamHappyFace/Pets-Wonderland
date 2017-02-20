<%@ Page Title="Register"
         Language="C#" 
         MasterPageFile="~/Site.Master"
         AutoEventWireup="true" 
         CodeBehind="Register.aspx.cs"
         Inherits="PetsWonderland.Client.Account.Register" %>

<asp:Content ContentPlaceHolderID="CustomStylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Pages/login.css") %>" rel="stylesheet" type="text/css" />      
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="registerForm" class="col-md-4">
        <div class="form-box">
	        <div class="form-top">
	            <div class="form-top-left">
	                <h3>Sign up now</h3>
	                <p>Fill in the form below to get instant access:</p>
	            </div>
	            <div class="form-top-right">
	                <i class="fa fa-pencil"></i>
	            </div>
	        </div>
            <div class="form-bottom">
               <%-- <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
                </p>--%>

                <div class="form-horizontal">       
		            <div class="form-group">
                        <div class="col-md-12">
				            <asp:DropDownList ID="UserType" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserType"
                                CssClass="text-danger" ErrorMessage="The username field is required." />
                        </div>
                    </div>
		            <div class="form-group">                        
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" placeholder="First Name..."/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                                CssClass="text-danger" ErrorMessage="The username field is required." />
                        </div>
                    </div>
		            <div class="form-group">                        
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="LastName" CssClass="form-control" placeholder="Last Name..."/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                                CssClass="text-danger" ErrorMessage="The username field is required." />
                        </div>
                    </div>
		            <div class="form-group">                        
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="Username" CssClass="form-control" placeholder="Usrname..." />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                CssClass="text-danger" ErrorMessage="The username field is required." />
                        </div>
                    </div>
                    <div class="form-group">                        
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Email..."/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
				            <asp:RegularExpressionValidator runat="server" ControlToValidate="Email" 
					            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
					            CssClass="text-danger" ErrorMessage="Invalid Email!" />
                        </div>
                    </div>
                    <div class="form-group">                        
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password..."/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">                        
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm Password..."/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default btn-register" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>    
</asp:Content>
