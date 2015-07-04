<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderCreation.aspx.cs" Inherits="sfloor_pages_OrderCreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Creation</title>
    <style>
        .oc_cont * {
            box-sizing: border-box;
        }
        .oc_cont {
            font-family:Calibri
        }
        h1 {color: #657665;
    letter-spacing: 7px;
    text-align: center;
    text-decoration: underline;
    word-spacing: 10px;
        }
            .oc_cont table tr th {
                border: 1px solid #fff;
            }
        .oc_cont table {
            border-collapse:collapse;
            max-width:1200px;margin: auto;
            width:100%; text-align:center
        }
            .oc_cont table td {
                padding: 5px;
            }
            .oc_cont tr:first-child {background:#000; color:#fff; font-size:18px}
            .oc_cont tr:nth-child(even) {
                background:#efefef
            }
            .oc_cont input {
                padding: 5px 10px;
                width: 100%;
            }
            .oc_cont tr:last-child {
                background: #ccc;
            }
            .oc_cont .add {background:url('../new-images/btn_window_close.gif') no-repeat;
                           width:10px; height:20px
            }
        .print a {
              background: #ff6a00 none repeat scroll 0 0;
    border: medium none;
    box-shadow: 1px 1px 4px 1px #ccc;
    color: #fff;
    padding: 5px 20px;
    text-decoration: none;
        }
        .print {
            margin-top: 50px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="oc_cont">
        <h1>Order Creation Form</h1>

        <table>
            <tr>
                <th>Sl. No.</th>
                <th>Product Name</th>
                <th>Price</th>
                <th>Quantity</th>
                <th>Total Price</th>
                <th>Action</th>
            </tr>
            <tr>
                <td>1</td>
                <td>
                    <input type="text" placeholder="Type product name"/>
                </td>
                <td>
                    <input type="text" placeholder="Price" disabled="disabled"/>
                </td>
                <td>
                    <input type="text" placeholder="Type Quantity"/>
                </td>
                <td>
                    <input type="text" placeholder="Type product name" disabled="disabled"/>
                </td>
                <td>
                    <a href="#add" class="add">Add</a>
                    <a href="#edit" class="edit">Edit</a>
                    <a href="#del" class="delete">Delete</a>
                </td>
            </tr>
            <tr>
                <th colspan="4">Sub Total</th>
                <th>2000.00</th>
                <th></th>
            </tr>

        </table>

        <div class="print">
              <a href="#printpreview">Print Preview</a>
              <a href="#print">Print Invoice</a>
        </div>

    </div>
    </form>
</body>
</html>
