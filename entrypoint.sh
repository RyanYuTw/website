#!/bin/sh
set -e

# 若無 Web.config（fresh clone），以範本複製
[ -f /app/Web.config ] || cp /app/Web.config.example /app/Web.config

# 注入執行期設定
sed -i "s|Password=YOUR_DB_PASSWORD;|Password=${DB_PASSWORD};|g" /app/Web.config
sed -i "s|Password=;|Password=${DB_PASSWORD};|g" /app/Web.config
sed -i "s|Data Source=localhost,1433|Data Source=${DB_HOST:-db},1433|g" /app/Web.config

exec xsp4 --port=8080 --address=0.0.0.0 --nonstop
