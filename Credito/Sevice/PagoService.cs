using Credito.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credito.Sevice
{
    public class PagoService
    {
        //monto == monto; monto == monto * interes/100; monto == monto - monto * interes / 100;
        public PagoService Instance { get; private set; } = new PagoService();
        private GlobalService globalService = GlobalService.Instance;
        private PagoService() {}

        public bool GuardarPago(Pago pago)
        {
            return globalService.WriteLine(@"\data\pagos.txt", pago.ToString());
        }
    }
}
