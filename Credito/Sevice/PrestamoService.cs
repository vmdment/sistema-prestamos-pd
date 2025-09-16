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
        public List<Prestamo> BuscarPrestamoPorDocumento(string documento)
        {
            string prestamos = globalService.ReadAll(@$"\data\prestamos.txt");
            List<Prestamo> listaDePrestamos = new List<Prestamo>();
            if (prestamos != null)
            {
                string[] filas = prestamos.Split("\n");
                foreach (String fila in filas) {
                    string[] filaSplit = fila.Split(";");
                    string documentoEnArchivo = filaSplit[1];
                    if(documentoEnArchivo == documento)
                    {
                        listaDePrestamos.Add(new Prestamo(filaSplit[0], documentoEnArchivo, decimal.Parse(filaSplit[2]), decimal.Parse(filaSplit[3]), decimal.Parse(filaSplit[4]),DateTime.Parse(filaSplit[5]), DateTime.Parse(filaSplit[6]), bool.Parse(filaSplit[7]),new List<Pago>()));
                    }
                }
                return listaDePrestamos;
            }
            else
                return listaDePrestamos;
        }
        public List<Prestamo> BuscarTodo()
        {
            string? prestamos = globalService.ReadAll(@$"\data\prestamos.txt");
            List<Prestamo> listaDePrestamos = new List<Prestamo>();
            if (prestamos != null)
            {
                string[] filas = prestamos.Split("\n");
                foreach (String fila in filas)
                {
                    string[] filaSplit = fila.Split(";");
                    listaDePrestamos.Add(new Prestamo(filaSplit[0], filaSplit[1], decimal.Parse(filaSplit[2]), decimal.Parse(filaSplit[3]), decimal.Parse(filaSplit[4]), DateTime.Parse(filaSplit[5]), DateTime.Parse(filaSplit[6]), bool.Parse(filaSplit[7]), new List<Pago>()));
                    
                }
                return listaDePrestamos;
            }
            else
                return listaDePrestamos;
        }
        public Prestamo ActualizarPrestamo(Prestamo prestamo)
        {
            List<Prestamo> prestamos = BuscarTodo();
            globalService.Reset(@$"\data\prestamos.txt");
            foreach (Prestamo prestamoTemp in prestamos)
            {
                if (prestamoTemp.Id == prestamo.Id)
                    GuardarPrestamo(prestamo);
                else
                    GuardarPrestamo(prestamoTemp);
            }
            return prestamo;

        }
        
    }
}
