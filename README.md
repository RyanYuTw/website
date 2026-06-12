# Wish Estate 許園

ASP.NET MVC 5 電商網站，使用 C# / .NET Framework 4.8，以 Mono + XSP4 在 Linux/Docker 上執行。

## 功能模組

| 模組 | 說明 |
|------|------|
| 會員 | 註冊、登入、修改密碼、個人資料 |
| 商品 | 商品列表、商品詳情 |
| 購物車 | 加入購物車、結帳流程 |
| 訂單 | 訂單列表、訂單詳情 |
| 部落格 | 文章列表、文章內頁 |
| 後台管理 | 商品 / 訂單管理（需管理員身份） |

## 技術規格

- **框架**：ASP.NET MVC 5.3 / Razor 3
- **語言**：C# (.NET Framework 4.8)
- **資料庫**：MSSQL Server（Entity Framework 6）
- **執行環境**：Mono 6 + XSP4（Docker）
- **密碼雜湊**：PBKDF2-SHA256（600k 次迭代）

## 本機開發

### 前置需求

- Visual Studio 2019 / 2022 或 Rider
- SQL Server（或 Docker 執行 MSSQL）

### 設定步驟

1. 複製設定範本：

   ```bash
   cp Web.config.example Web.config
   ```

2. 編輯 `Web.config`，填入資料庫連線字串與 SMTP 設定。

3. 還原 NuGet 套件：

   ```bash
   nuget restore packages.config -PackagesDirectory packages
   ```

4. 在 Visual Studio 開啟 `My.sln` 後執行。

## Docker 部署

```bash
# 建置映像
docker build -t wish-estate .

# 執行容器（傳入 DB 密碼）
docker run -d -p 8080:8080 \
  -e DB_PASSWORD=your_db_password \
  wish-estate
```

> 目前 `Web.config` 的連線字串密碼為空，部署時需手動替換或透過掛載設定檔傳入。

## 專案結構

```
Website/
├── App_Start/          # 路由、Filter、Bundle 設定
├── Controllers/        # MVC Controller
├── Helpers/            # 工具類別（加密、郵件、分頁）
├── Models/             # 資料模型與 ViewModel
├── Views/              # Razor (.cshtml) 視圖
├── Content/            # CSS
├── Scripts/            # JavaScript
├── Web.config          # 應用程式設定（勿提交含密碼版本）
├── Web.config.example  # 設定範本
├── Web.Release.config  # Release 環境轉換
├── My.csproj           # 專案檔
└── Dockerfile          # Docker 建置設定
```

## 注意事項

- `Web.config` 含有敏感設定，已加入 `.gitignore`，請以 `Web.config.example` 為範本建立本機設定。
- 密碼儲存格式為 `base64(salt):base64(hash)`，使用 `CryptoHelper.HashPassword()` 產生。
