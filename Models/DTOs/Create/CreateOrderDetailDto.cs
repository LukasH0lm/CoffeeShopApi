namespace Models.DTOs.Create;

public class CreateOrderDetailDto
{
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }
}