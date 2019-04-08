<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory.Master" AutoEventWireup="true" CodeBehind="StoreInsert.aspx.cs" Inherits="Inventory.UI.StoreInsert" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>添加仓库信息</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="dropdown-toggle" data-toggle="dropdown" href="form_basic.html#">
                                <i class="fa fa-wrench"></i>
                            </a>
                            <ul class="dropdown-menu dropdown-user">
                                <li><a href="form_basic.html#">选项1</a>
                                </li>
                                <li><a href="form_basic.html#">选项2</a>
                                </li>
                            </ul>
                            <a class="close-link">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content" style="height: 450px">
                        <form method="get" class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">仓库编号</label>

                                <div class="col-sm-10">
                                    <%--<input type="text" class="form-control" name="gno" >--%>
                                    <input id="txtstno" type="text" runat="server" minlength="3" maxlength="3" required class="form-control" name="stno" aria-required="true">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">仓库地址</label>
                                <div class="col-sm-10">
                                    <input id="address" type="text" runat="server" class="form-control" name="address">
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">联系方式</label>

                                <div class="col-sm-10">
                                    <input id="telephone" runat="server" class="form-control" name="telephone">
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">库存量</label>

                                <div class="col-sm-10">
                                    <input id="capacity" runat="server" type="text" class="form-control" name="capacity">
                                </div>
                            </div>

                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button runat="server" Text="添加" ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>

                                    <%--<asp:Button  runat="server" Text="删除" ID="btndelete"  cssclass="btn btn-primary" OnClick="btndelete_Click" />--%>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
