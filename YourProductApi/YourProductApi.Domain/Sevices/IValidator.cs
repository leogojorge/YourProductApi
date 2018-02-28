using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.Domain.Sevices
{
    public interface IValidator
    {
        IList<string> Erros { get; set; }
        bool IsValid();
    }

}
