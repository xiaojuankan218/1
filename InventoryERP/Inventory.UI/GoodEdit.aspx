<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory.Master" AutoEventWireup="true" CodeBehind="GoodEdit.aspx.cs" Inherits="Inventory.UI.GoodEdit"   EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>添加商品信息</h5>
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
                                <label class="col-sm-2 control-label">商品编号</label>

                                <div class="col-sm-10">
                                    <%--<input type="text" class="form-control" name="gno" >--%>
                                    <input id="txtgno" type="text" runat="server" minlength="6" maxlength="6" required class="form-control" name="gno" disabled="true" aria-required="true">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">商品名称</label>
                                <div class="col-sm-10">
                                    <input id="gname" type="text" runat="server" class="form-control" name="gname">
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">商品价格</label>

                                <div class="col-sm-10">
                                    <input id="price" runat="server" class="form-control" name="price">
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">商品生厂商</label>

                                <div class="col-sm-10">
                                    <input id="producer" runat="server" type="text" class="form-control" name="producer">
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
