using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Credito.Domain
{
    public class Prestamo
    {
        #region atributos
        public string Id { get; private set; }
        public string DocumentoCliente { get; private set; }
        public decimal Capital { get; private set; }
        public decimal Monto { get; set; }
        public decimal Interes { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
        public bool Estado { get; private set; }
        public List<Pago> Pagos { get; private set; }

        #endregion
        #region constructor
        public Prestamo(string documentoCliente,decimal capital)
        {
            FechaCreacion = DateTime.Now;
            FechaActualizacion = FechaCreacion;
            Id = documentoCliente + FechaCreacion.TimeOfDay.TotalMilliseconds;
            DocumentoCliente = documentoCliente;
            Capital = VerificarCapital(capital);
            Interes = DefinirInteres();
            Monto = Capital;
            Estado = true;
            Pagos = new List<Pago>();
        }
        public Prestamo(string id, string documentoCliente, decimal capital, decimal monto, decimal interes, DateTime fechaCreacion, DateTime fechaActualizacion,  bool estado, List<Pago> pagos)
        {
            Id = id;
            DocumentoCliente = documentoCliente;
            Capital = capital;
            Monto = monto;
            Interes = interes;
            FechaCreacion = fechaCreacion;
            FechaActualizacion = fechaActualizacion; 
            Estado = estado;
            Pagos = pagos;
        }
        #endregion
        #region metodos publicos
        public decimal DefinirInteres()
        {
            if(Capital >= 10000000)
                return 10;
            
            if (Capital < 10000000 && Capital >= 3000000)            
                return 15;
            
            return 20;            
        }
        
        public decimal VerificarCapital(decimal capitalPrestado)
        {
            if (capitalPrestado<=0)
            
                throw new ArgumentException("El capital prestado debe ser mayor a cero");
            

            return capitalPrestado;
        }

        #endregion
        #region metodos privados}
        public bool ActualizarEstado(decimal monto, bool estadoPrestamo)
        {
            if (monto == 0)
            {
                return estadoPrestamo = false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"{Id};{DocumentoCliente};{Capital};{Monto};{Interes};{FechaCreacion.ToString("yyyy-MM-ddTHH:mm")};{FechaActualizacion.ToString("yyyy-MM-ddTHH:mm")};{Estado}";
        }
        #endregion
    }
}
