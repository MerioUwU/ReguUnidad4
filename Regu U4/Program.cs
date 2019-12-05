using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regu_U4
{
    class Program
    {
        static void Main(string[] args)
        {
            RepoEnterprise empresa = new RepoEnterprise();//instancia del repo
            empresa.Principal();//llamado del metodo saludo
        }
    }
}
