<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Farmat.farmat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Поиск по Фармат</title>
    <link rel="stylesheet" href="Styles.css"/>
    <style type="text/css">
        .tdTB {
            width: 70%;
            padding-right: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="body">
            <asp:TextBox ID="phoneTB" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#CCFFFF" ReadOnly="True" Width="100px"></asp:TextBox>
            <div class="search">
                <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="#333333" Text="Введите ключевое слово:"></asp:Label>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td class="tdTB">
                            <asp:TextBox ID="TextBox1" CssClass="TB" runat="server" Font-Size="Medium" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="Button1" CssClass="searchBTN" runat="server" Font-Size="Medium" Text="Найти" Width="100%" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="GridView1" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="number" HeaderText="№" />
                    <asp:BoundField DataField="city" HeaderText="Город" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="address" HeaderText="Адрес" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="brand" HeaderText="Брэнд" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                     <asp:BoundField DataField="legalFace" HeaderText="Юр.Лицо" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="WorkingHours" HeaderText="Время работы" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="phone" HeaderText="Номер телефона" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                         <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select" Text="Выбрать"   OnClick="Button2_Click" />
                         </ItemTemplate>
                        <HeaderStyle Width="65px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                </Columns>
                <HeaderStyle CssClass="header" />
                <PagerStyle CssClass="pager" />
                <RowStyle CssClass="rows" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
