using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regu_U4
{
    interface IRepoEnterprise//interfaz de el repo con sus metodos a utilizar
    {
        void Menu();
        void AddEmployee();
        void SeeEmployees();
        Empleado EditEmployee(Empleado Employee);
        void DetailEmployee();
        void CatchMsg(Exception ex);
        void GoBack();   
    }
}
