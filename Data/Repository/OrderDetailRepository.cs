using Models;

namespace Data.Repository.Interfaces;

public class OrderDetailRepository : IOrderDetailRepository
{
    private List<OrderDetail> orderDetails = new List<OrderDetail>();

    public OrderDetail GetOrderDetailById(Guid orderDetailId)
    {
        return orderDetails.FirstOrDefault(od => od.OrderDetailId == orderDetailId);
    }

    public IEnumerable<OrderDetail> GetAllOrderDetails()
    {
        return orderDetails;
    }

    public void AddOrderDetail(OrderDetail orderDetail)
    {
        orderDetails.Add(orderDetail);
    }

    public void UpdateOrderDetail(OrderDetail orderDetail)
    {
        var index = orderDetails.FindIndex(od => od.OrderDetailId == orderDetail.OrderDetailId);
        orderDetails[index] = orderDetail;
    }

    public void DeleteOrderDetail(Guid orderDetailId)
    {
        orderDetails.RemoveAll(od => od.OrderDetailId == orderDetailId);
    }
}