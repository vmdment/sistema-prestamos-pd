using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credito.Domain
{
    public class Cliente:Persona
    {
        #region atributos
        
        public decimal Salario { get; private set; }
        public string Direccion { get; private set; }
        public List<Prestamo> Prestamos { get; private set; }

        #endregion

        #region contructor
        public Cliente(string nombreCompleto, string documento, string correo, string telefono, decimal salario, string direccion) :
            base(nombreCompleto, documento, correo, telefono)
        {
            Salario = ValidarSalario(salario);
            Direccion = direccion;
            Prestamos = new List<Prestamo>();
        }
        public Cliente(string id, string nombreCompleto, string documento, string correo, string telefono, decimal salario, string direccion, List<Prestamo> prestamos) :
            base(id,nombreCompleto, documento, correo, telefono)
        {
            Salario = ValidarSalario(salario);
            Direccion = direccion;
            Prestamos = prestamos;
        }
        #endregion

        #region Metodos Privados
        private decimal ValidarSalario(decimal salario) {
            return salario > 0 ? salario : throw new ArgumentOutOfRangeException();
        }
       
        #endregion
        public override string ToString()
        {
            return $"{Id};{NombreCompleto};{Documento};{Correo};{Telefono};{Salario};{Direccion}";
        }
    }
}
