namespace Application.DTOs.Order.ViewOrder
{
    /// <summary>
    /// Hiển thị sản phẩm trong đơn hàng 
    /// </summary>
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPrice => (UnitPrice * Quantity) - DiscountAmount;
    }
}
