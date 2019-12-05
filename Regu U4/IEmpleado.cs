using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regu_U4
{
    interface IEmpleado//interfaz del objeto
    {
        int ID { get; set; }
        string Name { get; set; }
        string Department { get; set; }
        int Schedule { get; set; }
    }
}
