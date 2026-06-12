@Code
    ViewBag.Title = "訂單完成"
End Code

<div class="text-center py-5">
    <h2 class="text-success">&#10003; 訂單已成功送出！</h2>
    <p class="lead mt-3">感謝您的購買，我們將盡快為您處理訂單。</p>
    <div class="mt-4">
        <a href="@Url.Action("Index", "Order")" class="btn btn-outline-dark me-2">查看訂單</a>
        <a href="@Url.Action("Index", "Home")" class="btn btn-dark">返回首頁</a>
    </div>
</div>
