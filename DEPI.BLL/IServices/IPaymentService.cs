
namespace DEPI.BLL.IServices
{
    public interface IPaymentService
    {
        Task<bool> ProcessPaymentAsync(PaymentDTO payment);
    }
}
