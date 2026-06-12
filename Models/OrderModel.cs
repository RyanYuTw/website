using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        public string ReceiverPhone { get; set; }
        [Required]
        public string ReceiverAddress { get; set; }
        public string ReceiverEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ShippingFee { get; set; }
        public string PaymentMethod { get; set; }
        // Pending=待付款, Paid=已付款, Shipped=已出貨, Completed=完成, Cancelled=取消
        public string Status { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal
        {
            get { return UnitPrice * Quantity; }
        }
    }

    public class OrderListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string StatusFilter { get; set; }
    }
}
