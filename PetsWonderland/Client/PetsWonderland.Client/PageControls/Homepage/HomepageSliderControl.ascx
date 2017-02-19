<%@ Control Language="C#"
            AutoEventWireup="true"
            CodeBehind="HomepageSliderControl.ascx.cs" 
            Inherits="PetsWonderland.Client.PageControls.Homepage.HomepageSliderControl" %>

<%--<div>
   
    <asp:Repeater ID="SliderRepeater" runat="server" ItemType="PetsWonderland.Business.Models.Pages.Slide">
        <ItemTemplate>
            <div><%#: Eval("Title") %></div>
            <div><%#: Eval("Caption") %></div>
             <asp:Image runat="server" CssClass="importantNews-user-avatar" ImageUrl='<%#: Item.Image %>' ToolTip='asdas' />
         
        </ItemTemplate>
    </asp:Repeater>
     
</div>--%>

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
                                <div class="prism-wrap">
                                    <span>Want to accomodate your pet ?</span>
                                    <span>Browse Hotels</span>
                                </div>                       
                            </div>       
     
                        </div> 
                    </li>    
            </ItemTemplate>
        </asp:Repeater>
            <%--<li data-transition="fade"
                data-slotamount="7" 
                data-masterspeed="500" 
                data-thumb="../../Images/Pages/Homepage/Slider/pets_01.jpg" 
                data-saveperformance="on" 
                data-title="Landing" >
                
                <img runat="server" 
                     src="~/Images/Pages/Homepage/Slider/pets_01.jpg" 
                     alt="slidebg1"
                     data-lazyload="../../Images/Pages/Homepage/Slider/pets_01.jpg" 
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
     
                </div> 
            </li>    
            <li data-transition="random" 
                data-slotamount="2"
                data-masterspeed="500" 
                data-thumb="../../Images/Pages/Homepage/Slider/pets_04.jpg" 
                data-saveperformance="on" 
                data-title="Services Info" >
                
                <img src="~/Images/Pages/Homepage/Slider/pets_04.jpg"
                     runat="server" 
                     alt="slidebg2"
                     data-lazyload="../../Images/Pages/Homepage/Slider/pets_04.jpg" 
                     data-bgposition="center top" 
                     data-bgfit="cover"
                     data-bgrepeat="no-repeat"/>                
            </li>
            <li data-transition="random" 
                data-slotamount="5"
                data-masterspeed="500" 
                data-thumb="../../Images/Pages/Homepage/Slider/pets_03.jpg" 
                data-saveperformance="on" 
                data-title="More.." >
                
                <img src="~/Images/Pages/Homepage/Slider/pets_03.jpg" 
                     alt="slidebg2"
                     data-lazyload="../../Images/Pages/Homepage/Slider/pets_03.jpg" 
                     data-bgposition="center top" 
                     data-bgfit="cover"
                     data-bgrepeat="no-repeat"
                     runat="server" 
                />                
            </li>    --%>       
        </ul>
    </div>
</div>
</section>
