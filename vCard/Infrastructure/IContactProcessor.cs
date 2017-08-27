using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vCard.Models;

namespace vCard.Infrastructure
{
    public interface IContactProcessor
    {
        void SendMessage(ContactInfo contact);
    }
}
