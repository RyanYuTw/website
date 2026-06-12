using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyWeb.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal
        {
            get { return UnitPrice * Quantity; }
        }
    }

    public class CartViewModel
    {
        public List<CartItem> Items { get; set; }
        public decimal TotalAmount
        {
            get
            {
                if (Items == null) return 0;
                return Items.Sum(x => x.SubTotal);
            }
        }
        public int TotalQty
        {
            get
            {
                if (Items == null) return 0;
                return Items.Sum(x => x.Quantity);
            }
        }
    }

    public class CheckoutViewModel
    {
        public CartViewModel Cart { get; set; }
        [Required(ErrorMessage = "收件人姓名為必填")]
        public string ReceiverName { get; set; }
        [Required(ErrorMessage = "收件人電話為必填")]
        public string ReceiverPhone { get; set; }
        [Required(ErrorMessage = "收件地址為必填")]
        public string ReceiverAddress { get; set; }
        public string ReceiverEmail { get; set; }
        [Required(ErrorMessage = "請選擇付款方式")]
        public string PaymentMethod { get; set; }
        public string Remark { get; set; }
    }
}
