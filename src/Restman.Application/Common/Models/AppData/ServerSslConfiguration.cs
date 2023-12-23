using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restman.Application.Common.Models.AppData;

public class ServerSslConfiguration
{
    public bool Validate { get; set; }
    public string? ServerSslHashString { get; set; }
}
