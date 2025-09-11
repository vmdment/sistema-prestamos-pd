using Credito.Domain;

namespace Credito.Sevice
{
    public class PersonaService
    {
        private GlobalService globalService;
        public PersonaService(GlobalService globalService)
        {
            this.globalService = globalService;
        }
        
        public Persona Login(string documento)
        {
            string[] archivos = ["clientes", "empleados"];
            foreach (string archivo in archivos)
            {
                string texts = globalService.ReadAll(@$"\data\{archivo}.txt") ?? "";
                string[] lineas = texts.Split("\n");
                foreach (string linea in lineas) {
                    string documentoEnArchivo = linea.Split(";")[2];
                    if(documentoEnArchivo == documento)
                    {
                        string[] persona = linea.Split(";");
                        if (archivo == "clientes")
                            return new Cliente(persona[0], persona[1], persona[2], persona[3], persona[4], decimal.Parse(persona[5]), persona[6]);
                        else
                            return new Empleado(persona[0], persona[1], persona[2], persona[3], persona[4]);
                    }
                }
            }
           return null;
        }
    }
}
