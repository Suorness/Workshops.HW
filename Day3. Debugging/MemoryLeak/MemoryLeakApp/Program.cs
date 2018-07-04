using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailService = new MailService();

            for (int i = 0; i < 1000; i++)
            {
                new MailClient(mailService);
                mailService.CreateMail(String.Format("Memory leak is {0} byte", 4096*i));
            }

            while (true) { }
        }
    }
}
