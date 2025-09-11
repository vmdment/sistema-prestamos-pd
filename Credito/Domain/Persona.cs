using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Credito.Domain
{
    public abstract class Persona
    {
        private static int LAST_ID = 0;
        #region atributos
        protected string Id { get; set; }
        protected string NombreCompleto { get; set; }
        protected string Documento { get; set; }
        protected string Correo { get; set; }
        protected string Telefono { get; set; }
        #endregion
      
        #region constructor
        public Persona(string nombreCompleto, string documento, string correo, string telefono)
        {
            this.Id = (Persona.LAST_ID++).ToString();
            this.NombreCompleto = ValidarNombre(nombreCompleto);
            this.Documento = ValidarDocumento(documento);
            this.Correo = ValidarCorreo(correo);
            this.Telefono = ValidarTelefono(telefono);
        }
        public Persona(string id, string nombreCompleto, string documento, string correo, string telefono)
        {
            this.Id = id;
            this.NombreCompleto = ValidarNombre(nombreCompleto);
            this.Documento = ValidarDocumento(documento);
            this.Correo = ValidarCorreo(correo);
            this.Telefono = ValidarTelefono(telefono);
        }
        #endregion

        #region Metodos Privados
        private string ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            return nombre;
        }

        private string ValidarDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento) || !Regex.IsMatch(documento, @"^\d{7,12}$"))
                throw new ArgumentException("El documento debe ser numérico.");
            return documento;
        }

        private string ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono) || !Regex.IsMatch(telefono, @"^\d+$"))
                throw new ArgumentException("El telefonoéfono debe ser numérico.");
            return telefono;
        }

        private string ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("El correo no puede estar vacío.");

            // Expresión regular para formato de email válido
            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El correo no es válido.");

            return correo;
        }
        #endregion
    }
}

