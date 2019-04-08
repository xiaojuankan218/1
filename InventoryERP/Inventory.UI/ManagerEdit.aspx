<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory.Master" AutoEventWireup="true" CodeBehind="ManagerEdit.aspx.cs" Inherits="Inventory.UI.ManagerEdit" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>修改管理员信息</h5>
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
                                <label class="col-sm-2 control-label">管理员编号</label>

                                <div class="col-sm-10">
                                    <%--<input type="text" class="form-control" name="gno" >--%>
                                    <input id="txtmno" type="text" runat="server" minlength="3" maxlength="3" required class="form-control" name="mno" disabled="true" aria-required="true">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">姓名</label>
                                <div class="col-sm-10">
                                    <input id="mname" type="text" runat="server" class="form-control" name="mname">
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">性别</label>

                                <div class="col-sm-10">
                                    <asp:DropDownList runat="server" ID="ddlsex" CssClass="form-control">
                                        <asp:ListItem Value="男" Text="男"></asp:ListItem>
                                        <asp:ListItem Value="女" Text="女"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">出生日期</label>

                                <div class="col-sm-10">
                                    <input id="birthday" runat="server" type="text" class="form-control" name="birthday">
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">管理仓库编号</label>

                                <div class="col-sm-10">
                                    <asp:DropDownList runat="server" ID="stno" ClientIDMode="Static" CssClass="form-control"/>
                                    <%--<input id="stno" runat="server" type="text" class="form-control" name="stno">--%>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button runat="server" Text="修改" ID="btnEdit" CssClass="btn btn-primary" OnClick="btnEdit_Click" />

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
