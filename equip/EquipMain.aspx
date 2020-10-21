<%@ Page Title="งานครุภัณฑ์" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipMain.aspx.cs" Inherits="ClaimProject.equip.EquipMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3 class="bg form-control"  style="background-color:#ad0505;font-size:25px;color:white;height:45px">&nbsp;&nbsp;เพิ่มและแก้ไขครุภัณฑ์</h3>
    <div class="row" id="chkmethod" runat="server" ></div>
    <div class="row" runat="server" id="divEquip">
        <div class="col-lg-3 col-md-3 col-sm-3" id="divsearch" runat="server" >
            <div class="card card-stats">
                <div class="card-header card-header-icon" >
                    <div class="card-icon" style="background-color:#d11f00" >
                        <i class="fab fa-sistrix" style="font-size:40px;background-color:#d11f00"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/equip/EquipAdd">ค้นหา/แก้ไข</a>
                    </h4>
                    
                </div>
                
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-3" id="divaddnew" runat="server" visible="false">
            <div class="card card-stats">
                <div class="card-header card-header-icon">
                    <div class="card-icon" style="background-color:#ba0239">
                        <i class="fas fa-plus" style="font-size:40px;background-color:#ba0239" ></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/equip/EquipAddAll" >เพิ่มใหม่</a>
                    </h4>
                    
                </div>
                
            </div>
        </div>
    </div>


    <h3 class="bg form-control"   style="background-color:#185701;font-size:25px;color:white;height:45px">&nbsp;&nbsp;การโอนย้ายครุภัณฑ์</h3>

    <div class="row" runat="server" id="divTransfer">
        <div class="col-lg-3 col-md-3 col-sm-3" >
            <div class="card card-stats">
                <div class="card-header   card-header-icon">
                    <div class="card-icon" style="background-color:#01914b">
                        <i class="fas fa-luggage-cart" style="font-size:40px;background-color:#01914b"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/equip/EquipTranList">ส่งครุภัณฑ์</a>
                    </h4>
                    
                </div>
                
            </div>
        </div>
       <div class="col-lg-3 col-md-3 col-sm-3" >
            <div class="card card-stats">
                <div class="card-header   card-header-icon">
                    <div class="card-icon" style="background-color:#559101">
                        <i class="fas fa-clipboard-check" style="font-size:40px;background-color:#559101"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/equip/EquipTranGetList">รับครุภัณฑ์</a>
                    </h4>
                </div>
            </div>
        </div>
        <!-- ยืม -->
        <div class="col-lg-3 col-md-3 col-sm-3" >
            <div class="card card-stats">
                <div class="card-header   card-header-icon">
                    <div class="card-icon" style="background-color:#26115c">
                        <i class="fas fa-hand-holding" style="font-size:40px;background-color:#26115c"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/equip/EquipLoanList">ยืมครุภัณฑ์</a>
                    </h4>
                </div>
            </div>
        </div>

        <div class="col-lg-3 col-md-3 col-sm-3" >
            <div class="card card-stats">
                <div class="card-header   card-header-icon">
                    <div class="card-icon" style="background-color:#0242ab">
                        <i class="fas fa-share" style="font-size:40px;background-color:#0242ab"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/equip/EquipTranOutList">รับจากภายนอก</a>
                    </h4>                  
                </div>            
            </div>
        </div>
    </div>
    
    
    <div class="row" runat="server" id="divcheckk" visible ="false">
        <div class="col-lg-3 col-md-3 col-sm-3" >
            <div class="card card-stats">
                <div class="card-header   card-header-icon">
                    <div class="card-icon" style="background-color:#fcd200">
                        <i class="fas fa-search-plus" style="font-size:40px;background-color:#fcd200"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/equip/EquipCheckList">ตรวจสอบด่านฯ</a>
                    </h4>                   
                </div>              
            </div>
        </div>

        <div class="col-lg-3 col-md-3 col-sm-3" >
            <div class="card card-stats">
                <div class="card-header   card-header-icon">
                    <div class="card-icon" style="background-color:#147568">
                        <i class="fas fa-history" style="font-size:40px;background-color:#147568"></i>
                    </div>
                    <h4 class="card-category">
                        <a class="nav-link" href="/equip/EquipHistory">ประวัติโอนย้าย</a>
                    </h4>                   
                </div>              
            </div>
        </div>
      
    </div>


</asp:Content>
