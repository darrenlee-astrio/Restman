using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restman.Application.Common.Formatters;

public static class StringFormatter
{
    public static string Format(HttpStatusCode statusCode)
    {
        return $"{(int)statusCode} {statusCode}";
    }

    public static string Format(TimeSpan timeSpan)
    {
        return $"{timeSpan.TotalMilliseconds.ToString("#.##")} ms";
    }
}
