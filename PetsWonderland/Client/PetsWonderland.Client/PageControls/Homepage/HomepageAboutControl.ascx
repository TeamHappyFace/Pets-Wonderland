<%@ Control Language="C#" 
            AutoEventWireup="true" 
            CodeBehind="HomepageAboutControl.ascx.cs"
            Inherits="PetsWonderland.Client.PageControls.Homepage.HomepageAboutControl" %>

<section id="about" class="hp-about generic-section container">
    <div class="section-title">
        <h2>Services</h2>
    </div>
    <div class="section-content">
        <div class="description">
            <p>
				We understand that when you get home from work everyday, you are exhausted and just want to kick back and relax before bed. 
				However, if you have a dog that sat at home all day cooped up and waiting for you to return, you can’t, because your dog needs a walk and some attention and play. 
				With that in mind, we founded hotels for you and your pet to each lead happy and healthy lives together, so come and open a membership with us and experience all
				the wonders for your dog that we have to offer.
            </p>
        </div>
        <div class="services-list">
            <div class="col-sm-12 col-md-6">
                <h3>For regular users</h3>
                <div class="row">
                    <ul>
                        <li class="col-sm-6">
                            <a href="#">
                                <img src="~/Images/Pages/Homepage/About/daycare.png" runat="server"/>
                                <span>Daycare</span>
                            </a>
                        </li>
                        <li class="col-sm-6">
                            <a href="#">
                                <img src="~/Images/Pages/Homepage/About/boarding.png" runat="server"/>
                                <span>Boarding</span>
                            </a>
                        </li>               
                    </ul>
                </div>                
            </div>
            <div class="col-sm-12 col-md-6">
                <h3>For hotel owners</h3>
                <div class="row">
                    <ul>
                        <li class="col-sm-6">
                            <a href="#">
                                <img src="~/Images/Pages/Homepage/About/management.png" runat="server"/>
                                <span>Management</span>
                            </a>
                        </li>
                        <li class="col-sm-6">
                            <a href="#">
                                <img src="~/Images/Pages/Homepage/About/organization.png" runat="server"/>
                                <span>Organization</span>
                            </a>
                        </li>                 
                    </ul>
                </div>                
            </div>
        </div>
    </div>
</section>
