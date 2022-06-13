using ElearningApplication.Interfaces.Email;
using ElearningApplication.Models.Email;
using MailKit.Net.Smtp;
using MimeKit;

namespace ElearningApplication.Services;

public class MailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;
    private ILogger<MailSender> _logger;

    public MailSender(EmailConfiguration emailConfig, ILogger<MailSender> logger)
    {
        _emailConfig = emailConfig;
        _logger = logger;
    }

    public async Task sendEmailAsync(MessageModel message,string otp)
    {
        MimeMessage email = CreateEmailMessage(message,otp);

        await SendAsync(email);
    }

    private MimeMessage CreateEmailMessage(MessageModel message,string otp)
    {
        var emailMessage = new MimeMessage();
        emailMessage.Sender = MailboxAddress.Parse(_emailConfig.From);
        //emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
        emailMessage.To.Add(message.To[0]);
        emailMessage.Subject = message.Subject;


        string format =
            "<div style='width: 100%;'>"+
            "<p align='center' style='font-size: 20px;'>{0}</p>"+
            "<h3 style='color: red;font-size:22px;text-align: center;text-transform: uppercase;'>{1}</h3>"+
            "</div>";

        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = string.Format(format,message.Content,otp)
        };

        return emailMessage;
    }

    private async Task SendAsync(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                await client.SendAsync(mailMessage);

                _logger.LogInformation("email was sent successfully");
            }
            catch (Exception ex)
            {
                
                //log an error message or throw an exception, or both.
                _logger.LogError(ex.Message,"123");
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}