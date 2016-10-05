<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="WebApplication2.shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
<title>Shop :: Merchant .net</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<meta name="description" content="Bootstrap template for Sample Merchant Application" />
<meta name="author" content="Abhishek Ranjan" />
<!-- css -->
<link href="css/bootstrap.min.css" rel="stylesheet" />
<link href="css/style.css" rel="stylesheet" />
	
<!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
<!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

<div id="wrapper">
	<!-- start header -->
	<header>
						
        <div class="navbar navbar-default navbar-static-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="<% =ConfigurationManager.AppSettings["indexlink"] %>"><img src="img/logo.png" alt="" width="48" height="48" /> Merchant <span class="highlight">.net</span></a>
                </div>
                <div class="navbar-collapse collapse ">
                   <ul class="nav navbar-nav">
                        <li><a href="<% =ConfigurationManager.AppSettings["indexlink"]     %>">Home</a></li>
                      
                 
                       
                         <li><a href="<% =ConfigurationManager.AppSettings["shoplink"]     %>">Shop</a></li>
                      
                
                       
                         <li> <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton></li>
                 
                        
              

                    </ul>
                </div>
            </div>
        </div>
	</header>
	<!-- end header -->


	<section id="inner-headline">
	<div class="container">
		<div class="row">
			<div class="col-lg-12">
				<ul class="breadcrumb">
					<li><a href="<% =ConfigurationManager.AppSettings["indexlink"]     %>">Home</a><i class="icon-angle-right"></i></li>
					<li class="active">Shop</li>
				</ul>
			</div>
		</div>
	</div>
	</section>
	<section id="content">
	<div class="container">
		<div class="row">
			<div class="col-lg-12">
				<h4>Example with <strong>3 Products</strong></h4>
			</div>
			<div class="col-lg-4">
				<div class="pricing-box-alt">
					<div class="pricing-heading">
						<h3>.net <strong>Basic</strong></h3>
					</div>
					<div class="pricing-terms">
						<h6> INR 150.00 </h6>
					</div>
					<div class="pricing-content">
						<ul>
							<li><i class="icon-ok"></i> 1 applications</li>
							<li><i class="icon-ok"></i> 24x7 learning</li>
							<li><i class="icon-ok"></i> No hidden fees</li>
							<li><i class="icon-ok"></i> Free 30-days trial</li>
							<li><i class="icon-ok"></i> Stop anytime easily</li>
						</ul>
					</div>
                     <% if ((string)Session["logedin"] == "true")
                        { %>   
					<div class="pricing-action">
						
                        <asp:Button ID="Button2" class="btn btn-info" runat="server" Text="Buy" OnClick="Button2_Click" />
					</div>
                             <% } %>
				</div>
			</div>
			<div class="col-lg-4">
				<div class="pricing-box-alt special">
					<div class="pricing-heading">
						<h3>.net <strong>Intermediate</strong></h3>
					</div>
					<div class="pricing-terms">
						<h6>INR 100.00 / Month</h6>
					</div>
					<div class="pricing-content">
						<ul>
							<li><i class="icon-ok"></i> 10 applications</li>
							<li><i class="icon-ok"></i> 24x7 learning</li>
							<li><i class="icon-ok"></i> No hidden fees</li>
							<li><i class="icon-ok"></i> Free 30-days trial</li>
							<li><i class="icon-ok"></i> Stop anytime easily</li>
						</ul>
					</div>
                          <% if ((string)Session["logedin"] == "true")
                        { %>   
					<div class="pricing-action">
                        <asp:Button ID="Button3" class="btn btn-info" runat="server" Text="Buy" OnClick="Button3_Click" />
					</div>
                       <% } %>

				</div>
			</div>
			<div class="col-lg-4">
				<div class="pricing-box-alt">
					<div class="pricing-heading">
						<h3>.net <strong>Advanced</strong></h3>
					</div>
					<div class="pricing-terms">
						<h6>INR 50.00 / Month</h6>
					</div>
					<div class="pricing-content">
						<ul>
							<li><i class="icon-ok"></i> 100 applications</li>
							<li><i class="icon-ok"></i> 24x7 support available</li>
							<li><i class="icon-ok"></i> No hidden fees</li>
							<li><i class="icon-ok"></i> Free 30-days trial</li>
							<li><i class="icon-ok"></i> Stop anytime easily</li>
						</ul>
					</div>
                       <% if ((string)Session["logedin"] == "true")
                        { %>   
					<div class="pricing-action">
					
                        
                        <asp:Button ID="Button1" class="btn btn-info"  runat="server" Text="Buy" OnClick="Button1_Click" />
					</div>
                             <% } %>
				</div>
			</div>
		</div>
	</div>
	</section>

	<footer>
	<div class="container">
		<div class="row">
			<div class="col-sm-4 col-lg-4">
				<div class="widget">
					<h4>Get in touch</h4>
						<i class="icon-phone"></i> 011-4975 4975 <br>
						<i class="icon-envelope-alt"></i> support@csccloud.in
					</p>
				</div>
			</div>
			<div class="col-sm-4 col-lg-4">
				<div class="widget">
					<h4>Support</h4>
					<ul class="link-list">
						<li><a href="#">Developer</a></li>
						<li><a href="#">Knowledgebase</a></li>
					</ul>
				</div>
				
			</div>
			<div class="col-sm-4 col-lg-4">
				<div class="widget">
					<h4>More</h4>
					<ul class="link-list">
						<li><a href="#">CSC E-Governance</a></li>
						<li><a href="#">Digital India</a></li>
					</ul>
				</div>
			</div>
			
		</div>
	</div>
	<div id="sub-footer">
		<div class="container">
			<div class="row">
				<div class="col-lg-6">
					<div class="copyright">
						<p>
							<span>&copy; 2016 CSC E-Governance. All right reserved. | <a href="http://csc.gov.in/">CSC Website</a>
                            
						
						</p>
					</div>
				</div>
				
			</div>
		</div>
	</div>
	</footer>
</div>

<script src="js/jquery.min.js"></script>
<script src="js/modernizr.custom.js"></script>
<script src="js/jquery.easing.1.3.js"></script>
<script src="js/bootstrap.min.js"></script>
    </div>
    </form>
</body>
</html>
