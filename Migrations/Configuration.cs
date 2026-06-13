using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MyWeb.Helpers;
using MyWeb.Models;

namespace MyWeb.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "MyWeb.Models.AppDbContext";
        }

        protected override void Seed(AppDbContext db)
        {
            SeedBlogCategories(db);
            SeedProductCategories(db);
            SeedMembers(db);
            SeedProducts(db);
            SeedBlogPosts(db);
            SeedOrders(db);
        }

        private void SeedBlogCategories(AppDbContext db)
        {
            db.BlogCategories.AddOrUpdate(x => x.Name,
                new BlogCategory { Name = "品牌故事", SortOrder = 1, IsActive = true },
                new BlogCategory { Name = "產品介紹", SortOrder = 2, IsActive = true },
                new BlogCategory { Name = "活動公告", SortOrder = 3, IsActive = true }
            );
            db.SaveChanges();
        }

        private void SeedProductCategories(AppDbContext db)
        {
            db.ProductCategories.AddOrUpdate(x => x.Name,
                new ProductCategory { Name = "精品咖啡", NameEn = "Specialty Coffee", SortOrder = 1, IsActive = true },
                new ProductCategory { Name = "手沖器具", NameEn = "Brewing Equipment", SortOrder = 2, IsActive = true },
                new ProductCategory { Name = "精選禮盒", NameEn = "Gift Set", SortOrder = 3, IsActive = true }
            );
            db.SaveChanges();
        }

        private void SeedMembers(AppDbContext db)
        {
            string adminPw = Environment.GetEnvironmentVariable("SEED_ADMIN_PASSWORD");
            string demoPw  = Environment.GetEnvironmentVariable("SEED_DEMO_PASSWORD");

            if (string.IsNullOrEmpty(adminPw) || string.IsNullOrEmpty(demoPw))
                throw new InvalidOperationException(
                    "請在環境變數設定 SEED_ADMIN_PASSWORD 與 SEED_DEMO_PASSWORD，" +
                    "不可使用預設帳號密碼。");

            db.Members.AddOrUpdate(x => x.Account,
                new Member
                {
                    Account = "admin",
                    Password = CryptoHelper.HashPassword(adminPw),
                    Name = "系統管理員",
                    Email = "admin@mywebsite.com",
                    Phone = "02-12345678",
                    Mobile = "0912345678",
                    Kind = "Admin",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1)
                },
                new Member
                {
                    Account = "demo",
                    Password = CryptoHelper.HashPassword(demoPw),
                    Name = "示範用戶",
                    Email = "demo@example.com",
                    Mobile = "0987654321",
                    Address = "台北市信義區信義路五段7號",
                    Birthday = new DateTime(1990, 6, 15),
                    Gender = "M",
                    Kind = "B2C",
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 3, 1)
                }
            );
            db.SaveChanges();
        }

        private void SeedProducts(AppDbContext db)
        {
            int coffeeId = db.ProductCategories.Where(x => x.Name == "精品咖啡").Select(x => x.Id).FirstOrDefault();
            int equipId  = db.ProductCategories.Where(x => x.Name == "手沖器具").Select(x => x.Id).FirstOrDefault();
            int giftId   = db.ProductCategories.Where(x => x.Name == "精選禮盒").Select(x => x.Id).FirstOrDefault();
            var now = DateTime.Now;

            db.Products.AddOrUpdate(x => x.Name,
                new Product
                {
                    Name = "衣索比亞 耶加雪菲 日曬", NameEn = "Ethiopia Yirgacheffe Natural",
                    CategoryId = coffeeId, Price = 480, SalePrice = 420,
                    Description = "帶有藍莓、草莓等熱帶水果香氣，甜感明亮，日曬處理法帶出飽滿醇厚的口感。",
                    Content = "<h5>產品特色</h5><p>耶加雪菲產區位於衣索比亞南部，海拔 1700–2200 公尺，是非洲咖啡的代名詞。日曬處理法讓咖啡果實在陽光下自然乾燥，使果糖充分滲透豆體，風味層次格外豐富。</p><h5>風味描述</h5><ul><li>前段：藍莓、草莓、熱帶水果</li><li>中段：玫瑰花香、茉莉</li><li>尾韻：黑巧克力、糖蜜</li></ul><h5>沖煮建議</h5><p>水溫 89–91°C，手沖粉水比 1:15，研磨度中細。冷卻後酸甜感更為明顯，適合冰滴或冷萃。</p><h5>商品規格</h5><ul><li>產地：衣索比亞 耶加雪菲 Kochere</li><li>處理法：日曬</li><li>烘焙度：中淺焙</li><li>容量：200g / 袋</li><li>有效期限：烘焙後 30 天內最佳</li></ul>",
                    Stock = 50, IsActive = true, IsRecommend = true, SortOrder = 1,
                    ImagePath = "/Content/images/products/black-gem-01.jpg",
                    CreatedAt = now, UpdatedAt = now
                },
                new Product
                {
                    Name = "哥倫比亞 花月夜 水洗", NameEn = "Colombia Huila Washed",
                    CategoryId = coffeeId, Price = 520,
                    Description = "柑橘、杏桃風味，酸質明亮細膩，尾韻帶有糖蜜甜感，均衡度極高。",
                    Content = "<h5>產品特色</h5><p>來自哥倫比亞 Huila 省的精品莊園，採用傳統水洗處理法，將咖啡豆的乾淨度與甜感完整呈現。花月夜批次由莊園主嚴選海拔 1800 公尺以上的成熟果實，品質穩定卓越。</p><h5>風味描述</h5><ul><li>前段：柑橘、血橙</li><li>中段：杏桃、白桃</li><li>尾韻：紅糖、蜂蜜</li></ul><h5>沖煮建議</h5><p>水溫 90–92°C，手沖粉水比 1:16，研磨度中研磨。均衡的酸甜比例，適合各種沖煮方式，新手首選。</p><h5>商品規格</h5><ul><li>產地：哥倫比亞 Huila</li><li>處理法：水洗</li><li>烘焙度：中焙</li><li>容量：200g / 袋</li><li>有效期限：烘焙後 30 天內最佳</li></ul>",
                    Stock = 40, IsActive = true, IsRecommend = true, SortOrder = 2,
                    ImagePath = "/Content/images/products/dawn-01.jpg",
                    CreatedAt = now, UpdatedAt = now
                },
                new Product
                {
                    Name = "巴拿馬 藝妓 蜜處理", NameEn = "Panama Geisha Honey",
                    CategoryId = coffeeId, Price = 1200,
                    Description = "珍稀藝妓品種，茉莉花香搭配桃子、玫瑰風味，複雜度與優雅感兼具。",
                    Content = "<h5>產品特色</h5><p>藝妓（Geisha）是咖啡界最珍稀的品種之一，原生於衣索比亞，在巴拿馬翡翠莊園發揚光大。本批次採用蜜處理，在果肉去除後保留部分果膠，讓風味介於日曬的果香與水洗的乾淨之間，複雜度極高。</p><h5>風味描述</h5><ul><li>前段：茉莉花、玫瑰水</li><li>中段：水蜜桃、荔枝</li><li>尾韻：蜂蜜、奶油糖</li></ul><h5>沖煮建議</h5><p>水溫 88–90°C，手沖粉水比 1:15，研磨度中細。建議使用陶瓷濾杯，保留完整香氣層次。數量稀少，每批次限量供應。</p><h5>商品規格</h5><ul><li>產地：巴拿馬 Boquete 翡翠莊園</li><li>處理法：蜜處理</li><li>烘焙度：淺焙</li><li>容量：100g / 袋（限量）</li><li>有效期限：烘焙後 21 天內最佳</li></ul>",
                    Stock = 20, IsActive = true, IsRecommend = false, SortOrder = 3,
                    ImagePath = "/Content/images/products/national-treasure-01.jpg",
                    CreatedAt = now, UpdatedAt = now
                },
                new Product
                {
                    Name = "Hario V60 手沖濾杯（紅）", NameEn = "Hario V60 Dripper Red",
                    CategoryId = equipId, Price = 380,
                    Description = "日本 Hario 經典 V60 陶瓷濾杯，01 號尺寸適合 1-2 杯，螺旋溝槽設計穩定萃取。",
                    Content = "<h5>產品特色</h5><p>Hario V60 是全球手沖咖啡師最常使用的濾杯之一，以 60 度錐形角度設計聞名。陶瓷材質保溫性佳，螺旋溝槽引導水流均勻通過咖啡粉層，讓萃取更穩定一致。</p><h5>規格說明</h5><ul><li>型號：VDC-01R（01 號，1–2 杯份）</li><li>材質：高品質陶瓷</li><li>顏色：紅色</li><li>尺寸：直徑 11.5 × 高度 8.2 cm</li><li>重量：約 148g</li><li>適用濾紙：Hario V60 01 號圓錐形濾紙</li></ul><h5>使用建議</h5><p>使用前以熱水預熱濾杯，可減少溫度流失對萃取的影響。搭配細口手沖壺控制注水速度，穩定出杯品質。</p><h5>清潔與保養</h5><p>使用後以清水沖洗即可，避免使用鋼刷。陶瓷材質耐用，正常使用下可長期保持光亮。</p>",
                    Stock = 30, IsActive = true, IsRecommend = false, SortOrder = 1,
                    ImagePath = "/Content/images/products/dripcoffee1.png",
                    CreatedAt = now, UpdatedAt = now
                },
                new Product
                {
                    Name = "手沖咖啡入門組", NameEn = "Pour Over Starter Kit",
                    CategoryId = giftId, Price = 1580, SalePrice = 1380,
                    Description = "包含 V60 濾杯、細口手沖壺、濾紙 40 入、衣索比亞精品豆 100g，新手必備。",
                    Content = "<h5>組合內容</h5><ul><li>Hario V60 陶瓷濾杯 01 號 × 1</li><li>細口不鏽鋼手沖壺 350ml × 1</li><li>Hario V60 01 號濾紙 × 40 張</li><li>衣索比亞 耶加雪菲 日曬豆 100g × 1</li><li>沖煮說明卡 × 1</li></ul><h5>適合對象</h5><p>首次接觸手沖咖啡的初學者、想送朋友入門咖啡的好禮，也適合想建立家庭咖啡角落的咖啡愛好者。</p><h5>入門沖煮步驟</h5><ol><li>折疊濾紙放入濾杯，以熱水潤濕濾紙並預熱杯子</li><li>放入 12g 中細研磨咖啡粉</li><li>以 90°C 熱水先注入 30ml 悶蒸 30 秒</li><li>緩慢繞圈注水至 180ml，總時間約 2.5 分鐘</li></ol><h5>禮盒包裝</h5><p>附精美牛皮紙禮盒，適合節慶送禮或自用。</p>",
                    Stock = 15, IsActive = true, IsRecommend = true, SortOrder = 1,
                    ImagePath = "/Content/images/products/pour-over-kit.png",
                    CreatedAt = now, UpdatedAt = now
                },
                new Product
                {
                    Name = "節日咖啡禮盒（三款豆）", NameEn = "Holiday Coffee Gift Set",
                    CategoryId = giftId, Price = 1280,
                    Description = "精選三款產區豆各 100g，附精美禮盒包裝與沖煮說明卡，送禮自用兩相宜。",
                    Content = "<h5>禮盒內容</h5><ul><li>衣索比亞 耶加雪菲 日曬 100g</li><li>哥倫比亞 花月夜 水洗 100g</li><li>巴拿馬 藝妓 蜜處理 100g</li><li>產區風味說明卡 × 3</li><li>精美禮盒包裝（可選附提袋）</li></ul><h5>產品特色</h5><p>三款豆涵蓋非洲、中南美洲，並包含日曬、水洗、蜜處理三種不同處理法，是認識精品咖啡產區風味的最佳入門禮組。</p><h5>適合場合</h5><ul><li>節慶送禮：尾牙、春節、聖誕節</li><li>商務伴手禮</li><li>探索不同產區風味</li></ul><h5>注意事項</h5><p>豆子均為新鮮烘焙後 7 天內出貨，建議收到後盡快開封享用，最佳賞味期為烘焙後 30 天內。</p>",
                    Stock = 25, IsActive = true, IsRecommend = true, SortOrder = 2,
                    ImagePath = "/Content/images/products/gift-set-01.jpg",
                    CreatedAt = now, UpdatedAt = now
                }
            );
            db.SaveChanges();
        }

        private void SeedBlogPosts(AppDbContext db)
        {
            int storyId   = db.BlogCategories.Where(x => x.Name == "品牌故事").Select(x => x.Id).FirstOrDefault();
            int productId = db.BlogCategories.Where(x => x.Name == "產品介紹").Select(x => x.Id).FirstOrDefault();
            int eventId   = db.BlogCategories.Where(x => x.Name == "活動公告").Select(x => x.Id).FirstOrDefault();

            db.BlogPosts.AddOrUpdate(x => x.Title,
                new BlogPost
                {
                    Title = "從一杯咖啡開始的故事",
                    CategoryId = storyId,
                    Summary = "創辦人如何從一次偶然的衣索比亞豆體驗，開啟了精品咖啡的旅程。",
                    Content = "<p>2018 年，創辦人在一場咖啡展中第一次喝到耶加雪菲日曬豆，那藍莓與黑醋栗交織的香氣徹底改變了對咖啡的認知……</p>",
                    Author = "創辦人 Ryan", IsPublished = true,
                    PublishedAt = new DateTime(2026, 1, 10),
                    CreatedAt = new DateTime(2026, 1, 10), UpdatedAt = new DateTime(2026, 1, 10),
                    Tags = "品牌,故事,起源",
                    ImagePath = "/Content/images/blog/coffee-show.jpg"
                },
                new BlogPost
                {
                    Title = "如何挑選適合自己的手沖濾杯",
                    CategoryId = productId,
                    Summary = "V60、Kalita Wave、Chemex 三款經典濾杯完整比較，幫你找到最適合的選擇。",
                    Content = "<p>手沖濾杯看似簡單，但不同的孔洞設計與溝槽結構會大幅影響萃取曲線……</p>",
                    Author = "咖啡師 Celine", IsPublished = true,
                    PublishedAt = new DateTime(2026, 2, 5),
                    CreatedAt = new DateTime(2026, 2, 5), UpdatedAt = new DateTime(2026, 2, 5),
                    Tags = "器具,手沖,濾杯",
                    ImagePath = "/Content/images/blog/dripper-guide.jpg"
                },
                new BlogPost
                {
                    Title = "2026 春季新豆上架：巴拿馬藝妓",
                    CategoryId = eventId,
                    Summary = "本季限量引進巴拿馬翡翠莊園藝妓，數量有限，先到先得！",
                    Content = "<p>每年春季是藝妓豆的採收季節，今年我們有幸取得翡翠莊園 BOP 等級藝妓……</p>",
                    Author = "採購 Tim", IsPublished = true,
                    PublishedAt = new DateTime(2026, 3, 1),
                    CreatedAt = new DateTime(2026, 3, 1), UpdatedAt = new DateTime(2026, 3, 1),
                    Tags = "新品,藝妓,限量",
                    ImagePath = "/Content/images/blog/new-arrival.jpg"
                },
                new BlogPost
                {
                    Title = "咖啡沖煮水溫完全指南",
                    CategoryId = productId,
                    Summary = "88°C 還是 93°C？不同豆種、烘焙度的最佳沖煮水溫一次說清楚。",
                    Content = "<p>水溫是影響萃取的關鍵變數之一，過高容易苦澀，過低則萃取不足……</p>",
                    Author = "咖啡師 Celine", IsPublished = false,
                    CreatedAt = new DateTime(2026, 4, 20), UpdatedAt = new DateTime(2026, 4, 20),
                    Tags = "沖煮,技巧,水溫",
                    ImagePath = "/Content/images/blog/brewing-temp.jpg"
                }
            );
            db.SaveChanges();
        }

        private void SeedOrders(AppDbContext db)
        {
            if (db.Orders.Any()) return;

            int memberId = db.Members.Where(x => x.Account == "demo").Select(x => x.Id).FirstOrDefault();
            if (memberId == 0) return;

            var p1 = db.Products.Where(x => x.Name.Contains("耶加雪菲")).FirstOrDefault();
            var p2 = db.Products.Where(x => x.Name.Contains("禮盒")).FirstOrDefault();
            if (p1 == null || p2 == null) return;

            db.Orders.Add(new Order
            {
                OrderNo = "ORD20260301001",
                MemberId = memberId,
                OrderDate = new DateTime(2026, 3, 15),
                ReceiverName = "示範用戶",
                ReceiverPhone = "0987654321",
                ReceiverAddress = "台北市信義區信義路五段7號",
                ReceiverEmail = "demo@example.com",
                TotalAmount = p1.Price + p2.Price,
                ShippingFee = 0,
                PaymentMethod = "ATM",
                Status = "Completed",
                CreatedAt = new DateTime(2026, 3, 15),
                UpdatedAt = new DateTime(2026, 3, 16),
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = p1.Id, ProductName = p1.Name, UnitPrice = p1.Price, Quantity = 1 },
                    new OrderItem { ProductId = p2.Id, ProductName = p2.Name, UnitPrice = p2.Price, Quantity = 1 }
                }
            });
            db.SaveChanges();
        }
    }
}
