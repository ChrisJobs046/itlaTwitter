using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailSend
{
    public interface IEmailSender
    {
        Task SendMailAsync(Message message);
    }
}
