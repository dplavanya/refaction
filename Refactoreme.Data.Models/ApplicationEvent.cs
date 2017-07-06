using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoreme.Data.Models
{
    public enum ApplicationEvent
    {
        UnhandledApplicationException = 5000,

        DeleteOptionFailedEvent = 5001,
        UpdateOptionFailedEvent = 5002,
        CreateOptionFailedEvent = 5003,

        DeleteProductFailedEvent = 5004,
        UpdateProductFailedEvent = 5005,
        CreateProductFailedEvent = 5006,

    }
}
