using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakApp
{
    public sealed class MailEventArgs : EventArgs
    {
        private readonly string _message;

        public MailEventArgs(string message)
        {
            _message = message;
        }

        public string Message { get { return _message; } }
    }

    public class MailService
    {
        public event EventHandler<MailEventArgs> NewMail = delegate { };

        protected virtual void OnMail(MailEventArgs e)
        {
            NewMail?.Invoke(this, e);
        }

        public void CreateMail(string message)
        {
            OnMail(new MailEventArgs(message));
        }
    }
}
