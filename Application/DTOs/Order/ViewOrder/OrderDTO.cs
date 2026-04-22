namespace Application.DTOs.Order.ViewOrder;
/// <summary>
/// xem danh sách đơn hàng 
/// </summary>
public class OrderDTO
{
    public Guid Id { get; set; }
    public string OrderCode { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
}


