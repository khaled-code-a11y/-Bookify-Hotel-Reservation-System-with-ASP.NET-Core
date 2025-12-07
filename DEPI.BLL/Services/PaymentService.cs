
using System.Net;
using System.Net.Mail;
using DEPI.BLL.DTOS;
using DEPI.DAL;
using Microsoft.EntityFrameworkCore;

namespace DEPI.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _dbContext;

        public PaymentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> ProcessPaymentAsync(PaymentDTO payment)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == payment.Email);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            string subject = "Payment Confirmation - AmunraHotel";
            string body =
            $@"Hello {user.Name} (National ID: {user.NationalId}),
            Your booking at AmunraHotel for Room #{payment.roomId} from {payment.startDate:yyyy-MM-dd} to {payment.endDate:yyyy-MM-dd} 
            will be paid using: {payment.PaymentMethod}.
            Thank you for choosing us! We hope you enjoy your stay.
            Best regards,
            AmunraHotel Team";


            using var client = new SmtpClient("smtp.gmail.com") 
            {
                Port = 587,
                Credentials = new NetworkCredential("abdullahelkashlan@gmail.com", "qmgj dozf lqlo aqwb"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("abdullahelkashlan@gmail.com", "AmunraHotel"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };
            mailMessage.To.Add(payment.Email);

            await client.SendMailAsync(mailMessage);

            return true; 
        }


    }
}
