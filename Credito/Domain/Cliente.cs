using Credito.Sevice;
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
        private PagoService pagoService = PagoService.Instance;
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
        public Pago? RealizarPago()
        {
            Pago? pago = null;
            Prestamo? prestamo = Prestamos.Find((prestamo) => prestamo.Estado == true);
            if (prestamo == null)
            {
                Console.WriteLine("No se encuentran prestamos activos");
                return null;
            }
            
            bool validate = true;   
            string confirmarPago = "y";
            bool pagoGuardado = false;
            do
            {
                
                Console.WriteLine("Opciones de pago");
                Console.WriteLine("1. Pago de interes");
                Console.WriteLine("2. Pago total");
                //Console.WriteLine("3. Pago de capital");
                Console.Write("Seleccione una opcion: ");

                int opcion = int.Parse(Console.ReadLine() ?? "-1");
                switch (opcion) { 
                    case 1:
                        decimal montoInteres = prestamo.Monto * prestamo.Interes / 100;
                        pago = new Pago(prestamo.Id, montoInteres);
                        Console.WriteLine("Monto a pagar: " + montoInteres);
                        Console.Write("Confirmar pago: (Y/n)");
                        confirmarPago = Console.ReadLine() ?? "y";
                        confirmarPago = confirmarPago == "" ? "y" : confirmarPago;
                        if (confirmarPago.Equals("y", StringComparison.CurrentCultureIgnoreCase)) { 
                            pagoGuardado = pagoService.GuardarPago(prestamo,pago);
                            if (pagoGuardado)
                                Console.WriteLine("Pago realizado exitosamente");
                            else
                                Console.WriteLine("Error al guardar el pago.");
                        }
                        validate = true;
                        break;
                    case 2:
                        pago = new Pago(prestamo.Id, prestamo.Monto + prestamo.Monto * prestamo.Interes / 100);
                        Console.WriteLine("Monto a pagar: " + prestamo.Monto);
                        Console.Write("Confirmar pago: (Y/n)");
                        confirmarPago = Console.ReadLine() ?? "y";
                        confirmarPago = confirmarPago == "" ? "y" : confirmarPago;
                        if (confirmarPago.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                        {
                            pagoGuardado = pagoService.GuardarPago(prestamo,pago);
                            if(pagoGuardado)
                                Console.WriteLine("Pago realizado exitosamente");
                            else
                                Console.WriteLine("Error al guardar el pago.");
                        }
                        validate = true;
                        break;
                    //case 3:
                    //    decimal montoCapital = prestamo.Monto == 0 ? prestamo.Capital : prestamo.Monto;
                    //    pago = new Pago(prestamo.Id, montoCapital);
                    //    Console.WriteLine("Monto a pagar: " + montoCapital);
                    //    Console.Write("Confirmar pago: (Y/n)");
                    //    confirmarPago = Console.ReadLine() ?? "Y";
                    //    if(confirmarPago == "Y")
                    //    pagoService.GuardarPago(prestamo,pago);
                    //    validate = true;
                    //    break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        validate = false;
                        break;
                }

            } while (!validate);
            return pago;
        }
        #endregion
        public override string ToString()
        {
            return $"{Id};{NombreCompleto};{Documento};{Correo};{Telefono};{Salario};{Direccion}";
        }
    }
}
