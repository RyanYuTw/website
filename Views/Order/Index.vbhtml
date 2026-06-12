@ModelType My.Models.OrderListViewModel
@Code
    ViewBag.Title = "我的訂單"
End Code

<h2>我的訂單</h2>
<hr />

<div class="mb-3">
    <a href="@Url.Action("Index")" class="btn btn-sm @If String.IsNullOrEmpty(Model.StatusFilter) Then "btn-dark" Else "btn-outline-dark" End If">全部</a>
    <a href="@Url.Action("Index", New With {.status = "Pending"})" class="btn btn-sm @If Model.StatusFilter = "Pending" Then "btn-dark" Else "btn-outline-dark" End If">待付款</a>
    <a href="@Url.Action("Index", New With {.status = "Paid"})" class="btn btn-sm @If Model.StatusFilter = "Paid" Then "btn-dark" Else "btn-outline-dark" End If">已付款</a>
    <a href="@Url.Action("Index", New With {.status = "Shipped"})" class="btn btn-sm @If Model.StatusFilter = "Shipped" Then "btn-dark" Else "btn-outline-dark" End If">已出貨</a>
    <a href="@Url.Action("Index", New With {.status = "Completed"})" class="btn btn-sm @If Model.StatusFilter = "Completed" Then "btn-dark" Else "btn-outline-dark" End If">已完成</a>
</div>

<div class="table-responsive">
    <table class="table">
        <thead>
            <tr>
                <th>訂單編號</th>
                <th>日期</th>
                <th>金額</th>
                <th>狀態</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            @If Model.Orders IsNot Nothing Then
                For Each o In Model.Orders
                    @<tr>
                        <td>@o.OrderNo</td>
                        <td>@o.OrderDate.ToString("yyyy/MM/dd")</td>
                        <td>NT$ @o.TotalAmount.ToString("N0")</td>
                        <td>@o.Status</td>
                        <td><a href="@Url.Action("Detail", New With {.id = o.Id})" class="btn btn-sm btn-outline-dark">查看</a></td>
                    </tr>
                Next
            Else
                @<tr><td colspan="5" class="text-center text-muted">尚無訂單記錄</td></tr>
            End If
        </tbody>
    </table>
</div>
