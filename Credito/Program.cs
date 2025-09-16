
using Credito.Domain;
using Credito.Sevice;

namespace Credito
{
    public class Program
    {
        private static PersonaService personaService = PersonaService.Instance;
        public static void Main(string[] args)
        {
            Console.WriteLine("********************** INICIO PROGRAMA PRESTAMOS **********************");
            Persona persona = Login();
            if (persona != null)
            {
                Console.WriteLine($"** Bienvenid@: {persona.NombreCompleto} **");
                if (persona is Empleado)
                {
                    ProcesarMenuEmpleado((Empleado)persona);
                }
                else
                {
                    
                    Console.WriteLine("Cliente");
                }
                Console.WriteLine(persona);
            }
        }
        private static Persona Login()
        {
            
            Console.WriteLine("***** LOGIN *****");
            Console.Write("Ingrese su documento:");
            string documento = Console.ReadLine() ?? "";
            return personaService.Login(documento);
        }
        private static void ProcesarMenuEmpleado(Empleado empleado)
        {
            string opcion;
            do
            {
                Cliente cliente;
                opcion = MenuEmpleado();
                switch (opcion)
                {
                    case "1":
                        cliente = empleado.RegistrarCliente();
                        Console.WriteLine("Cliente registrado: " + cliente);
                        break;
                    case "2":
                        Console.WriteLine("***** REALIZAR PRESTAMO *****");
                        Console.Write("documento:");
                        string documento = Console.ReadLine() ?? "";
                        cliente = personaService.buscarClientePorDocumento(documento);
                        if(cliente != null)
                        {
                            Prestamo prestamo = empleado.RealizarPrestamo(cliente);
                        }
                        else
                        {
                            Console.WriteLine("Cliente no encontrado");
                        }
                        break;
                    case "3":
                        // Realizar Recaudo
                        break;
                    case "4":
                        // Consultar Creditos por Cliente
                        break;
                    case "5":
                        // Consultar Creditos por Estado
                        break;
                    case "0":
                        Console.WriteLine("Saliendo...");
                        break;
                }
            } while (opcion != "0");
        }
        private static string MenuEmpleado()
        {
            do
            {
                Console.WriteLine("********************** MENU EMPLEADO **********************");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Realizar Credito");
                Console.WriteLine("3. Realizar Recaudo");
                Console.WriteLine("4. Consultar Creditos por Cliente");
                Console.WriteLine("5. Consultar Creditos por Estado");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción:");
                int opcion = int.Parse(Console.ReadLine() ?? "-1");
                if(opcion < 0 || opcion > 5)
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                else
                    return opcion.ToString();
            } while (true);
        }

        private static void ProcesarMenuCliente(Cliente cliente)
        {
            string opcion;
            do
            {
                
                opcion = MenuCliente();
                switch (opcion)
                {
                    case "1":
                        cliente.RealizarPago();
                        Console.WriteLine("Cliente registrado: " + cliente);
                        break;
                    case "0":
                        Console.WriteLine("Saliendo...");
                        break;
                }
            } while (opcion != "0");
        }
        private static string MenuCliente()
        {
            do
            {
                Console.WriteLine("********************** MENU CLIENTE **********************");
                Console.WriteLine("1. Realizar Pago");               
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción:");
                int opcion = int.Parse(Console.ReadLine() ?? "-1");
                if (opcion < 0 || opcion > 1)
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                else
                    return opcion.ToString();
            } while (true);
        }


    }
}