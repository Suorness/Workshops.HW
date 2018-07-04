using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakApp
{
    public class MailClient
    {
        private byte[] data;

        public MailClient(MailService mailService)
        {
            mailService.NewMail += ShowMessage;
            data = new byte[4096];
        }

        private void ShowMessage(Object sender, MailEventArgs e)
        {
            Console.WriteLine("New mail!");
            Console.WriteLine(e.Message);
        }
    }
}
