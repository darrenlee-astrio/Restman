using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restman.Application.Common.Formatters;

public static class UrlFormatter
{
    public static string Combine(string baseUrl, string endUrl)
    {
        Uri baseUri = new Uri(baseUrl, UriKind.Absolute);
        Uri combinedUri = new Uri(baseUri, endUrl);

        return combinedUri.ToString();
    }
}
