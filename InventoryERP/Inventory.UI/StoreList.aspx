﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory.Master" AutoEventWireup="true" CodeBehind="StoreList.aspx.cs" Inherits="Inventory.UI.StoreList" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
            <div class="ibox-content">
                <div class="row row-lg">
                    <div class="col-sm-6">
                        <!-- Example Classes -->
                        <div class="example-wrap">
                            <h4 class="example-title">仓库信息</h4>
                            <div class="example">
                                <table data-toggle="table" data-classes="table table-hover table-condensed" data-url="js/demo/table_base.json" data-striped="true" data-height="250" data-mobile-responsive="true">
                                    <thead>
                                        <tr>
                                            <th data-field="stno">仓库编号</th>
                                            <th data-field="address">仓库地址</th>
                                            <th data-field="telephone">联系方式</th>
                                            <th data-field="capacity">库存量</th>
                                            <th data-field="operation">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        
                                     <asp:Repeater ID="Repeater1" runat="server">
                                         <ItemTemplate>
                                             <tr>
                                                 <td>
                                                     <%# Eval("stno") %>
                                                 </td>
                                                 <td>
                                                     <%# Eval("address") %>
                                                 </td>
                                                 <td>
                                                     <%# Eval("telephone") %>
                                                 </td>
                                                 <td>
                                                     <%# Eval("capacity") %>
                                                 </td>
                                                 <td>
                                                     <a  class="btn btn-info" href="StoreEdit.aspx?stno=<%#  Eval("stno") %>">
                                                         <i class="fa fa-paste">修改</i>
                                                     </a>|
                                                     <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" CommandArgument='<%# Eval("stno") %>' CommandName="Delete" OnClientClick="javascript:return confirm('请再次确认是否删除该商品!','系统提示');"  OnClick="LinkButton1_Click">
                                                         <i class="fa fa-times"></i>
                                                         删除
                                                     </asp:LinkButton>
                                                 </td>
                                             </tr>
                                         </ItemTemplate>
                                     </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <!-- End Example Classes -->
                    </div>
                    </div>
                </div>
         </div>
     <script src="js/content.min.js?v=1.0.0"></script>
    <script src="js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="js/demo/bootstrap-table-demo.min.js"></script>
     <script type="text/javascript" src="http://tajs.qq.com/stats?sId=9051096" charset="UTF-8"></script>

</asp:Content>
