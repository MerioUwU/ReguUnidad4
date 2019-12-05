using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regu_U4
{
    class RepoEnterprise : IRepoEnterprise//herencia de la interfaz
    {
        List<Empleado> empleados;//lista global
        int EmployeeID = 0;//contador que sirve de id y muestra cuantos empleados tiene
        public RepoEnterprise()//ctor para lista
        {
            empleados = new List<Empleado>();
        }
        internal void Principal() //salido que viene del menu
        {
            Console.WriteLine("Bienvenido al programa de control de empresa, presione cualquier tecla para ir al menu.");
            GoBack();
        }
        public void Menu()//agregar, ver lista y modificar
        {
            try 
            {
                Console.WriteLine("Numero de empleados actuales: {0}\n\nSeleccione con un numero que desea hacer: \n\n1.-Agregar empleado\n2.-Ver lista de empleados\n3.-Salir",EmployeeID);
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        SeeEmployees();
                        break;
                    case 3:
                        System.Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Seleccione una opcion valida, por favor");
                        GoBack();
                        break;
                }
            }
            catch (Exception ex) 
            {
                CatchMsg(ex);
            }
        }
        public void AddEmployee()//agregar empleado, puedes repetir el jale 
        {
            Console.Clear();
            try 
            {
                Console.WriteLine("Ingrese el nombre del empleado: ");
                string name = Console.ReadLine();
                Console.WriteLine("Ingrese el departamento en el que el emplado labora: ");
                string department = Console.ReadLine();
                Console.WriteLine("Seleccione con un numero el horario que el empleado trabajara: \n1.-Turno matutino\n2.-Turno vespertino\n3.-Turno Nocturno\n4.-Horario quebrado");
                int schedule = int.Parse(Console.ReadLine());
                switch (schedule) 
                {
                    case 1: schedule = 1; break;
                    case 2: schedule = 2; break;
                    case 3: schedule = 3; break;
                    case 4: schedule = 4; break;
                    default: Console.WriteLine("Opcion invalida, ingrese un numero entre 1 y 4: "); schedule = int.Parse(Console.ReadLine()); break;
                }
                empleados.Add(new Empleado { ID = EmployeeID + 1, Name = name, Department = department, Schedule = schedule });
                EmployeeID++;
                Console.WriteLine("Empleado almacenado correctamente, presione 1 para ingresar otro o 2 para volver al menu: ");
                if (int.Parse(Console.ReadLine())==1) //ya se lleno
                {
                    Console.Clear();
                    AddEmployee();//por si queire repetir
                }
                else 
                {
                    GoBack();//regresar al menu
                }
            }
            catch ( Exception ex) 
            {
                CatchMsg(ex);//metodo para no escribir lo mismo siempre
            }
        }

        public Empleado EditEmployee(Empleado Employee)//editar empleado trayendo un objeto seleccionado
        {
            try 
            {
                Console.WriteLine("Seleccione con un numero la informacion deseada para modificar:\n\n1.-Nombre\n2.-Departamento\n3.-Horario");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Escribe el nombre actualizado del empleado: ");
                        string nombre = Console.ReadLine();
                        Employee.Name = nombre;
                        break;
                    case 2:
                        Console.WriteLine("Escriba el departamento actualizado del empleado: ");
                        string department = Console.ReadLine();
                        Employee.Department = department;
                        break;
                    case 3:
                        Console.WriteLine("Seleccione con un numero el horario:\n1.- Turno Matutino\n2.- Turno Vespertino\n3.- Turno Nocturno\n4.- Horario Quebrado");
                        int schedule = int.Parse(Console.ReadLine());
                        Employee.Schedule = schedule;
                        break;
                    case 4:
                        return Employee;
                    default:
                        Console.WriteLine("Seleccione una opcion Valida, se volvera al menu"); 
                        GoBack();
                        break;
                }
                Console.WriteLine("Datos actualizados correctamente, presione cualquier tecla para continuar");
                Console.ReadKey();
                return Employee;//regresas empleado
            }
            catch(Exception ex) 
            {
                CatchMsg(ex);
                return Employee;
            }
        }

        public void SeeEmployees()//ver lista de empleados, si la lsita esta vacia te regresa al menu
        {
            try
            {
                Console.Clear();
                if (empleados == null)
                {
                    Console.WriteLine("La lista esta vacia, volviendo al menu");
                    GoBack();
                }
                else
                {
                    foreach (var item in empleados)//despliegue de objetos
                    {
                        Console.WriteLine("{0}.- {1}", item.ID, item.Name);
                    }
                    Console.WriteLine("Para ver informacion detallada de un empleado, presione 1, para volver al menu presione 2");
                    if (int.Parse(Console.ReadLine()) == 1) 
                    {
                        DetailEmployee();//si el usuario quiere detallar manda al metodo
                    }
                    else 
                    {
                        GoBack();//si no quiere detallar va al menu
                    }
                }
            }
            catch(Exception ex) 
            {
                CatchMsg(ex);
            }
        }
        public void DetailEmployee()
        {
            try
            {
                Empleado e = new Empleado();//pides elegir al usuario un objeto de la lista
                Console.WriteLine("Seleccione con un numero de la lista el empleado a detallar: ");
                int idsearch = int.Parse(Console.ReadLine());
                foreach(var item in empleados) 
                {
                    if(idsearch == item.ID) 
                    {
                        e = item;//si el usuario esta lo hace el objeto instanciado
                    }
                }
                string schedule="";//variable int para horario
                switch (e.Schedule) 
                {
                    case 1: schedule = "Turno Matutino"; break;
                    case 2: schedule = "Turno Vespertino"; break;
                    case 3: schedule = "Turno Nocturno"; break;
                    case 4: schedule = "Horario Quebrado"; break;
                }
                Console.WriteLine("Numero de empleado:{0}\nNombre: {1}\nDepartamento: {2}\nHorario:{3}\n\nSi desea modificar algun dato del empleado presione 1, para volver al menu presione 2",e.ID,e.Name,e.Department,schedule);
                if (int.Parse(Console.ReadLine()) == 1) //despues de desplegar el usuario pregunta si queire editar
                {
                    e = EditEmployee(e);
                    GoBack();//despues de editar regresa al menu
                }
                else 
                {
                    GoBack();//se devuelve al menu si no quiere
                }
            }
            catch(Exception ex) 
            {
                CatchMsg(ex);
            }
        }
        public void CatchMsg(Exception ex) //lo que despliega el catch en todos los try catch
        {
            Console.WriteLine("Se ha detectado en error: {0}", ex.Message);
            GoBack();//manda al menu 
        }
        public void GoBack() //metodo para devolver al menu constantemente
        {
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
