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
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam lobortis et quam
                nec volutpat. Nam aliquet at lectus id viverra. Suspendisse potenti. Ut dictum 
                imperdiet augue, a dictum mi sagittis sed. Duis ac ligula nunc. Nulla finibus 
                neque nunc. Cras eget nunc libero. Nam luctus lobortis aliquam. Pellentesque congue
                libero sit amet feugiat rhoncus. Aliquam vestibulum felis non vehicula lobortis.
                Morbi ipsum erat, tincidunt in scelerisque placerat, efficitur nec augue. 
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
