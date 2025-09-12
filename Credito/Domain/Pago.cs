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
        public decimal montoPagado { get; set; }
        public DateTime fechaDePago { get; set; }

        #endregion
        #region constructor
        public Pago(decimal montoPagado)
        {
            this.montoPagado = ValidarMonto(montoPagado);
            this.fechaDePago = DateTime.Today;
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
        #endregion
    }
}
