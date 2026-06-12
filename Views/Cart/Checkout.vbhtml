@ModelType My.Models.CheckoutViewModel
@Code
    ViewBag.Title = "結帳"
End Code

<h2>確認訂單</h2>
<hr />

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True, "", New With {.class = "alert alert-danger"})

    @<div class="row">
        <div class="col-md-7">
            <h5>收件資料</h5>
            <div class="mb-3">
                @Html.LabelFor(Function(m) m.ReceiverName, "收件人姓名", New With {.class = "form-label"})
                @Html.TextBoxFor(Function(m) m.ReceiverName, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.ReceiverName, "", New With {.class = "text-danger small"})
            </div>
            <div class="mb-3">
                @Html.LabelFor(Function(m) m.ReceiverPhone, "聯絡電話", New With {.class = "form-label"})
                @Html.TextBoxFor(Function(m) m.ReceiverPhone, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.ReceiverPhone, "", New With {.class = "text-danger small"})
            </div>
            <div class="mb-3">
                @Html.LabelFor(Function(m) m.ReceiverAddress, "收件地址", New With {.class = "form-label"})
                @Html.TextBoxFor(Function(m) m.ReceiverAddress, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.ReceiverAddress, "", New With {.class = "text-danger small"})
            </div>
            <div class="mb-3">
                @Html.LabelFor(Function(m) m.PaymentMethod, "付款方式", New With {.class = "form-label"})
                @Html.DropDownListFor(Function(m) m.PaymentMethod,
                    New SelectList(New List(Of String) From {"信用卡", "ATM轉帳", "貨到付款"}),
                    "-- 請選擇 --",
                    New With {.class = "form-select"})
                @Html.ValidationMessageFor(Function(m) m.PaymentMethod, "", New With {.class = "text-danger small"})
            </div>
            <div class="mb-3">
                @Html.LabelFor(Function(m) m.Remark, "備註", New With {.class = "form-label"})
                @Html.TextAreaFor(Function(m) m.Remark, New With {.class = "form-control", .rows = 3})
            </div>
        </div>
        <div class="col-md-5">
            <h5>訂單摘要</h5>
            <table class="table table-sm">
                @If Model.Cart IsNot Nothing Then
                    For Each item In Model.Cart.Items
                        @<tr>
                            <td>@item.ProductName x @item.Quantity</td>
                            <td class="text-end">NT$ @item.SubTotal.ToString("N0")</td>
                        </tr>
                    Next
                End If
                <tr class="fw-bold">
                    <td>合計</td>
                    <td class="text-end text-danger">NT$ @Model.Cart.TotalAmount.ToString("N0")</td>
                </tr>
            </table>
        </div>
    </div>
    @<button type="submit" class="btn btn-dark btn-lg">確認下單</button>
End Using
