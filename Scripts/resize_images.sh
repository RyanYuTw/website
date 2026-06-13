#!/bin/sh
# 依出現位置裁切圖片，產生各尺寸的變體
# 命名規則：原檔名_variant.ext
#   _list   → 列表縮圖
#   _detail → 詳細/文章大圖
#   _desktop / _mobile → banner

IMG=/app/Content/images

crop() {
    src="$1"; w="$2"; h="$3"; suffix="$4"
    [ -f "$src" ] || return
    base="${src%.*}"; ext="${src##*.}"
    convert "$src" \
        -resize "${w}x${h}^" \
        -gravity Center \
        -extent "${w}x${h}" \
        "${base}_${suffix}.${ext}"
}

# 商品圖：3:2 比例
# - 列表卡片 640×427 (SIZE_MOBILE)
# - 詳細頁大圖 1280×853 (SIZE_DESKTOP)
for f in "$IMG/products/"*; do
    [ -f "$f" ] || continue
    crop "$f" 640 427 "list"
    crop "$f" 1280 853 "detail"
done

# 部落格圖：16:9 比例
# - 列表縮圖 640×360 (SIZE_MOBILE)
# - 文章 header 1280×720 (SIZE_DESKTOP)
for f in "$IMG/blog/"*; do
    [ -f "$f" ] || continue
    crop "$f" 640 360 "list"
    crop "$f" 1280 720 "detail"
done

# 首頁 banner：8:3 比例
if [ -f "$IMG/banner.jpg" ]; then
    crop "$IMG/banner.jpg" 1280 480 "desktop"
    crop "$IMG/banner.jpg" 640  240 "mobile"
fi

# no-image placeholder
if [ -f "$IMG/no-image.png" ]; then
    crop "$IMG/no-image.png" 640  427 "list"
    crop "$IMG/no-image.png" 1280 853 "detail"
fi

echo "Image resize complete."
