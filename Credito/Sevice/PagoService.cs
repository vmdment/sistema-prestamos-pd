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
        public static PagoService Instance { get; private set; } = new PagoService();
        
        private PrestamoService prestamoService = PrestamoService.Instance;
                
        private GlobalService globalService = GlobalService.Instance;
        private PagoService() {}

        public bool GuardarPago(Prestamo prestamo, Pago pago)
        {
            bool pagoRealizado = globalService.WriteLine(@"\data\pagos.txt", pago.ToString());
            if (pagoRealizado)
            { 
                prestamo.Monto -= pago.Monto;
                prestamoService.ActualizarPrestamo(prestamo);
            }
            return pagoRealizado;
        }
    }
}
