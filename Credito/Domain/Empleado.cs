
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
        
        #region constructor
        public Empleado(string nombreCompleto, string documento, string correo, string telefono):
            base(nombreCompleto, documento, correo, telefono) // llama al constructor de Persona
        {}
        public Empleado(string id, string nombreCompleto, string documento, string correo, string telefono) :
            base(id,nombreCompleto, documento, correo, telefono) // llama al constructor de Persona
        { }
        #endregion

        #region Métodos Privados de Empleado


        public void RealizarRecaudo()
        {

        }

        public Cliente RegistrarCliente() {
            //const Cliente cliente = new Cliente();
            // documento,nombreCompleto  correo,  telefono
            Console.Write("Ingrese su documento:");
            string documento = Console.ReadLine() ?? "";
            Console.Write("Ingrese su nombre:");
            string nombreCompleto = Console.ReadLine() ?? "";
            Console.Write("Ingrese su correo:");
            string correo = Console.ReadLine() ?? "";
            Console.Write("Ingrese su telefono:");
            string telefono = Console.ReadLine() ?? "";
            Console.Write("Ingrese su direccion:");
            string direccion = Console.ReadLine() ?? "";
            Console.Write("Ingrese su salario:");
            decimal salario = decimal.Parse(Console.ReadLine() ?? "0");
            
            return new Cliente(nombreCompleto, documento, correo, telefono, salario, direccion);

        }
        #endregion
    }
}
