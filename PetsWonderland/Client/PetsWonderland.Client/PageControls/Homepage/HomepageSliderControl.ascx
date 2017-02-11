<%@ Control Language="C#"
            AutoEventWireup="true"
            CodeBehind="HomepageSliderControl.ascx.cs" 
            Inherits="PetsWonderland.Client.PageControls.Homepage.HomepageSliderControl" %>

<section id="homepage-slider">
    <div class="fullwidthbanner-container">
    <div class="fullscreenbanner">
        <ul>
            <li data-transition="cube" data-slotamount="1" >
                <img src="~/Images/Pages/Homepage/Slider/pets_01.jpg" runat="server" />
                      
                <div class="tp-caption tp-fade"
                     data-x="center"
                     data-hoffset="0"
                     data-y="center"
                     data-voffset="200"
                     data-speed="800"
                     data-start="500"
                     data-easing="Power3.easeInOut"
                     data-elementdelay="0.1"
                     data-endelementdelay="0.1"
                     data-endspeed="300"
                >
                    <img src="~/Images/Pages/Homepage/Slider/slider_t_bg_white.png" alt="" runat="server" data-ww="2550" data-hh="247" />
                </div>

                <div class="tp-caption sft"
                     data-x="center"
                     data-hoffset="0"
                     data-y="center"
                     data-voffset="133"
                     data-speed="800"
                     data-start="1200"
                     data-easing="Power3.easeInOut"
                     data-elementdelay="0.1"
                     data-endelementdelay="0.1"
                     data-endspeed="300"
                >
                    <img src="" alt=""  />
                    <h1 class="slide-title">PetsWonderland</h1>
                </div>

                <div class="tp-caption tp-fadet"
                     data-x="center"
                     data-hoffset="0"
                     data-y="center"
                     data-voffset="197"
                     data-speed="750"
                     data-start="1500"
                     data-easing="Power3.easeInOut"
                     data-elementdelay="0.1"
                     data-endelementdelay="0.1"
                     data-endspeed="300"
                >
                    <div  class="slide-middle-text"><p>Find the best boarding service for your pet</p></div>
                </div>

                <div class="tp-caption sfb"
                     data-x="center"
                     data-hoffset="0"
                     data-y="center"
                     data-voffset="264"
                     data-speed="800"
                     data-start="1900"
                     data-easing="Power3.easeInOut"
                     data-elementdelay="0.1"
                     data-endelementdelay="0.1"
                     data-endspeed="300"

                >       
                    <div class="browse-hotel prism-button">
                        <div class="prism-wrap">
                            <span>Want to accomodate your pet ?</span>
                            <span>Browse Hotels</span>
                        </div>                       
                    </div>       
                    <!--<div class="slide-bottom-text"><p>Try us</p></div>-->
                </div>
            </li>    
            <li data-transition="cube" data-slotamount="2" >
                <img src="~/Images/Pages/Homepage/Slider/pets_04.jpg" runat="server" />                
            </li>
            <li data-transition="cube" data-slotamount="3" >
                <img src="~/Images/Pages/Homepage/Slider/pets_03.jpg" runat="server" />                
            </li> 
        </ul>
    </div>
</div>
</section>
