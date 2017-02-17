<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="QuickContactControl.ascx.cs" 
    Inherits="PetsWonderland.Client.PageControls.Homepage.QuickContactControl" %>

<div id="quick-contact">
    <a class="quick-contact-btn" href="#">
        <i class="fa fa-envelope fa-2x"></i>
    </a>
    <div id="quick-contact-form">
        <h4>CONTACT US</h4>
        <p>If you have any questions you can send us an email and we will get back to you as soon as possible.</p>
        <form method="post">
            <div class="form-group">
                <input type="text" required="" name="f_names" class="form-control" placeholder="Your Name"/>
            </div>
            <div class="form-group">
                <input type="email" required="" name="f_email" class="form-control" placeholder="Your Email" />
            </div>
            <div class="form-group">
                <textarea name="f_messag" class="form-control" placeholder="Your Message"></textarea>    
            </div>
            <button class="btn btn-default pull-right" type="submit">Send</button>
        </form>
    </div>
</div>