using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Core.Framework
{
    public interface IRequestHandlerTypeProvider
    {
        (Type requestType, Type responseType) GetInputOutputTypes(string requestName);
        Type GetInputType(string requestName);
    }
}
