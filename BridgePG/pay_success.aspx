<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pay_success.aspx.cs" Inherits="WebApplication2.pay_success" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta charset="utf-8">
<title>Payment Response :: Merchant .net</title>
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
					<li class="active">Payments</li>
				</ul>
			</div>
		</div>
	</div>
	</section>
	
	
	<!-- payment response section  -->

    	<section id="Section1">
	<section id="content">
	<div class="container">

        		<div class="row">
			
				<div class="col-md-6 col-lg-6 col-xl-6 col-sm-12 col-xs-12 bg-top">
					<h4>Transaction ID (CSC PG): <%=csc_txn %> </h4>
					<h3>Transaction ID:  <%=merchant_txn %></h3>
					<h3>Date:  <%=merchant_txn_date_time %></h3>
					<h3>Amount:  <%=TextBoxtxn_amount.Text %> </h3>
					<h3>Invoice: <%=TextBoxmerchant_receipt_no.Text %></h3>
				</div>
				<div class="col-md-6 col-lg-6 col-xl-6 col-sm-12 col-xs-12 bg-top">
					<h4>Product Details</h4>
					<p>
						<strong>Information</strong>, write a summary of transaction for VLE to see
					</p>					
					<div class="col-lg-12 ">
						<h4>Response from CSC Payment Gateway</h4>
						<pre class="prettyprint linenums">
							print the response string 
							Encrypted Values: <% = bridgeResponseMessage %>  
							<br>
							Decrypted Values:  <% = drcResponse %>
						</pre>
					</div>
                    </div>
	<hr>
			<div class="row">				
				<div class="col-md-5 col-lg-5 col-xl-5 col-sm-12 col-xs-12 bg">
					<h4>CSC PG Respponse</h4><hr>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>CSC Transaction:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">						
							
						 <asp:TextBox ID="TextBoxcsc_txn" runat="server" class="form-control"></asp:TextBox>
                        </div>
					</div>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Merchant Id:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">							
							
                            <asp:TextBox ID="TextBoxmerchant_id" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>CSC Id:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
							
                            <asp:TextBox ID="TextBoxcsc_id" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Merchant Transaction:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
							
                            <asp:TextBox ID="TextBoxmerchant_txn" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>	
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Merchant Transaction Date:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
							
                            <asp:TextBox ID="TextBoxmerchant_txn_date_time" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Product Id:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
							
                            <asp:TextBox ID="TextBoxproduct_id" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Transaction Amount:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
							
                            <asp:TextBox ID="TextBoxtxn_amount" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Amount Parameter:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
							
                            <asp:TextBox ID="TextBoxamount_parameter" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Transaction Mode:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
						
                            <asp:TextBox ID="TextBoxtxn_mode" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>	
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Transaction Type:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
							
                            <asp:TextBox ID="TextBoxtxn_type" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Merchant Receipt No:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
							
                            <asp:TextBox ID="TextBoxmerchant_receipt_no" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>						
					<div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>CSC Share Amount:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
						
                            <asp:TextBox ID="TextBoxcsc_share_amount" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>
                    <div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 col-xs-12 padding-btm">
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
							<label class="control-label"><strong>Transaction reference:</strong></label>
						</div>	
						<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">					
						
                            <asp:TextBox ID="TextBoxrefund_reference" runat="server" class="form-control"></asp:TextBox>
						</div>
					</div>		
				</div>
				<div class="col-md-2 col-lg-2 col-xl-2 col-sm-12 col-xs-12 bg">
					<h4>CSC PG Action</h4><hr>
					<div class="col-md-12 col-lg-12 col-xl-2 col-sm-12 col-xs-12 padding-btm">
						
                        <asp:Button ID="ButtonTransaction_enquiry" runat="server" Text="Transaction enquiry" OnClick="ButtonTransaction_enquiry_Click" class="btn btn-default" />
					</div>
					<div class="col-md-12 col-lg-12 col-xl-2 col-sm-12 col-xs-12 padding-btm">
						
                        <asp:Button ID="ButtonTransaction_Status" runat="server" Text="Transaction status" OnClick="ButtonTransaction_Status_Click" class="btn btn-default" />
					</div>					
					<div class="col-md-12 col-lg-12 col-xl-2 col-sm-12 col-xs-12 padding-btm">
						
                        <asp:Button ID="Buttonrefund_log" runat="server" Text="Refund request" OnClick="Buttonrefund_log_Click" class="btn btn-default" />
					</div>
					<div class="col-md-12 col-lg-12 col-xl-2 col-sm-12 col-xs-12 padding-btm">
						
                        <asp:Button ID="Buttonrefund_status" runat="server" Text="Refund status" OnClick="Buttonrefund_status_Click" class="btn btn-default" />
					</div>
					<div class="col-md-12 col-lg-12 col-xl-2 col-sm-12 col-xs-12 padding-btm">
						 <asp:Button ID="Buttonrecon_log" runat="server" Text="Recon request" OnClick="Buttonrecon_log_Click" class="btn btn-default" /> 
					</div>
				</div>
				<div class="col-md-5 col-lg-5 col-xl-5 col-sm-12 col-xs-12 bg">
					<h4>CSC PG Action Result</h4><hr>
				</div>
			</div>
                  
	</section>

	
	
	<!-- payment response status -->
	

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

	
</body>
   
    </div>
    </form>
</body>
</html>

