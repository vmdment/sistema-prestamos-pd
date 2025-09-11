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
        
        private decimal Salario { get; set; }
        private string Direccion { get; set; }
        
        #endregion

        #region contructor
        public Cliente(string nombreCompleto, string documento, string correo, string telefono, decimal salario, string direccion) :
            base(nombreCompleto, documento, correo, telefono)
        {
            this.Salario = ValidarSalario(salario);
            this.Direccion = direccion;
        }
        public Cliente(string id, string nombreCompleto, string documento, string correo, string telefono, decimal salario, string direccion) :
            base(id,nombreCompleto, documento, correo, telefono)
        {
            this.Salario = ValidarSalario(salario);
            this.Direccion = direccion;
        }
        #endregion

        #region Metodos Privados
        private decimal ValidarSalario(decimal salario) {
            return salario > 0 ? salario : throw new ArgumentOutOfRangeException();
        }
        #endregion
    }
}
