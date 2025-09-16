using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credito.Domain
{
    public class Pago
    {
        #region atributos
        public string PrestamoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        #endregion
        #region constructor
        public Pago(string prestamoId, decimal monto)
        {
            PrestamoId = prestamoId;
            Monto = ValidarMonto(monto);
            Fecha = DateTime.Now;
        }
        public Pago(string prestamoId, decimal monto, DateTime fecha)
        {
            PrestamoId = prestamoId;
            Monto = ValidarMonto(monto);
            Fecha = fecha;
        }
        #endregion
        #region Metodos privados
        private decimal ValidarMonto(decimal monto)
        {
            if (monto <= 0)
            {
                throw new ArgumentException("El monto debe ser mayor a cero");
            }
            return monto;
        }
        public override string ToString()
        {
            return $"{PrestamoId};{Monto};{Fecha.ToString("yyyy-MM-ddTHH:mm")}";
        }
        #endregion
    }
}
