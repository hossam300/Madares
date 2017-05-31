<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="CreateWorkShifts.aspx.cs" Inherits="ERPWebForms.HR.CreateWorkShifts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="content">
        <div class="grid_container">
            <div class="grid_12">
                <div class="widget_wrap">
                    <div class="widget_top">
                        <span class="h_icon list"></span>
                        <h6>
                            <asp:Label ID="Label1" runat="server" Text="Create Work Shift" meta:resourcekey="Label1Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;<asp:Label ID="Label2" runat="server" Text="Information" meta:resourcekey="Label2Resource1"></asp:Label></legend>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label3" runat="server" Text="Shift Name" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_7 alpha">
                                                    <asp:TextBox ID="txtShiftName" placeholder="Shift Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtShiftNameResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtShiftName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <span class="clear"></span>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label4" runat="server" Text="From" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_2 alpha">
                                                    <asp:DropDownList ID="ddlFrom" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlFromResource1">
                                                        <asp:ListItem Value="" Selected="True" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                                        <asp:ListItem Value="00:00" meta:resourcekey="ListItemResource2">00:00</asp:ListItem>
                                                        <asp:ListItem Value="00:15" meta:resourcekey="ListItemResource3">00:15</asp:ListItem>
                                                        <asp:ListItem Value="00:30" meta:resourcekey="ListItemResource4">00:30</asp:ListItem>
                                                        <asp:ListItem Value="00:45" meta:resourcekey="ListItemResource5">00:45</asp:ListItem>
                                                        <asp:ListItem Value="01:00" meta:resourcekey="ListItemResource6">01:00</asp:ListItem>
                                                        <asp:ListItem Value="01:15" meta:resourcekey="ListItemResource7">01:15</asp:ListItem>
                                                        <asp:ListItem Value="01:30" meta:resourcekey="ListItemResource8">01:30</asp:ListItem>
                                                        <asp:ListItem Value="01:45" meta:resourcekey="ListItemResource9">01:45</asp:ListItem>
                                                        <asp:ListItem Value="02:00" meta:resourcekey="ListItemResource10">02:00</asp:ListItem>
                                                        <asp:ListItem Value="02:15" meta:resourcekey="ListItemResource11">02:15</asp:ListItem>
                                                        <asp:ListItem Value="02:30" meta:resourcekey="ListItemResource12">02:30</asp:ListItem>
                                                        <asp:ListItem Value="02:45" meta:resourcekey="ListItemResource13">02:45</asp:ListItem>
                                                        <asp:ListItem Value="03:00" meta:resourcekey="ListItemResource14">03:00</asp:ListItem>
                                                        <asp:ListItem Value="03:15" meta:resourcekey="ListItemResource15">03:15</asp:ListItem>
                                                        <asp:ListItem Value="03:30" meta:resourcekey="ListItemResource16">03:30</asp:ListItem>
                                                        <asp:ListItem Value="03:45" meta:resourcekey="ListItemResource17">03:45</asp:ListItem>
                                                        <asp:ListItem Value="04:00" meta:resourcekey="ListItemResource18">04:00</asp:ListItem>
                                                        <asp:ListItem Value="04:15" meta:resourcekey="ListItemResource19">04:15</asp:ListItem>
                                                        <asp:ListItem Value="04:30" meta:resourcekey="ListItemResource20">04:30</asp:ListItem>
                                                        <asp:ListItem Value="04:45" meta:resourcekey="ListItemResource21">04:45</asp:ListItem>
                                                        <asp:ListItem Value="05:00" meta:resourcekey="ListItemResource22">05:00</asp:ListItem>
                                                        <asp:ListItem Value="05:15" meta:resourcekey="ListItemResource23">05:15</asp:ListItem>
                                                        <asp:ListItem Value="05:30" meta:resourcekey="ListItemResource24">05:30</asp:ListItem>
                                                        <asp:ListItem Value="05:45" meta:resourcekey="ListItemResource25">05:45</asp:ListItem>
                                                        <asp:ListItem Value="06:00" meta:resourcekey="ListItemResource26">06:00</asp:ListItem>
                                                        <asp:ListItem Value="06:15" meta:resourcekey="ListItemResource27">06:15</asp:ListItem>
                                                        <asp:ListItem Value="06:30" meta:resourcekey="ListItemResource28">06:30</asp:ListItem>
                                                        <asp:ListItem Value="06:45" meta:resourcekey="ListItemResource29">06:45</asp:ListItem>
                                                        <asp:ListItem Value="07:00" meta:resourcekey="ListItemResource30">07:00</asp:ListItem>
                                                        <asp:ListItem Value="07:15" meta:resourcekey="ListItemResource31">07:15</asp:ListItem>
                                                        <asp:ListItem Value="07:30" meta:resourcekey="ListItemResource32">07:30</asp:ListItem>
                                                        <asp:ListItem Value="07:45" meta:resourcekey="ListItemResource33">07:45</asp:ListItem>
                                                        <asp:ListItem Value="08:00" meta:resourcekey="ListItemResource34">08:00</asp:ListItem>
                                                        <asp:ListItem Value="08:15" meta:resourcekey="ListItemResource35">08:15</asp:ListItem>
                                                        <asp:ListItem Value="08:30" meta:resourcekey="ListItemResource36">08:30</asp:ListItem>
                                                        <asp:ListItem Value="08:45" meta:resourcekey="ListItemResource37">08:45</asp:ListItem>
                                                        <asp:ListItem Value="09:00" meta:resourcekey="ListItemResource38">09:00</asp:ListItem>
                                                        <asp:ListItem Value="09:15" meta:resourcekey="ListItemResource39">09:15</asp:ListItem>
                                                        <asp:ListItem Value="09:30" meta:resourcekey="ListItemResource40">09:30</asp:ListItem>
                                                        <asp:ListItem Value="09:45" meta:resourcekey="ListItemResource41">09:45</asp:ListItem>
                                                        <asp:ListItem Value="10:00" meta:resourcekey="ListItemResource42">10:00</asp:ListItem>
                                                        <asp:ListItem Value="10:15" meta:resourcekey="ListItemResource43">10:15</asp:ListItem>
                                                        <asp:ListItem Value="10:30" meta:resourcekey="ListItemResource44">10:30</asp:ListItem>
                                                        <asp:ListItem Value="10:45" meta:resourcekey="ListItemResource45">10:45</asp:ListItem>
                                                        <asp:ListItem Value="11:00" meta:resourcekey="ListItemResource46">11:00</asp:ListItem>
                                                        <asp:ListItem Value="11:15" meta:resourcekey="ListItemResource47">11:15</asp:ListItem>
                                                        <asp:ListItem Value="11:30" meta:resourcekey="ListItemResource48">11:30</asp:ListItem>
                                                        <asp:ListItem Value="11:45" meta:resourcekey="ListItemResource49">11:45</asp:ListItem>
                                                        <asp:ListItem Value="12:00" meta:resourcekey="ListItemResource50">12:00</asp:ListItem>
                                                        <asp:ListItem Value="12:15" meta:resourcekey="ListItemResource51">12:15</asp:ListItem>
                                                        <asp:ListItem Value="12:30" meta:resourcekey="ListItemResource52">12:30</asp:ListItem>
                                                        <asp:ListItem Value="12:45" meta:resourcekey="ListItemResource53">12:45</asp:ListItem>
                                                        <asp:ListItem Value="13:00" meta:resourcekey="ListItemResource54">13:00</asp:ListItem>
                                                        <asp:ListItem Value="13:15" meta:resourcekey="ListItemResource55">13:15</asp:ListItem>
                                                        <asp:ListItem Value="13:30" meta:resourcekey="ListItemResource56">13:30</asp:ListItem>
                                                        <asp:ListItem Value="13:45" meta:resourcekey="ListItemResource57">13:45</asp:ListItem>
                                                        <asp:ListItem Value="14:00" meta:resourcekey="ListItemResource58">14:00</asp:ListItem>
                                                        <asp:ListItem Value="14:15" meta:resourcekey="ListItemResource59">14:15</asp:ListItem>
                                                        <asp:ListItem Value="14:30" meta:resourcekey="ListItemResource60">14:30</asp:ListItem>
                                                        <asp:ListItem Value="14:45" meta:resourcekey="ListItemResource61">14:45</asp:ListItem>
                                                        <asp:ListItem Value="15:00" meta:resourcekey="ListItemResource62">15:00</asp:ListItem>
                                                        <asp:ListItem Value="15:15" meta:resourcekey="ListItemResource63">15:15</asp:ListItem>
                                                        <asp:ListItem Value="15:30" meta:resourcekey="ListItemResource64">15:30</asp:ListItem>
                                                        <asp:ListItem Value="15:45" meta:resourcekey="ListItemResource65">15:45</asp:ListItem>
                                                        <asp:ListItem Value="16:00" meta:resourcekey="ListItemResource66">16:00</asp:ListItem>
                                                        <asp:ListItem Value="16:15" meta:resourcekey="ListItemResource67">16:15</asp:ListItem>
                                                        <asp:ListItem Value="16:30" meta:resourcekey="ListItemResource68">16:30</asp:ListItem>
                                                        <asp:ListItem Value="16:45" meta:resourcekey="ListItemResource69">16:45</asp:ListItem>
                                                        <asp:ListItem Value="17:00" meta:resourcekey="ListItemResource70">17:00</asp:ListItem>
                                                        <asp:ListItem Value="17:15" meta:resourcekey="ListItemResource71">17:15</asp:ListItem>
                                                        <asp:ListItem Value="17:30" meta:resourcekey="ListItemResource72">17:30</asp:ListItem>
                                                        <asp:ListItem Value="17:45" meta:resourcekey="ListItemResource73">17:45</asp:ListItem>
                                                        <asp:ListItem Value="18:00" meta:resourcekey="ListItemResource74">18:00</asp:ListItem>
                                                        <asp:ListItem Value="18:15" meta:resourcekey="ListItemResource75">18:15</asp:ListItem>
                                                        <asp:ListItem Value="18:30" meta:resourcekey="ListItemResource76">18:30</asp:ListItem>
                                                        <asp:ListItem Value="18:45" meta:resourcekey="ListItemResource77">18:45</asp:ListItem>
                                                        <asp:ListItem Value="19:00" meta:resourcekey="ListItemResource78">19:00</asp:ListItem>
                                                        <asp:ListItem Value="19:15" meta:resourcekey="ListItemResource79">19:15</asp:ListItem>
                                                        <asp:ListItem Value="19:30" meta:resourcekey="ListItemResource80">19:30</asp:ListItem>
                                                        <asp:ListItem Value="19:45" meta:resourcekey="ListItemResource81">19:45</asp:ListItem>
                                                        <asp:ListItem Value="20:00" meta:resourcekey="ListItemResource82">20:00</asp:ListItem>
                                                        <asp:ListItem Value="20:15" meta:resourcekey="ListItemResource83">20:15</asp:ListItem>
                                                        <asp:ListItem Value="20:30" meta:resourcekey="ListItemResource84">20:30</asp:ListItem>
                                                        <asp:ListItem Value="20:45" meta:resourcekey="ListItemResource85">20:45</asp:ListItem>
                                                        <asp:ListItem Value="21:00" meta:resourcekey="ListItemResource86">21:00</asp:ListItem>
                                                        <asp:ListItem Value="21:15" meta:resourcekey="ListItemResource87">21:15</asp:ListItem>
                                                        <asp:ListItem Value="21:30" meta:resourcekey="ListItemResource88">21:30</asp:ListItem>
                                                        <asp:ListItem Value="21:45" meta:resourcekey="ListItemResource89">21:45</asp:ListItem>
                                                        <asp:ListItem Value="22:00" meta:resourcekey="ListItemResource90">22:00</asp:ListItem>
                                                        <asp:ListItem Value="22:15" meta:resourcekey="ListItemResource91">22:15</asp:ListItem>
                                                        <asp:ListItem Value="22:30" meta:resourcekey="ListItemResource92">22:30</asp:ListItem>
                                                        <asp:ListItem Value="22:45" meta:resourcekey="ListItemResource93">22:45</asp:ListItem>
                                                        <asp:ListItem Value="23:00" meta:resourcekey="ListItemResource94">23:00</asp:ListItem>
                                                        <asp:ListItem Value="23:15" meta:resourcekey="ListItemResource95">23:15</asp:ListItem>
                                                        <asp:ListItem Value="23:30" meta:resourcekey="ListItemResource96">23:30</asp:ListItem>
                                                        <asp:ListItem Value="23:45" meta:resourcekey="ListItemResource97">23:45</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="ddlFrom" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label5" runat="server" Text="To" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                <div class="form_grid_2">
                                                    <asp:DropDownList ID="ddlTo" runat="server" type="text" TabIndex="1" Style="width: 100%" class="chzn-select" meta:resourcekey="ddlToResource1">
                                                        <asp:ListItem Value="" Selected="True" meta:resourcekey="ListItemResource98"></asp:ListItem>
                                                        <asp:ListItem Value="00:00" meta:resourcekey="ListItemResource99">00:00</asp:ListItem>
                                                        <asp:ListItem Value="00:15" meta:resourcekey="ListItemResource100">00:15</asp:ListItem>
                                                        <asp:ListItem Value="00:30" meta:resourcekey="ListItemResource101">00:30</asp:ListItem>
                                                        <asp:ListItem Value="00:45" meta:resourcekey="ListItemResource102">00:45</asp:ListItem>
                                                        <asp:ListItem Value="01:00" meta:resourcekey="ListItemResource103">01:00</asp:ListItem>
                                                        <asp:ListItem Value="01:15" meta:resourcekey="ListItemResource104">01:15</asp:ListItem>
                                                        <asp:ListItem Value="01:30" meta:resourcekey="ListItemResource105">01:30</asp:ListItem>
                                                        <asp:ListItem Value="01:45" meta:resourcekey="ListItemResource106">01:45</asp:ListItem>
                                                        <asp:ListItem Value="02:00" meta:resourcekey="ListItemResource107">02:00</asp:ListItem>
                                                        <asp:ListItem Value="02:15" meta:resourcekey="ListItemResource108">02:15</asp:ListItem>
                                                        <asp:ListItem Value="02:30" meta:resourcekey="ListItemResource109">02:30</asp:ListItem>
                                                        <asp:ListItem Value="02:45" meta:resourcekey="ListItemResource110">02:45</asp:ListItem>
                                                        <asp:ListItem Value="03:00" meta:resourcekey="ListItemResource111">03:00</asp:ListItem>
                                                        <asp:ListItem Value="03:15" meta:resourcekey="ListItemResource112">03:15</asp:ListItem>
                                                        <asp:ListItem Value="03:30" meta:resourcekey="ListItemResource113">03:30</asp:ListItem>
                                                        <asp:ListItem Value="03:45" meta:resourcekey="ListItemResource114">03:45</asp:ListItem>
                                                        <asp:ListItem Value="04:00" meta:resourcekey="ListItemResource115">04:00</asp:ListItem>
                                                        <asp:ListItem Value="04:15" meta:resourcekey="ListItemResource116">04:15</asp:ListItem>
                                                        <asp:ListItem Value="04:30" meta:resourcekey="ListItemResource117">04:30</asp:ListItem>
                                                        <asp:ListItem Value="04:45" meta:resourcekey="ListItemResource118">04:45</asp:ListItem>
                                                        <asp:ListItem Value="05:00" meta:resourcekey="ListItemResource119">05:00</asp:ListItem>
                                                        <asp:ListItem Value="05:15" meta:resourcekey="ListItemResource120">05:15</asp:ListItem>
                                                        <asp:ListItem Value="05:30" meta:resourcekey="ListItemResource121">05:30</asp:ListItem>
                                                        <asp:ListItem Value="05:45" meta:resourcekey="ListItemResource122">05:45</asp:ListItem>
                                                        <asp:ListItem Value="06:00" meta:resourcekey="ListItemResource123">06:00</asp:ListItem>
                                                        <asp:ListItem Value="06:15" meta:resourcekey="ListItemResource124">06:15</asp:ListItem>
                                                        <asp:ListItem Value="06:30" meta:resourcekey="ListItemResource125">06:30</asp:ListItem>
                                                        <asp:ListItem Value="06:45" meta:resourcekey="ListItemResource126">06:45</asp:ListItem>
                                                        <asp:ListItem Value="07:00" meta:resourcekey="ListItemResource127">07:00</asp:ListItem>
                                                        <asp:ListItem Value="07:15" meta:resourcekey="ListItemResource128">07:15</asp:ListItem>
                                                        <asp:ListItem Value="07:30" meta:resourcekey="ListItemResource129">07:30</asp:ListItem>
                                                        <asp:ListItem Value="07:45" meta:resourcekey="ListItemResource130">07:45</asp:ListItem>
                                                        <asp:ListItem Value="08:00" meta:resourcekey="ListItemResource131">08:00</asp:ListItem>
                                                        <asp:ListItem Value="08:15" meta:resourcekey="ListItemResource132">08:15</asp:ListItem>
                                                        <asp:ListItem Value="08:30" meta:resourcekey="ListItemResource133">08:30</asp:ListItem>
                                                        <asp:ListItem Value="08:45" meta:resourcekey="ListItemResource134">08:45</asp:ListItem>
                                                        <asp:ListItem Value="09:00" meta:resourcekey="ListItemResource135">09:00</asp:ListItem>
                                                        <asp:ListItem Value="09:15" meta:resourcekey="ListItemResource136">09:15</asp:ListItem>
                                                        <asp:ListItem Value="09:30" meta:resourcekey="ListItemResource137">09:30</asp:ListItem>
                                                        <asp:ListItem Value="09:45" meta:resourcekey="ListItemResource138">09:45</asp:ListItem>
                                                        <asp:ListItem Value="10:00" meta:resourcekey="ListItemResource139">10:00</asp:ListItem>
                                                        <asp:ListItem Value="10:15" meta:resourcekey="ListItemResource140">10:15</asp:ListItem>
                                                        <asp:ListItem Value="10:30" meta:resourcekey="ListItemResource141">10:30</asp:ListItem>
                                                        <asp:ListItem Value="10:45" meta:resourcekey="ListItemResource142">10:45</asp:ListItem>
                                                        <asp:ListItem Value="11:00" meta:resourcekey="ListItemResource143">11:00</asp:ListItem>
                                                        <asp:ListItem Value="11:15" meta:resourcekey="ListItemResource144">11:15</asp:ListItem>
                                                        <asp:ListItem Value="11:30" meta:resourcekey="ListItemResource145">11:30</asp:ListItem>
                                                        <asp:ListItem Value="11:45" meta:resourcekey="ListItemResource146">11:45</asp:ListItem>
                                                        <asp:ListItem Value="12:00" meta:resourcekey="ListItemResource147">12:00</asp:ListItem>
                                                        <asp:ListItem Value="12:15" meta:resourcekey="ListItemResource148">12:15</asp:ListItem>
                                                        <asp:ListItem Value="12:30" meta:resourcekey="ListItemResource149">12:30</asp:ListItem>
                                                        <asp:ListItem Value="12:45" meta:resourcekey="ListItemResource150">12:45</asp:ListItem>
                                                        <asp:ListItem Value="13:00" meta:resourcekey="ListItemResource151">13:00</asp:ListItem>
                                                        <asp:ListItem Value="13:15" meta:resourcekey="ListItemResource152">13:15</asp:ListItem>
                                                        <asp:ListItem Value="13:30" meta:resourcekey="ListItemResource153">13:30</asp:ListItem>
                                                        <asp:ListItem Value="13:45" meta:resourcekey="ListItemResource154">13:45</asp:ListItem>
                                                        <asp:ListItem Value="14:00" meta:resourcekey="ListItemResource155">14:00</asp:ListItem>
                                                        <asp:ListItem Value="14:15" meta:resourcekey="ListItemResource156">14:15</asp:ListItem>
                                                        <asp:ListItem Value="14:30" meta:resourcekey="ListItemResource157">14:30</asp:ListItem>
                                                        <asp:ListItem Value="14:45" meta:resourcekey="ListItemResource158">14:45</asp:ListItem>
                                                        <asp:ListItem Value="15:00" meta:resourcekey="ListItemResource159">15:00</asp:ListItem>
                                                        <asp:ListItem Value="15:15" meta:resourcekey="ListItemResource160">15:15</asp:ListItem>
                                                        <asp:ListItem Value="15:30" meta:resourcekey="ListItemResource161">15:30</asp:ListItem>
                                                        <asp:ListItem Value="15:45" meta:resourcekey="ListItemResource162">15:45</asp:ListItem>
                                                        <asp:ListItem Value="16:00" meta:resourcekey="ListItemResource163">16:00</asp:ListItem>
                                                        <asp:ListItem Value="16:15" meta:resourcekey="ListItemResource164">16:15</asp:ListItem>
                                                        <asp:ListItem Value="16:30" meta:resourcekey="ListItemResource165">16:30</asp:ListItem>
                                                        <asp:ListItem Value="16:45" meta:resourcekey="ListItemResource166">16:45</asp:ListItem>
                                                        <asp:ListItem Value="17:00" meta:resourcekey="ListItemResource167">17:00</asp:ListItem>
                                                        <asp:ListItem Value="17:15" meta:resourcekey="ListItemResource168">17:15</asp:ListItem>
                                                        <asp:ListItem Value="17:30" meta:resourcekey="ListItemResource169">17:30</asp:ListItem>
                                                        <asp:ListItem Value="17:45" meta:resourcekey="ListItemResource170">17:45</asp:ListItem>
                                                        <asp:ListItem Value="18:00" meta:resourcekey="ListItemResource171">18:00</asp:ListItem>
                                                        <asp:ListItem Value="18:15" meta:resourcekey="ListItemResource172">18:15</asp:ListItem>
                                                        <asp:ListItem Value="18:30" meta:resourcekey="ListItemResource173">18:30</asp:ListItem>
                                                        <asp:ListItem Value="18:45" meta:resourcekey="ListItemResource174">18:45</asp:ListItem>
                                                        <asp:ListItem Value="19:00" meta:resourcekey="ListItemResource175">19:00</asp:ListItem>
                                                        <asp:ListItem Value="19:15" meta:resourcekey="ListItemResource176">19:15</asp:ListItem>
                                                        <asp:ListItem Value="19:30" meta:resourcekey="ListItemResource177">19:30</asp:ListItem>
                                                        <asp:ListItem Value="19:45" meta:resourcekey="ListItemResource178">19:45</asp:ListItem>
                                                        <asp:ListItem Value="20:00" meta:resourcekey="ListItemResource179">20:00</asp:ListItem>
                                                        <asp:ListItem Value="20:15" meta:resourcekey="ListItemResource180">20:15</asp:ListItem>
                                                        <asp:ListItem Value="20:30" meta:resourcekey="ListItemResource181">20:30</asp:ListItem>
                                                        <asp:ListItem Value="20:45" meta:resourcekey="ListItemResource182">20:45</asp:ListItem>
                                                        <asp:ListItem Value="21:00" meta:resourcekey="ListItemResource183">21:00</asp:ListItem>
                                                        <asp:ListItem Value="21:15" meta:resourcekey="ListItemResource184">21:15</asp:ListItem>
                                                        <asp:ListItem Value="21:30" meta:resourcekey="ListItemResource185">21:30</asp:ListItem>
                                                        <asp:ListItem Value="21:45" meta:resourcekey="ListItemResource186">21:45</asp:ListItem>
                                                        <asp:ListItem Value="22:00" meta:resourcekey="ListItemResource187">22:00</asp:ListItem>
                                                        <asp:ListItem Value="22:15" meta:resourcekey="ListItemResource188">22:15</asp:ListItem>
                                                        <asp:ListItem Value="22:30" meta:resourcekey="ListItemResource189">22:30</asp:ListItem>
                                                        <asp:ListItem Value="22:45" meta:resourcekey="ListItemResource190">22:45</asp:ListItem>
                                                        <asp:ListItem Value="23:00" meta:resourcekey="ListItemResource191">23:00</asp:ListItem>
                                                        <asp:ListItem Value="23:15" meta:resourcekey="ListItemResource192">23:15</asp:ListItem>
                                                        <asp:ListItem Value="23:30" meta:resourcekey="ListItemResource193">23:30</asp:ListItem>
                                                        <asp:ListItem Value="23:45" meta:resourcekey="ListItemResource194">23:45</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="ddlTo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <%-- <label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label6" runat="server" Text="Duration" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                        <div class="form_grid_2">
                                            <asp:TextBox ID="txtDuration" placeholder="Duration" runat="server" type="text" tabindex="1" class="limiter required" meta:resourcekey="txtDurationResource1"></asp:TextBox>
                                                --%> <%--</div>--%>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label7" runat="server" Text="Employees List" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="list_left">
                                                    <div class="list_filter">
                                                        <label>
                                                            <asp:Label ID="Label8" runat="server" Text="Available Employees:" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                                        &nbsp;
                                                    </div>
                                                    <asp:ListBox ID="box1View" runat="server" multiple="multiple" class="multiple_list" DataTextField="EmpName" DataValueField="EmpID" meta:resourcekey="box1ViewResource1"></asp:ListBox>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [EmpID], [EmpName] FROM [HR_Employees]"></asp:SqlDataSource>
                                                </div>
                                                <div class="list_switch">
                                                    <asp:Button ID="btnAddAll" CausesValidation="false" runat="server" Text=">>" class="swap_btn" UseSubmitBehavior="False" OnClick="btnAddAll_Click" meta:resourcekey="btnAddAllResource1" />
                                                    <asp:Button ID="btnAllSelected" CausesValidation="false" runat="server" Text=">" class="swap_btn" UseSubmitBehavior="False" OnClick="btnAllSelected_Click" meta:resourcekey="btnAllSelectedResource1" />
                                                    <asp:Button ID="btnRemoveSelected" CausesValidation="false" runat="server" Text="<" class="swap_btn" UseSubmitBehavior="False" OnClick="btnRemoveSelected_Click" meta:resourcekey="btnRemoveSelectedResource1" />
                                                    <asp:Button ID="btnRemoveAll" CausesValidation="false" runat="server" Text="<<" class="swap_btn" UseSubmitBehavior="False" OnClick="btnRemoveAll_Click" meta:resourcekey="btnRemoveAllResource1" />
                                                </div>
                                                <div class="list_right">
                                                    <div class="list_filter">
                                                        <label>
                                                            <asp:Label ID="Label9" runat="server" Text="Assigned Employees:" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                                        &nbsp;
                                                    </div>
                                                    <asp:ListBox ID="box2View" runat="server" multiple="multiple" class="multiple_list" meta:resourcekey="box2ViewResource1"></asp:ListBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="box2View" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <div class="list_itemcount">
                                                        <asp:Label ID="lbmsg" runat="server" meta:resourcekey="lbmsgResource1"></asp:Label>
                                                    </div>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="False" class="btn_small btn_blue" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
                                                <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" runat="server" Text="Save" class="btn_small btn_blue" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" class="btn_small btn_orange" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" />
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>