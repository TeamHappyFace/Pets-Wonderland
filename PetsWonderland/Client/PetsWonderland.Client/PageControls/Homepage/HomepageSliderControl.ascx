<%@ Control Language="C#"
            AutoEventWireup="true"
            CodeBehind="HomepageSliderControl.ascx.cs" 
            Inherits="PetsWonderland.Client.PageControls.Homepage.HomepageSliderControl" %>

<section id="homepage-slider">
    <div class="tp-banner-container">
    <div class="tp-banner">
        <ul>
            <asp:Repeater ID="SliderRepeater" runat="server" ItemType="PetsWonderland.Business.Models.Pages.Slide">
                <ItemTemplate>                     
                    <li data-transition="fade"
                        data-slotamount="7" 
                        data-masterspeed="500" 
                        data-thumb="<%#: Item.Image.Remove(0,1) %>" 
                        data-saveperformance="on" 
                        data-title="Landing" >
                
                        <img runat="server" 
                                src="<%#: Item.Image %>" 
                                alt="slidebg1"
                                data-lazyload="<%#: Item.Image.Remove(0,1) %>" 
                                data-bgposition="center top" 
                                data-bgfit="cover"
                                data-bgrepeat="no-repeat" />
                      
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
                            <h1 class="slide-title"><%#: Eval("Title") %></h1>
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
                            <div  class="slide-middle-text"><p><%#: Eval("Caption") %></p></div>
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
                                 <a class="page-scroll" href="#hotels">
                                     <div class="prism-wrap">                                   
                                        <span>Want to accomodate your pet ?</span>
                                        <span>Browse Hotels</span>                                                                     
                                    </div>  
                                 </a>                     
                            </div>       
     
                        </div> 
                    </li>    
            </ItemTemplate>
        </asp:Repeater>          
        </ul>
    </div>
</div>
</section>
