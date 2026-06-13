#!/bin/sh
set -e

# 若無 Web.config（fresh clone），以範本複製
[ -f /app/Web.config ] || cp /app/Web.config.example /app/Web.config

# 注入執行期設定（用 awk 避免密碼含特殊字元時 sed 跳脫問題）
awk -v pw="${DB_PASSWORD}" '{ gsub(/\$\{DB_PASSWORD\}/, pw) } 1' /app/Web.config > /tmp/Web.config.tmp && mv /tmp/Web.config.tmp /app/Web.config
awk -v host="${DB_HOST:-db}" '{ gsub(/localhost,1433/, host",1433") } 1' /app/Web.config > /tmp/Web.config.tmp && mv /tmp/Web.config.tmp /app/Web.config

# 讓 Mono 從 bin/ 找到 ASP.NET MVC 組件
export MONO_PATH=/app/bin${MONO_PATH:+:$MONO_PATH}

exec xsp4 --port=8080 --address=0.0.0.0 --nonstop
