using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{   //creating an interafce which is just the method and propery signatures, convenction dictates they atart with an I
    //the actual code for the interface is then defined in any class that uses it
    //use to define commanilty between classes that are otherwicse not related
    public interface ILoggable //must be public
    {
        string Log();
    }
}
