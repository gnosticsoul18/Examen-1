using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Program
    {
        //Creacion de clase Empleado
        class Empleado
        {
            public string Cedula { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public double Salario { get; set; }

            //Creacion de constructor para la clase Empleado
            public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
            {
                Cedula = cedula;
                Nombre = nombre;
                Direccion = direccion;
                Telefono = telefono;
                Salario = salario;
            }

        }

        //Creacion de clase Menu Principal
        static class MenuPrincipal
        {
            public static int cantidadEmpleados = 10;
            public static string[] cedulas = new string[cantidadEmpleados];
            public static string[] nombres = new string[cantidadEmpleados];
            public static string[] direcciones = new string[cantidadEmpleados];
            public static string[] telefonos = new string[cantidadEmpleados];
            public static double[] salarios = new double[cantidadEmpleados];
            public static int empleadoCount = 0;

            public static void MostrarMenu()
            {
                Console.Clear();
                Console.WriteLine("Menú Principal");
                Console.WriteLine("1- Agregar Empleados");
                Console.WriteLine("2- Consultar Empleados");
                Console.WriteLine("3- Modificar Empleados");
                Console.WriteLine("4- Borrar Empleados");
                Console.WriteLine("5- Inicializar Arreglos");
                Console.WriteLine("6- Reportes");
                Console.WriteLine("7- Salir");
            }
            public static void InicializarArreglos()
            {
                Console.Clear();
                cedulas = Enumerable.Repeat("", cantidadEmpleados).ToArray();
                nombres = Enumerable.Repeat("", cantidadEmpleados).ToArray();
                direcciones = Enumerable.Repeat("", cantidadEmpleados).ToArray();
                telefonos = Enumerable.Repeat("", cantidadEmpleados).ToArray();
                salarios = Enumerable.Repeat(0.0, cantidadEmpleados).ToArray();
                empleadoCount = 0;
                Console.WriteLine("Arreglos inicializados correctamente.");
                Console.WriteLine("Presione Enter para continuar.");
                Console.ReadKey();
            }
            public static void AgregarEmpleado()
            {
                Console.Clear();
                if (empleadoCount < cantidadEmpleados)
                {
                    Console.WriteLine("Ingrese la cédula del empleado:");
                    cedulas[empleadoCount] = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre del empleado:");
                    nombres[empleadoCount] = Console.ReadLine();
                    Console.WriteLine("Ingrese la dirección del empleado:");
                    direcciones[empleadoCount] = Console.ReadLine();
                    Console.WriteLine("Ingrese el teléfono del empleado:");
                    telefonos[empleadoCount] = Console.ReadLine();
                    Console.WriteLine("Ingrese el salario del empleado:");
                    double salario;
                    if (double.TryParse(Console.ReadLine(), out salario))
                    {
                        salarios[empleadoCount] = salario;
                        empleadoCount++;
                        Console.WriteLine("Empleado agregado exitosamente.");
                        Console.WriteLine("Presione ENTER para continuar.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Salario no válido.");
                    }
                }
                else
                {
                    Console.WriteLine("No se pueden agregar más empleados.");
                    Console.WriteLine("Presione ENTER para continuar.");
                    Console.ReadKey();
                }
            }

            public static int ConsultarEmpleado(string cedula)
            {
                Console.Clear();

                for (int i = 0; i < empleadoCount; i++)
                {
                    if (cedulas[i] == cedula)
                    {
                        Console.WriteLine("*** Empleado encontrado: ***");
                        Console.WriteLine("Nombre:" + nombres[i]);
                        Console.WriteLine("Dirección: " + direcciones[i]);
                        Console.WriteLine("Teléfono: " + telefonos[i]);
                        Console.WriteLine("Salario: " + salarios[i]);
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadKey();
                        return i; // Devuelve el índice del empleado encontrado para usarse en otros métodos
                    }
                }

                Console.WriteLine("Empleado no encontrado.");
                return -1; // Devuelve -1 si no se encuentra el empleado
            }


            public static void ModificarEmpleado()
            {
                Console.Clear();
                Console.WriteLine("Ingrese la cédula del empleado a modificar:");
                string cedula = Console.ReadLine();

                // Llama a la función ConsultarEmpleado
                int index = ConsultarEmpleado(cedula);

                if (index >= 0)
                {
                    Console.WriteLine("Ingrese el nuevo nombre del empleado:");
                    nombres[index] = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva dirección del empleado:");
                    direcciones[index] = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo teléfono del empleado:");
                    telefonos[index] = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo salario del empleado:");
                    double salario;
                    if (double.TryParse(Console.ReadLine(), out salario))
                    {
                        salarios[index] = salario;
                        Console.WriteLine("Empleado modificado exitosamente.");
                        Console.WriteLine("Presione ENTER para continuar.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Salario no válido.");
                    }
                }
                else
                {
                    Console.WriteLine("Empleado no encontrado.");
                    Console.WriteLine("Presione ENTER para continuar.");
                    Console.ReadKey();
                }
            }

            public static void BorrarEmpleado()
            {
                Console.Clear();
                Console.WriteLine("Ingrese la cédula del empleado a borrar:");
                string cedula = Console.ReadLine();

                // Llama a la función ConsultarEmpleado
                int index = ConsultarEmpleado(cedula);

                if (index >= 0)
                {
                    for (int i = index; i < empleadoCount - 1; i++)
                    {
                        cedulas[i] = cedulas[i + 1];
                        nombres[i] = nombres[i + 1];
                        direcciones[i] = direcciones[i + 1];
                        telefonos[i] = telefonos[i + 1];
                        salarios[i] = salarios[i + 1];
                    }

                    cedulas[empleadoCount - 1] = "";
                    nombres[empleadoCount - 1] = "";
                    direcciones[empleadoCount - 1] = "";
                    telefonos[empleadoCount - 1] = "";
                    salarios[empleadoCount - 1] = 0.0;

                    empleadoCount--;
                    Console.WriteLine("Empleado borrado exitosamente.");
                    Console.WriteLine("Presione ENTER para continuar.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Empleado no encontrado.");
                    Console.WriteLine("Presione ENTER para continuar.");
                    Console.ReadKey();
                }
            }

            public static void ListarEmpleados()
            {
                Console.Clear();
                Console.WriteLine("*** Listado de Empleados ***");
                for (int i = 0; i < MenuPrincipal.empleadoCount; i++)
                {
                    Console.WriteLine("Numero de empleado (Indice): " + i);
                    Console.WriteLine("Cédula: " + MenuPrincipal.cedulas[i]);
                    Console.WriteLine("Nombre: " + MenuPrincipal.nombres[i]);
                    Console.WriteLine("Dirección: " + MenuPrincipal.direcciones[i]);
                    Console.WriteLine("Teléfono: " + MenuPrincipal.telefonos[i]);
                    Console.WriteLine("Salario: " + MenuPrincipal.salarios[i]);
                    Console.WriteLine();
                }
                Console.WriteLine("Presione ENTER para continuar");
                Console.ReadKey();
            }

            public static void CalcularPromedioSalarios()
            {
                Console.Clear();
                if (MenuPrincipal.empleadoCount == 0)
                {
                    Console.WriteLine("No hay empleados registrados.");
                }
                else
                {
                    double totalSalarios = 0;
                    for (int i = 0; i < MenuPrincipal.empleadoCount; i++)
                    {
                        totalSalarios += MenuPrincipal.salarios[i]; //Suma todos los salarios
                    }
                    double promedioSalarios = totalSalarios / MenuPrincipal.empleadoCount;
                    Console.WriteLine("Promedio de salarios: " + promedioSalarios);
                }
                Console.WriteLine("Presione ENTER para continuar");
                Console.ReadKey();
            }

            public static void SalarioMaxMin()
            {
                Console.Clear();
                if (MenuPrincipal.empleadoCount == 0)
                {
                    Console.WriteLine("No hay empleados registrados.");
                }
                else
                {
                    double salarioMinimo = MenuPrincipal.salarios[0];
                    double salarioMaximo = MenuPrincipal.salarios[0];

                    for (int i = 1; i < MenuPrincipal.empleadoCount; i++)
                    {
                        if (MenuPrincipal.salarios[i] < salarioMinimo)
                        {
                            salarioMinimo = MenuPrincipal.salarios[i];
                        }
                        if (MenuPrincipal.salarios[i] > salarioMaximo)
                        {
                            salarioMaximo = MenuPrincipal.salarios[i];
                        }
                    }

                    Console.WriteLine("Salario más bajo: " + salarioMinimo);
                    Console.WriteLine("Salario más alto: " + salarioMaximo);
                }
                Console.WriteLine("Presione ENTER para continuar");
                Console.ReadKey();
            }

            public static void MostrarReportes()
            {
                int opcion = 0;
                while (opcion != 5)
                {
                    Console.Clear();
                    Console.WriteLine("Menú de Reportes");
                    Console.WriteLine("1- Consultar empleados por cédula");
                    Console.WriteLine("2- Listar empleados por nombre");
                    Console.WriteLine("3- Calcular promedio de salarios");
                    Console.WriteLine("4- Encontrar salario más alto y más bajo");
                    Console.WriteLine("5- Volver al menú principal");
                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Ingrese la cédula del empleado a consultar:");
                                string cedula = Console.ReadLine();
                                MenuPrincipal.ConsultarEmpleado(cedula);
                                break;
                            case 2:
                                MenuPrincipal.ListarEmpleados();
                                break;
                            case 3:
                                MenuPrincipal.CalcularPromedioSalarios();
                                break;
                            case 4:
                                MenuPrincipal.SalarioMaxMin();
                                break;
                            case 5:
                                Console.WriteLine("Volviendo al menú principal.");
                                break;
                            default:
                                Console.WriteLine("Opción no válida.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
                }
            }

        }

        public static void Main()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al Sistema de Recursos Humanos");
            Console.WriteLine("Por favor inicialize los arreglos (Opción 5) para empezar");
            Console.WriteLine("Presione ENTER para continuar al menú principal.");
            Console.ReadKey();
            int opcion = 0;
            while (opcion != 7)
            {
                MenuPrincipal.MostrarMenu();
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            MenuPrincipal.AgregarEmpleado();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ingrese la cédula del empleado a consultar:");
                            string cedula = Console.ReadLine();
                            MenuPrincipal.ConsultarEmpleado(cedula);
                            break;
                        case 3:
                            MenuPrincipal.ModificarEmpleado();
                            break;
                        case 4:
                            MenuPrincipal.BorrarEmpleado();
                            break;
                        case 5:
                            MenuPrincipal.InicializarArreglos();
                            break;
                        case 6:
                            MenuPrincipal.MostrarReportes();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo del programa.");
                            return;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
        }


    }
}


