using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regu_U4
{
    class Empleado : IEmpleado//herencia de la interfaz
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Schedule { get; set; }
    }
}
