<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRMasterPage.master" AutoEventWireup="true" CodeBehind="CreateEmployee.aspx.cs" Inherits="ERPWebForms.HR.CreateEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                            <asp:Label ID="Label2" runat="server" Text="Create Employee" meta:resourcekey="Label2Resource1"></asp:Label></h6>
                    </div>
                    <div class="widget_content">
                        <div id="form103" class="form_container left_label valid_tip">
                            <div>
                                <br />
                            </div>
                            <fieldset style="border: 1px solid">
                                <legend>&nbsp;<asp:Label ID="Label1" runat="server" Text="Information" meta:resourcekey="Label1Resource1"></asp:Label></legend>
                                <fieldset style="border: 1px solid">
                                    <legend>
                                        <asp:Label ID="Label15" runat="server" Text="<%$ Resources:Name %>"></asp:Label></legend>
                                    <ul>
                                        <li>
                                            <div class="form_grid_12">
                                                <label class="field_title">
                                                    <asp:Label ID="Label3" runat="server" Text="Frist Name" meta:resourcekey="Label3Resource1"></asp:Label></label>
                                                <div class="form_input">
                                                    <div class="form_grid_4 alpha">
                                                        <asp:TextBox ID="txtfname" placeholder="Frist Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtfnameResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtfname" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <label class="field_title">&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Middle Name" meta:resourcekey="Label4Resource1"></asp:Label></label>
                                                    <div class="form_grid_4">
                                                        <asp:TextBox ID="txtmname" placeholder="Middle Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtmnameResource1"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="form_grid_12">
                                                <label class="field_title">
                                                    <asp:Label ID="Label5" runat="server" Text="Last Name" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                                <div class="form_input">
                                                    <div class="form_grid_4 alpha">
                                                        <asp:TextBox ID="txtlname" placeholder="Last Name" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtlnameResource1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtlname" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </li>
                                    </ul>
                                </fieldset>
                                <ul>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label6" runat="server" Text="Employee Code" meta:resourcekey="Label6Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtEmpCode" placeholder="Employee Code" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtEmpCodeResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtEmpCode" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label7" runat="server" Text="Sallary" meta:resourcekey="Label7Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txtSallary" placeholder="Sallary" runat="server" type="number" Width="100%" TabIndex="1" class="limiter required" meta:resourcekey="txtSallaryResource1"></asp:TextBox>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label8" runat="server" Text="Job Title" meta:resourcekey="Label8Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlJobTitle" runat="server" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" DataSourceID="SqlDataSource3" DataTextField="JobTitle" DataValueField="JobTitleID" meta:resourcekey="ddlJobTitleResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource1" Selected="True" Value="">Choose Job Title</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="<%$ Resources:ListItemResource1.Text %>" runat="server" ForeColor="Red" ControlToValidate="ddlJobTitle" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [JobTitleID], [JobTitle] FROM [HR_JobTitle]"></asp:SqlDataSource>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="Job Category" meta:resourcekey="Label9Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlJobCategory" runat="server" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" DataSourceID="SqlDataSource1" DataTextField="JobCategory" DataValueField="JobCategoryID" meta:resourcekey="ddlJobCategoryResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource2" Selected="True" Value="">Choose Job Category</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="<%$ Resources:ListItemResource2.Text %>" runat="server" ForeColor="Red" ControlToValidate="ddlJobCategory" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [JobCategoryID], [JobCategory] FROM [HR_JobCategory]"></asp:SqlDataSource>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label14" runat="server" Text="Pay Grade" meta:resourcekey="Label14Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlPayGrade" runat="server" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" DataSourceID="SqlDataSource4" DataTextField="PayGrade" DataValueField="PayGradeID" meta:resourcekey="ddlPayGradeResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource3" Selected="True" Value="">Choose Pay Grade</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="<%$ Resources:ListItemResource3.Text %>" ForeColor="Red" ControlToValidate="ddlPayGrade" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ERP2ConnectionString %>" SelectCommand="SELECT [PayGradeID], [PayGrade] FROM [HR_PayGrades]"></asp:SqlDataSource>
                                                </div>
                                                <label class="field_title">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label11" runat="server" Text="Hiring Date" meta:resourcekey="Label11Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:TextBox ID="txthirngdate" placeholder="Hiring Date" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txthirngdateResource1"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txthirngdate" BehaviorID="CalendarExtender1" Format="dd/MM/yyyy" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ControlToValidate="txthirngdate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label12" runat="server" Text="Specialty" meta:resourcekey="Label12Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:TextBox ID="txtSpecialty" placeholder="Specialty" runat="server" type="text" TabIndex="1" class="limiter required" meta:resourcekey="txtSpecialtyResource1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="txtSpecialty" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="field_title">&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="Report To" meta:resourcekey="Label13Resource1"></asp:Label></label>
                                                <div class="form_grid_4">
                                                    <asp:DropDownList ID="ddlReportTo" runat="server" AppendDataBoundItems="True" Style="width: 100%" class="chzn-select" TabIndex="13" DataSourceID="SqlDataSource2" DataTextField="EmpName" DataValueField="EmpID" meta:resourcekey="ddlReportToResource1">
                                                        <asp:ListItem meta:resourcekey="ListItemResource4">Choose User</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ERP2ConnectionString %>' SelectCommand="SELECT [EmpID], [EmpName] FROM [HR_Employees]"></asp:SqlDataSource>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <label class="field_title">
                                                <asp:Label ID="Label10" runat="server" Text="Nationality" meta:resourcekey="Label10Resource1"></asp:Label></label>
                                            <div class="form_input">
                                                <div class="form_grid_4 alpha">
                                                    <asp:DropDownList ID="ddlNationality" runat="server" Style="width: 100%" class="chzn-select" TabIndex="13" meta:resourcekey="ddlNationalityResource1">
                                                        <asp:ListItem Value="" Selected="True" meta:resourcekey="ListItemResource5">Select Country</asp:ListItem>
                                                        <asp:ListItem Value="AF" meta:resourcekey="ListItemResource6">Afghanistan</asp:ListItem>
                                                        <asp:ListItem Value="AL" meta:resourcekey="ListItemResource7">Albania</asp:ListItem>
                                                        <asp:ListItem Value="DZ" meta:resourcekey="ListItemResource8">Algeria</asp:ListItem>
                                                        <asp:ListItem Value="AS" meta:resourcekey="ListItemResource9">American Samoa</asp:ListItem>
                                                        <asp:ListItem Value="AD" meta:resourcekey="ListItemResource10">Andorra</asp:ListItem>
                                                        <asp:ListItem Value="AO" meta:resourcekey="ListItemResource11">Angola</asp:ListItem>
                                                        <asp:ListItem Value="AI" meta:resourcekey="ListItemResource12">Anguilla</asp:ListItem>
                                                        <asp:ListItem Value="AQ" meta:resourcekey="ListItemResource13">Antarctica</asp:ListItem>
                                                        <asp:ListItem Value="AG" meta:resourcekey="ListItemResource14">Antigua And Barbuda</asp:ListItem>
                                                        <asp:ListItem Value="AR" meta:resourcekey="ListItemResource15">Argentina</asp:ListItem>
                                                        <asp:ListItem Value="AM" meta:resourcekey="ListItemResource16">Armenia</asp:ListItem>
                                                        <asp:ListItem Value="AW" meta:resourcekey="ListItemResource17">Aruba</asp:ListItem>
                                                        <asp:ListItem Value="AU" meta:resourcekey="ListItemResource18">Australia</asp:ListItem>
                                                        <asp:ListItem Value="AT" meta:resourcekey="ListItemResource19">Austria</asp:ListItem>
                                                        <asp:ListItem Value="AZ" meta:resourcekey="ListItemResource20">Azerbaijan</asp:ListItem>
                                                        <asp:ListItem Value="BS" meta:resourcekey="ListItemResource21">Bahamas</asp:ListItem>
                                                        <asp:ListItem Value="BH" meta:resourcekey="ListItemResource22">Bahrain</asp:ListItem>
                                                        <asp:ListItem Value="BD" meta:resourcekey="ListItemResource23">Bangladesh</asp:ListItem>
                                                        <asp:ListItem Value="BB" meta:resourcekey="ListItemResource24">Barbados</asp:ListItem>
                                                        <asp:ListItem Value="BY" meta:resourcekey="ListItemResource25">Belarus</asp:ListItem>
                                                        <asp:ListItem Value="BE" meta:resourcekey="ListItemResource26">Belgium</asp:ListItem>
                                                        <asp:ListItem Value="BZ" meta:resourcekey="ListItemResource27">Belize</asp:ListItem>
                                                        <asp:ListItem Value="BJ" meta:resourcekey="ListItemResource28">Benin</asp:ListItem>
                                                        <asp:ListItem Value="BM" meta:resourcekey="ListItemResource29">Bermuda</asp:ListItem>
                                                        <asp:ListItem Value="BT" meta:resourcekey="ListItemResource30">Bhutan</asp:ListItem>
                                                        <asp:ListItem Value="BO" meta:resourcekey="ListItemResource31">Bolivia</asp:ListItem>
                                                        <asp:ListItem Value="BA" meta:resourcekey="ListItemResource32">Bosnia And Herzegowina</asp:ListItem>
                                                        <asp:ListItem Value="BW" meta:resourcekey="ListItemResource33">Botswana</asp:ListItem>
                                                        <asp:ListItem Value="BV" meta:resourcekey="ListItemResource34">Bouvet Island</asp:ListItem>
                                                        <asp:ListItem Value="BR" meta:resourcekey="ListItemResource35">Brazil</asp:ListItem>
                                                        <asp:ListItem Value="IO" meta:resourcekey="ListItemResource36">British Indian Ocean Territory</asp:ListItem>
                                                        <asp:ListItem Value="BN" meta:resourcekey="ListItemResource37">Brunei Darussalam</asp:ListItem>
                                                        <asp:ListItem Value="BG" meta:resourcekey="ListItemResource38">Bulgaria</asp:ListItem>
                                                        <asp:ListItem Value="BF" meta:resourcekey="ListItemResource39">Burkina Faso</asp:ListItem>
                                                        <asp:ListItem Value="BI" meta:resourcekey="ListItemResource40">Burundi</asp:ListItem>
                                                        <asp:ListItem Value="KH" meta:resourcekey="ListItemResource41">Cambodia</asp:ListItem>
                                                        <asp:ListItem Value="CM" meta:resourcekey="ListItemResource42">Cameroon</asp:ListItem>
                                                        <asp:ListItem Value="CA" meta:resourcekey="ListItemResource43">Canada</asp:ListItem>
                                                        <asp:ListItem Value="CV" meta:resourcekey="ListItemResource44">Cape Verde</asp:ListItem>
                                                        <asp:ListItem Value="KY" meta:resourcekey="ListItemResource45">Cayman Islands</asp:ListItem>
                                                        <asp:ListItem Value="CF" meta:resourcekey="ListItemResource46">Central African Republic</asp:ListItem>
                                                        <asp:ListItem Value="TD" meta:resourcekey="ListItemResource47">Chad</asp:ListItem>
                                                        <asp:ListItem Value="CL" meta:resourcekey="ListItemResource48">Chile</asp:ListItem>
                                                        <asp:ListItem Value="CN" meta:resourcekey="ListItemResource49">China</asp:ListItem>
                                                        <asp:ListItem Value="CX" meta:resourcekey="ListItemResource50">Christmas Island</asp:ListItem>
                                                        <asp:ListItem Value="CC" meta:resourcekey="ListItemResource51">Cocos (Keeling) Islands</asp:ListItem>
                                                        <asp:ListItem Value="CO" meta:resourcekey="ListItemResource52">Colombia</asp:ListItem>
                                                        <asp:ListItem Value="KM" meta:resourcekey="ListItemResource53">Comoros</asp:ListItem>
                                                        <asp:ListItem Value="CG" meta:resourcekey="ListItemResource54">Congo</asp:ListItem>
                                                        <asp:ListItem Value="CK" meta:resourcekey="ListItemResource55">Cook Islands</asp:ListItem>
                                                        <asp:ListItem Value="CR" meta:resourcekey="ListItemResource56">Costa Rica</asp:ListItem>
                                                        <asp:ListItem Value="CI" meta:resourcekey="ListItemResource57">Cote D'Ivoire</asp:ListItem>
                                                        <asp:ListItem Value="HR" meta:resourcekey="ListItemResource58">Croatia (Local Name: Hrvatska)</asp:ListItem>
                                                        <asp:ListItem Value="CU" meta:resourcekey="ListItemResource59">Cuba</asp:ListItem>
                                                        <asp:ListItem Value="CY" meta:resourcekey="ListItemResource60">Cyprus</asp:ListItem>
                                                        <asp:ListItem Value="CZ" meta:resourcekey="ListItemResource61">Czech Republic</asp:ListItem>
                                                        <asp:ListItem Value="DK" meta:resourcekey="ListItemResource62">Denmark</asp:ListItem>
                                                        <asp:ListItem Value="DJ" meta:resourcekey="ListItemResource63">Djibouti</asp:ListItem>
                                                        <asp:ListItem Value="DM" meta:resourcekey="ListItemResource64">Dominica</asp:ListItem>
                                                        <asp:ListItem Value="DO" meta:resourcekey="ListItemResource65">Dominican Republic</asp:ListItem>
                                                        <asp:ListItem Value="TP" meta:resourcekey="ListItemResource66">East Timor</asp:ListItem>
                                                        <asp:ListItem Value="EC" meta:resourcekey="ListItemResource67">Ecuador</asp:ListItem>
                                                        <asp:ListItem Value="EG" meta:resourcekey="ListItemResource68">Egypt</asp:ListItem>
                                                        <asp:ListItem Value="SV" meta:resourcekey="ListItemResource69">El Salvador</asp:ListItem>
                                                        <asp:ListItem Value="GQ" meta:resourcekey="ListItemResource70">Equatorial Guinea</asp:ListItem>
                                                        <asp:ListItem Value="ER" meta:resourcekey="ListItemResource71">Eritrea</asp:ListItem>
                                                        <asp:ListItem Value="EE" meta:resourcekey="ListItemResource72">Estonia</asp:ListItem>
                                                        <asp:ListItem Value="ET" meta:resourcekey="ListItemResource73">Ethiopia</asp:ListItem>
                                                        <asp:ListItem Value="FK" meta:resourcekey="ListItemResource74">Falkland Islands (Malvinas)</asp:ListItem>
                                                        <asp:ListItem Value="FO" meta:resourcekey="ListItemResource75">Faroe Islands</asp:ListItem>
                                                        <asp:ListItem Value="FJ" meta:resourcekey="ListItemResource76">Fiji</asp:ListItem>
                                                        <asp:ListItem Value="FI" meta:resourcekey="ListItemResource77">Finland</asp:ListItem>
                                                        <asp:ListItem Value="FR" meta:resourcekey="ListItemResource78">France</asp:ListItem>
                                                        <asp:ListItem Value="GF" meta:resourcekey="ListItemResource79">French Guiana</asp:ListItem>
                                                        <asp:ListItem Value="PF" meta:resourcekey="ListItemResource80">French Polynesia</asp:ListItem>
                                                        <asp:ListItem Value="TF" meta:resourcekey="ListItemResource81">French Southern Territories</asp:ListItem>
                                                        <asp:ListItem Value="GA" meta:resourcekey="ListItemResource82">Gabon</asp:ListItem>
                                                        <asp:ListItem Value="GM" meta:resourcekey="ListItemResource83">Gambia</asp:ListItem>
                                                        <asp:ListItem Value="GE" meta:resourcekey="ListItemResource84">Georgia</asp:ListItem>
                                                        <asp:ListItem Value="DE" meta:resourcekey="ListItemResource85">Germany</asp:ListItem>
                                                        <asp:ListItem Value="GH" meta:resourcekey="ListItemResource86">Ghana</asp:ListItem>
                                                        <asp:ListItem Value="GI" meta:resourcekey="ListItemResource87">Gibraltar</asp:ListItem>
                                                        <asp:ListItem Value="GR" meta:resourcekey="ListItemResource88">Greece</asp:ListItem>
                                                        <asp:ListItem Value="GL" meta:resourcekey="ListItemResource89">Greenland</asp:ListItem>
                                                        <asp:ListItem Value="GD" meta:resourcekey="ListItemResource90">Grenada</asp:ListItem>
                                                        <asp:ListItem Value="GP" meta:resourcekey="ListItemResource91">Guadeloupe</asp:ListItem>
                                                        <asp:ListItem Value="GU" meta:resourcekey="ListItemResource92">Guam</asp:ListItem>
                                                        <asp:ListItem Value="GT" meta:resourcekey="ListItemResource93">Guatemala</asp:ListItem>
                                                        <asp:ListItem Value="GN" meta:resourcekey="ListItemResource94">Guinea</asp:ListItem>
                                                        <asp:ListItem Value="GW" meta:resourcekey="ListItemResource95">Guinea-Bissau</asp:ListItem>
                                                        <asp:ListItem Value="GY" meta:resourcekey="ListItemResource96">Guyana</asp:ListItem>
                                                        <asp:ListItem Value="HT" meta:resourcekey="ListItemResource97">Haiti</asp:ListItem>
                                                        <asp:ListItem Value="HM" meta:resourcekey="ListItemResource98">Heard And Mc Donald Islands</asp:ListItem>
                                                        <asp:ListItem Value="VA" meta:resourcekey="ListItemResource99">Holy See (Vatican City State)</asp:ListItem>
                                                        <asp:ListItem Value="HN" meta:resourcekey="ListItemResource100">Honduras</asp:ListItem>
                                                        <asp:ListItem Value="HK" meta:resourcekey="ListItemResource101">Hong Kong</asp:ListItem>
                                                        <asp:ListItem Value="HU" meta:resourcekey="ListItemResource102">Hungary</asp:ListItem>
                                                        <asp:ListItem Value="IS" meta:resourcekey="ListItemResource103">Icel And</asp:ListItem>
                                                        <asp:ListItem Value="IN" meta:resourcekey="ListItemResource104">India</asp:ListItem>
                                                        <asp:ListItem Value="ID" meta:resourcekey="ListItemResource105">Indonesia</asp:ListItem>
                                                        <asp:ListItem Value="IR" meta:resourcekey="ListItemResource106">Iran (Islamic Republic Of)</asp:ListItem>
                                                        <asp:ListItem Value="IQ" meta:resourcekey="ListItemResource107">Iraq</asp:ListItem>
                                                        <asp:ListItem Value="IE" meta:resourcekey="ListItemResource108">Ireland</asp:ListItem>
                                                        <asp:ListItem Value="IL" meta:resourcekey="ListItemResource109">Israel</asp:ListItem>
                                                        <asp:ListItem Value="IT" meta:resourcekey="ListItemResource110">Italy</asp:ListItem>
                                                        <asp:ListItem Value="JM" meta:resourcekey="ListItemResource111">Jamaica</asp:ListItem>
                                                        <asp:ListItem Value="JP" meta:resourcekey="ListItemResource112">Japan</asp:ListItem>
                                                        <asp:ListItem Value="JO" meta:resourcekey="ListItemResource113">Jordan</asp:ListItem>
                                                        <asp:ListItem Value="KZ" meta:resourcekey="ListItemResource114">Kazakhstan</asp:ListItem>
                                                        <asp:ListItem Value="KE" meta:resourcekey="ListItemResource115">Kenya</asp:ListItem>
                                                        <asp:ListItem Value="KI" meta:resourcekey="ListItemResource116">Kiribati</asp:ListItem>
                                                        <asp:ListItem Value="KP" meta:resourcekey="ListItemResource117">Korea, Dem People'S Republic</asp:ListItem>
                                                        <asp:ListItem Value="KR" meta:resourcekey="ListItemResource118">Korea, Republic Of</asp:ListItem>
                                                        <asp:ListItem Value="KW" meta:resourcekey="ListItemResource119">Kuwait</asp:ListItem>
                                                        <asp:ListItem Value="KG" meta:resourcekey="ListItemResource120">Kyrgyzstan</asp:ListItem>
                                                        <asp:ListItem Value="LA" meta:resourcekey="ListItemResource121">Lao People'S Dem Republic</asp:ListItem>
                                                        <asp:ListItem Value="LV" meta:resourcekey="ListItemResource122">Latvia</asp:ListItem>
                                                        <asp:ListItem Value="LB" meta:resourcekey="ListItemResource123">Lebanon</asp:ListItem>
                                                        <asp:ListItem Value="LS" meta:resourcekey="ListItemResource124">Lesotho</asp:ListItem>
                                                        <asp:ListItem Value="LR" meta:resourcekey="ListItemResource125">Liberia</asp:ListItem>
                                                        <asp:ListItem Value="LY" meta:resourcekey="ListItemResource126">Libyan Arab Jamahiriya</asp:ListItem>
                                                        <asp:ListItem Value="LI" meta:resourcekey="ListItemResource127">Liechtenstein</asp:ListItem>
                                                        <asp:ListItem Value="LT" meta:resourcekey="ListItemResource128">Lithuania</asp:ListItem>
                                                        <asp:ListItem Value="LU" meta:resourcekey="ListItemResource129">Luxembourg</asp:ListItem>
                                                        <asp:ListItem Value="MO" meta:resourcekey="ListItemResource130">Macau</asp:ListItem>
                                                        <asp:ListItem Value="MK" meta:resourcekey="ListItemResource131">Macedonia</asp:ListItem>
                                                        <asp:ListItem Value="MG" meta:resourcekey="ListItemResource132">Madagascar</asp:ListItem>
                                                        <asp:ListItem Value="MW" meta:resourcekey="ListItemResource133">Malawi</asp:ListItem>
                                                        <asp:ListItem Value="MY" meta:resourcekey="ListItemResource134">Malaysia</asp:ListItem>
                                                        <asp:ListItem Value="MV" meta:resourcekey="ListItemResource135">Maldives</asp:ListItem>
                                                        <asp:ListItem Value="ML" meta:resourcekey="ListItemResource136">Mali</asp:ListItem>
                                                        <asp:ListItem Value="MT" meta:resourcekey="ListItemResource137">Malta</asp:ListItem>
                                                        <asp:ListItem Value="MH" meta:resourcekey="ListItemResource138">Marshall Islands</asp:ListItem>
                                                        <asp:ListItem Value="MQ" meta:resourcekey="ListItemResource139">Martinique</asp:ListItem>
                                                        <asp:ListItem Value="MR" meta:resourcekey="ListItemResource140">Mauritania</asp:ListItem>
                                                        <asp:ListItem Value="MU" meta:resourcekey="ListItemResource141">Mauritius</asp:ListItem>
                                                        <asp:ListItem Value="YT" meta:resourcekey="ListItemResource142">Mayotte</asp:ListItem>
                                                        <asp:ListItem Value="MX" meta:resourcekey="ListItemResource143">Mexico</asp:ListItem>
                                                        <asp:ListItem Value="FM" meta:resourcekey="ListItemResource144">Micronesia, Federated States</asp:ListItem>
                                                        <asp:ListItem Value="MD" meta:resourcekey="ListItemResource145">Moldova, Republic Of</asp:ListItem>
                                                        <asp:ListItem Value="MC" meta:resourcekey="ListItemResource146">Monaco</asp:ListItem>
                                                        <asp:ListItem Value="MN" meta:resourcekey="ListItemResource147">Mongolia</asp:ListItem>
                                                        <asp:ListItem Value="MS" meta:resourcekey="ListItemResource148">Montserrat</asp:ListItem>
                                                        <asp:ListItem Value="MA" meta:resourcekey="ListItemResource149">Morocco</asp:ListItem>
                                                        <asp:ListItem Value="MZ" meta:resourcekey="ListItemResource150">Mozambique</asp:ListItem>
                                                        <asp:ListItem Value="MM" meta:resourcekey="ListItemResource151">Myanmar</asp:ListItem>
                                                        <asp:ListItem Value="NA" meta:resourcekey="ListItemResource152">Namibia</asp:ListItem>
                                                        <asp:ListItem Value="NR" meta:resourcekey="ListItemResource153">Nauru</asp:ListItem>
                                                        <asp:ListItem Value="NP" meta:resourcekey="ListItemResource154">Nepal</asp:ListItem>
                                                        <asp:ListItem Value="NL" meta:resourcekey="ListItemResource155">Netherlands</asp:ListItem>
                                                        <asp:ListItem Value="AN" meta:resourcekey="ListItemResource156">Netherlands Ant Illes</asp:ListItem>
                                                        <asp:ListItem Value="NC" meta:resourcekey="ListItemResource157">New Caledonia</asp:ListItem>
                                                        <asp:ListItem Value="NZ" meta:resourcekey="ListItemResource158">New Zealand</asp:ListItem>
                                                        <asp:ListItem Value="NI" meta:resourcekey="ListItemResource159">Nicaragua</asp:ListItem>
                                                        <asp:ListItem Value="NE" meta:resourcekey="ListItemResource160">Niger</asp:ListItem>
                                                        <asp:ListItem Value="NG" meta:resourcekey="ListItemResource161">Nigeria</asp:ListItem>
                                                        <asp:ListItem Value="NU" meta:resourcekey="ListItemResource162">Niue</asp:ListItem>
                                                        <asp:ListItem Value="NF" meta:resourcekey="ListItemResource163">Norfolk Island</asp:ListItem>
                                                        <asp:ListItem Value="MP" meta:resourcekey="ListItemResource164">Northern Mariana Islands</asp:ListItem>
                                                        <asp:ListItem Value="NO" meta:resourcekey="ListItemResource165">Norway</asp:ListItem>
                                                        <asp:ListItem Value="OM" meta:resourcekey="ListItemResource166">Oman</asp:ListItem>
                                                        <asp:ListItem Value="PK" meta:resourcekey="ListItemResource167">Pakistan</asp:ListItem>
                                                        <asp:ListItem Value="PW" meta:resourcekey="ListItemResource168">Palau</asp:ListItem>
                                                        <asp:ListItem Value="PA" meta:resourcekey="ListItemResource169">Panama</asp:ListItem>
                                                        <asp:ListItem Value="PG" meta:resourcekey="ListItemResource170">Papua New Guinea</asp:ListItem>
                                                        <asp:ListItem Value="PY" meta:resourcekey="ListItemResource171">Paraguay</asp:ListItem>
                                                        <asp:ListItem Value="PE" meta:resourcekey="ListItemResource172">Peru</asp:ListItem>
                                                        <asp:ListItem Value="PH" meta:resourcekey="ListItemResource173">Philippines</asp:ListItem>
                                                        <asp:ListItem Value="PN" meta:resourcekey="ListItemResource174">Pitcairn</asp:ListItem>
                                                        <asp:ListItem Value="PL" meta:resourcekey="ListItemResource175">Poland</asp:ListItem>
                                                        <asp:ListItem Value="PT" meta:resourcekey="ListItemResource176">Portugal</asp:ListItem>
                                                        <asp:ListItem Value="PR" meta:resourcekey="ListItemResource177">Puerto Rico</asp:ListItem>
                                                        <asp:ListItem Value="QA" meta:resourcekey="ListItemResource178">Qatar</asp:ListItem>
                                                        <asp:ListItem Value="RE" meta:resourcekey="ListItemResource179">Reunion</asp:ListItem>
                                                        <asp:ListItem Value="RO" meta:resourcekey="ListItemResource180">Romania</asp:ListItem>
                                                        <asp:ListItem Value="RU" meta:resourcekey="ListItemResource181">Russian Federation</asp:ListItem>
                                                        <asp:ListItem Value="RW" meta:resourcekey="ListItemResource182">Rwanda</asp:ListItem>
                                                        <asp:ListItem Value="KN" meta:resourcekey="ListItemResource183">Saint K Itts And Nevis</asp:ListItem>
                                                        <asp:ListItem Value="LC" meta:resourcekey="ListItemResource184">Saint Lucia</asp:ListItem>
                                                        <asp:ListItem Value="VC" meta:resourcekey="ListItemResource185">Saint Vincent, The Grenadines</asp:ListItem>
                                                        <asp:ListItem Value="WS" meta:resourcekey="ListItemResource186">Samoa</asp:ListItem>
                                                        <asp:ListItem Value="SM" meta:resourcekey="ListItemResource187">San Marino</asp:ListItem>
                                                        <asp:ListItem Value="ST" meta:resourcekey="ListItemResource188">Sao Tome And Principe</asp:ListItem>
                                                        <asp:ListItem Value="SA" meta:resourcekey="ListItemResource189">Saudi Arabia</asp:ListItem>
                                                        <asp:ListItem Value="SN" meta:resourcekey="ListItemResource190">Senegal</asp:ListItem>
                                                        <asp:ListItem Value="SC" meta:resourcekey="ListItemResource191">Seychelles</asp:ListItem>
                                                        <asp:ListItem Value="SL" meta:resourcekey="ListItemResource192">Sierra Leone</asp:ListItem>
                                                        <asp:ListItem Value="SG" meta:resourcekey="ListItemResource193">Singapore</asp:ListItem>
                                                        <asp:ListItem Value="SK" meta:resourcekey="ListItemResource194">Slovakia (Slovak Republic)</asp:ListItem>
                                                        <asp:ListItem Value="SI" meta:resourcekey="ListItemResource195">Slovenia</asp:ListItem>
                                                        <asp:ListItem Value="SB" meta:resourcekey="ListItemResource196">Solomon Islands</asp:ListItem>
                                                        <asp:ListItem Value="SO" meta:resourcekey="ListItemResource197">Somalia</asp:ListItem>
                                                        <asp:ListItem Value="ZA" meta:resourcekey="ListItemResource198">South Africa</asp:ListItem>
                                                        <asp:ListItem Value="GS" meta:resourcekey="ListItemResource199">South Georgia , S Sandwich Is.</asp:ListItem>
                                                        <asp:ListItem Value="ES" meta:resourcekey="ListItemResource200">Spain</asp:ListItem>
                                                        <asp:ListItem Value="LK" meta:resourcekey="ListItemResource201">Sri Lanka</asp:ListItem>
                                                        <asp:ListItem Value="SH" meta:resourcekey="ListItemResource202">St. Helena</asp:ListItem>
                                                        <asp:ListItem Value="PM" meta:resourcekey="ListItemResource203">St. Pierre And Miquelon</asp:ListItem>
                                                        <asp:ListItem Value="SD" meta:resourcekey="ListItemResource204">Sudan</asp:ListItem>
                                                        <asp:ListItem Value="SR" meta:resourcekey="ListItemResource205">Suriname</asp:ListItem>
                                                        <asp:ListItem Value="SJ" meta:resourcekey="ListItemResource206">Svalbard, Jan Mayen Islands</asp:ListItem>
                                                        <asp:ListItem Value="SZ" meta:resourcekey="ListItemResource207">Sw Aziland</asp:ListItem>
                                                        <asp:ListItem Value="SE" meta:resourcekey="ListItemResource208">Sweden</asp:ListItem>
                                                        <asp:ListItem Value="CH" meta:resourcekey="ListItemResource209">Switzerland</asp:ListItem>
                                                        <asp:ListItem Value="SY" meta:resourcekey="ListItemResource210">Syrian Arab Republic</asp:ListItem>
                                                        <asp:ListItem Value="TW" meta:resourcekey="ListItemResource211">Taiwan</asp:ListItem>
                                                        <asp:ListItem Value="TJ" meta:resourcekey="ListItemResource212">Tajikistan</asp:ListItem>
                                                        <asp:ListItem Value="TZ" meta:resourcekey="ListItemResource213">Tanzania, United Republic Of</asp:ListItem>
                                                        <asp:ListItem Value="TH" meta:resourcekey="ListItemResource214">Thailand</asp:ListItem>
                                                        <asp:ListItem Value="TG" meta:resourcekey="ListItemResource215">Togo</asp:ListItem>
                                                        <asp:ListItem Value="TK" meta:resourcekey="ListItemResource216">Tokelau</asp:ListItem>
                                                        <asp:ListItem Value="TO" meta:resourcekey="ListItemResource217">Tonga</asp:ListItem>
                                                        <asp:ListItem Value="TT" meta:resourcekey="ListItemResource218">Trinidad And Tobago</asp:ListItem>
                                                        <asp:ListItem Value="TN" meta:resourcekey="ListItemResource219">Tunisia</asp:ListItem>
                                                        <asp:ListItem Value="TR" meta:resourcekey="ListItemResource220">Turkey</asp:ListItem>
                                                        <asp:ListItem Value="TM" meta:resourcekey="ListItemResource221">Turkmenistan</asp:ListItem>
                                                        <asp:ListItem Value="TC" meta:resourcekey="ListItemResource222">Turks And Caicos Islands</asp:ListItem>
                                                        <asp:ListItem Value="TV" meta:resourcekey="ListItemResource223">Tuvalu</asp:ListItem>
                                                        <asp:ListItem Value="UG" meta:resourcekey="ListItemResource224">Uganda</asp:ListItem>
                                                        <asp:ListItem Value="UA" meta:resourcekey="ListItemResource225">Ukraine</asp:ListItem>
                                                        <asp:ListItem Value="AE" meta:resourcekey="ListItemResource226">United Arab Emirates</asp:ListItem>
                                                        <asp:ListItem Value="GB" meta:resourcekey="ListItemResource227">United Kingdom</asp:ListItem>
                                                        <asp:ListItem Value="US" meta:resourcekey="ListItemResource228">United States</asp:ListItem>
                                                        <asp:ListItem Value="UM" meta:resourcekey="ListItemResource229">United States Minor Is.</asp:ListItem>
                                                        <asp:ListItem Value="UY" meta:resourcekey="ListItemResource230">Uruguay</asp:ListItem>
                                                        <asp:ListItem Value="UZ" meta:resourcekey="ListItemResource231">Uzbekistan</asp:ListItem>
                                                        <asp:ListItem Value="VU" meta:resourcekey="ListItemResource232">Vanuatu</asp:ListItem>
                                                        <asp:ListItem Value="VE" meta:resourcekey="ListItemResource233">Venezuela</asp:ListItem>
                                                        <asp:ListItem Value="VN" meta:resourcekey="ListItemResource234">Viet Nam</asp:ListItem>
                                                        <asp:ListItem Value="VG" meta:resourcekey="ListItemResource235">Virgin Islands (British)</asp:ListItem>
                                                        <asp:ListItem Value="VI" meta:resourcekey="ListItemResource236">Virgin Islands (U.S.)</asp:ListItem>
                                                        <asp:ListItem Value="WF" meta:resourcekey="ListItemResource237">Wallis And Futuna Islands</asp:ListItem>
                                                        <asp:ListItem Value="EH" meta:resourcekey="ListItemResource238">Western Sahara</asp:ListItem>
                                                        <asp:ListItem Value="YE" meta:resourcekey="ListItemResource239">Yemen</asp:ListItem>
                                                        <asp:ListItem Value="ZR" meta:resourcekey="ListItemResource240">Zaire</asp:ListItem>
                                                        <asp:ListItem Value="ZM" meta:resourcekey="ListItemResource241">Zambia</asp:ListItem>
                                                        <asp:ListItem Value="ZW" meta:resourcekey="ListItemResource242">Zimbabwe</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="ddlNationality" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                                <span class="clear"></span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div class="form_grid_12">
                                            <div class="form_input">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn_small btn_blue" Visible="False" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" />
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
