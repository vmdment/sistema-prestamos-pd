
using Credito.Domain;
using Credito.Sevice;

namespace Credito
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("********************** INICIO PROGRAMA PRESTAMOS **********************");
            Console.WriteLine(Directory.GetCurrentDirectory());
            Persona persona = Login();
            if (persona != null)
            {
                Console.WriteLine(persona.ToString());
                if (persona is Empleado)
                {
                    Console.WriteLine("Empleado");
                }
                else
                    Console.WriteLine("Cliente");
            }
            //Empleado empleado = new Empleado("Luis", "1231231", "lrivas@gmail.com", "123312");
            //empleado.RegistrarCliente();
        }
        private static Persona Login()
        {
            PersonaService personaService = new PersonaService(new GlobalService());
            Console.Write("Ingrese su documento:");
            string documento = Console.ReadLine() ?? "";
            return personaService.Login(documento);
        }
    }
}