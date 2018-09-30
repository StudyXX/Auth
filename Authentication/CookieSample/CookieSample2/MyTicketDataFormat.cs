using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;

namespace CookieSample2
{
public class MyTicketDataFormat : TicketDataFormat
{
    public MyTicketDataFormat(IDataProtector dataProtector=null):base(dataProtector)
    {

    }
    public new string Protect(AuthenticationTicket data)
    {
        return base.Protect(data);
    }

    public new string Protect(AuthenticationTicket data, string purpose)
    {
        return base.Protect(data, purpose);
    }

    public new AuthenticationTicket Unprotect(string protectedText)
    {
        return base.Unprotect(protectedText);
    }

    public new AuthenticationTicket Unprotect(string protectedText, string purpose)
    {
        return base.Unprotect(protectedText, purpose);
    }
}
}
