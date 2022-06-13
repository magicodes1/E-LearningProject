using ElearningApplication.Models.Email;

namespace ElearningApplication.Interfaces.Email;

public interface IEmailSender
{
    Task sendEmailAsync(MessageModel message,string otp);
}