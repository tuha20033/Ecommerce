namespace Application.DTOs;

public class OrderDTO
{
    public Guid Id { get; set; }
    public string OrderCode { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal ShippingFee { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Note { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItemDTO> Items { get; set; } = new();
}

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
