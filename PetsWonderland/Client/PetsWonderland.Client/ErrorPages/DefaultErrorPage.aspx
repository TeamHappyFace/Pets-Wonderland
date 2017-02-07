<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultErrorPage.aspx.cs" Inherits="PetsWonderland.Client.ErrorPages.DefaultErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<div class="container">
			<div id="unfound_message">
				<h1>Oops! There seems to be a problem with that page.</h1>
				<h2>Either the URL was mistyped, never existed, or once existed but was mysteriously lost.</h2>
				<a href='../../Default.aspx'>
					<div>
						<img src="../../Images/default_page_cover.jpg"  />
					</div>
				</a>
			</div>
		</div>
    </form>
</body>
</html>
