
using Credito.Sevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Credito.Domain
{
    public class Empleado:Persona
    {
        PersonaService personaService = PersonaService.Instance;
        PrestamoService prestamoService = PrestamoService.Instance;
        #region constructor
        public Empleado(string nombreCompleto, string documento, string correo, string telefono):
            base(nombreCompleto, documento, correo, telefono) // llama al constructor de Persona
        {}
        public Empleado(string id, string nombreCompleto, string documento, string correo, string telefono) :
            base(id,nombreCompleto, documento, correo, telefono) // llama al constructor de Persona
        {
            
        }
        #endregion

        #region Métodos publicos de Empleado


        public void RealizarRecaudo()
        {

        }
        public Prestamo? RealizarPrestamo(Cliente cliente)
        {
            bool existePrestamo = cliente.Prestamos.Find((prestamo)=> prestamo.Estado) != null;
            if(existePrestamo)
            {
                Console.WriteLine("El cliente ya tiene un préstamo activo.");
                return null;
            }
            Console.Write("Valor a prestar:");
            decimal valorPrestamo = decimal.Parse(Console.ReadLine() ?? "0");
            if(valorPrestamo <= cliente.Salario * 2)
            {
                Prestamo prestamo = new Prestamo(cliente.Id, valorPrestamo);
                prestamoService.GuardarPrestamo(prestamo);
                return prestamo;
            }
            Console.WriteLine("El valor a prestar excede el límite permitido.");
            return null;
            
        }
        public Cliente RegistrarCliente() {
            Console.WriteLine("***** REGISTRO DE CLIENTE *****");
            Console.Write("\x1b[34mdocumento:\x1b[0m");
            string documento = Console.ReadLine() ?? "";
            Console.Write("nombre:");
            string nombreCompleto = Console.ReadLine() ?? "";
            Console.Write("correo:");
            string correo = Console.ReadLine() ?? "";
            Console.Write("telefono:");
            string telefono = Console.ReadLine() ?? "";
            Console.Write("direccion:");
            string direccion = Console.ReadLine() ?? "";
            Console.Write("salario:");
            decimal salario = decimal.Parse(Console.ReadLine() ?? "0");
            Cliente cliente = new Cliente(nombreCompleto, documento, correo, telefono, salario, direccion);
            personaService.GuardarCliente(cliente);
            return cliente;

        }
        public override string ToString()
        {
            return $"{Id};{NombreCompleto};{Documento};{Correo};{Telefono}";
        }
        #endregion
    }
}
