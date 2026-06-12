@Code
    ViewBag.Title = "首頁"
End Code

<section class="hero bg-light py-5 mb-4">
    <div class="text-center">
        <h1>Wish Estate 許園</h1>
        <p class="lead">頂級咖啡與生活選品</p>
        <a href="@Url.Action("Index", "Product")" class="btn btn-dark btn-lg">探索商品</a>
    </div>
</section>

<section class="mb-5">
    <h2 class="mb-3">精選商品</h2>
    <div class="row">
        <p class="text-muted">（商品將從資料庫載入）</p>
    </div>
</section>

<section class="mb-5">
    <h2 class="mb-3">最新文章</h2>
    <div class="row">
        <p class="text-muted">（文章將從資料庫載入）</p>
    </div>
</section>
