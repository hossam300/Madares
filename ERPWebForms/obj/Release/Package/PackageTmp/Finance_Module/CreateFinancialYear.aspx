<%@ Page Title="" Language="C#" MasterPageFile="~/Finance_Module/AccountingMasterPage.master" AutoEventWireup="true" CodeBehind="CreateFinancialYear.aspx.cs" Inherits="ERPWebForms.Finance_Module.CreateFinancialYear" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div id="content">
           <div class="grid_container">
				<div class="grid_12">
				<div class="widget_wrap">
					<div class="widget_top">
						<span class="h_icon list"></span>
						<h6><asp:Label ID="lblHeader" runat="server" Text="Create Financial Year" meta:resourcekey="lblHeaderResource1" ></asp:Label></h6>
					</div>
					<div class="widget_content">
						<div  id="form103" class="form_container left_label valid_tip">
                         <div>
                             <br />
                         </div>
                             <fieldset  style="border:1px solid">	
	                        <legend><asp:Label ID="Label1" runat="server" Text="Financial Year Information" meta:resourcekey="Label1Resource1" ></asp:Label></legend>
							<ul>
								<li>
								<div class="form_grid_12">
									<label class="field_title"><asp:Label ID="Label2" runat="server" Text="Financial Year Name" meta:resourcekey="Label2Resource1" ></asp:Label></label>
									<div class="form_input">
										<div class="form_grid_4 alpha">
											<asp:TextBox ID="txtYearName" placeholder="Year Name" runat="server" type="text" tabindex="1" class="limiter required" meta:resourcekey="txtYearNameResource1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtYearName"></asp:RequiredFieldValidator></div>
										<span class="clear"></span>
									</div>
								</div>
								</li>
								<li>
								<div class="form_grid_12">
									<label class="field_title"><asp:Label ID="Label3" runat="server" Text="Start Date" meta:resourcekey="Label3Resource1" ></asp:Label></label>
									<div class="form_input">
										<div class="form_grid_4 alpha">
											<asp:TextBox ID="txtStartDate" placeholder="Start Date" runat="server" type="text" tabindex="1" class="limiter required" meta:resourcekey="txtStartDateResource1"></asp:TextBox>
										<cc1:CalendarExtender ID ="CCStartDate" runat ="server" TargetControlID ="txtStartDate" BehaviorID="CCStartDate"   Format="dd/MM/yyyy"/>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtStartDate"></asp:RequiredFieldValidator></div>    	
											<label class="field_title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="End Date" meta:resourcekey="Label4Resource1" ></asp:Label></label>
										<div class="form_grid_4">
												<asp:TextBox ID="txtEndDate" placeholder="End Date" runat="server" type="text" tabindex="1" class="limiter required" meta:resourcekey="txtEndDateResource1"></asp:TextBox>
										<cc1:CalendarExtender ID ="CCEndDate" runat ="server" TargetControlID ="txtEndDate" BehaviorID="CCEndDate"  Format="dd/MM/yyyy"/>
											 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEndDate"></asp:RequiredFieldValidator></div>
										</div>
										<span class="clear"></span>
									</div>
								</li>
                                <li>
								<div class="form_grid_12">
									<label class="field_title"><asp:Label ID="Label5" runat="server" Text="Description" meta:resourcekey="Label5Resource1" ></asp:Label> </label>
									<div class="form_input" >
                                        	<div class="form_grid_8">
										<asp:TextBox id="txtDesc" Width="94%" runat="server" TextMode ="MultiLine" Columns="5"  tabindex="4" meta:resourcekey="txtDescResource1"></asp:TextBox>
									</div>
                                        </div>
								</div>
								</li>
                                </ul>
                                  </fieldset>
                            <ul>
                                <li>
                                    <div class="form_grid_12">
									<div class="form_input">
                                         <asp:Button ID="btnEdit" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';"   UseSubmitBehavior="false"  runat="server" Text="Edit"  class="btn_small btn_blue" Visible="False"  OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1"  />
                                        <asp:Button ID="btnSave" OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';"   UseSubmitBehavior="false"  runat="server" Text="Save" class="btn_small btn_blue" meta:resourcekey="Button1Resource1" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn_small btn_orange" meta:resourcekey="Button2Resource1" CausesValidation="False" OnClick="btnCancel_Click"/>
                                        </div>
                                        </div>
                                </li>
                            </ul>
						</div>
					</div>
                    </div>
                    </div>
               </div>
           </div>
</asp:Content>