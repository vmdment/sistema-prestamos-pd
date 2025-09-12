using Credito.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credito.Sevice
{
    public class PrestamoService
    {
        private GlobalService globalService;
        public static PrestamoService Instance { get; } = new PrestamoService();
        public PrestamoService() {
            globalService = GlobalService.Instance;
        }
        public bool GuardarPrestamo(Prestamo prestamo)
        {
            return globalService.WriteLine(@$"\data\prestamos.txt", prestamo.ToString());
        }

    }
}
