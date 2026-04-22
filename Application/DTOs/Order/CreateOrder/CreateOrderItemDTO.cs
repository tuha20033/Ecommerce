namespace Application.DTOs.Order.CreateOrder
{
    /// <summary>
    /// Tạo đơn hàng 
    /// </summary>
    public class CreateOrderItemDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
