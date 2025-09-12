using Credito.Domain;

namespace Credito.Sevice
{
    public class PersonaService
    {
        private GlobalService globalService;
        public static PersonaService Instance { get; } = new PersonaService();
        private PersonaService()
        {
            this.globalService = GlobalService.Instance;
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
                            return new Cliente(persona[0], persona[1], persona[2], persona[3], persona[4], decimal.Parse(persona[5]), persona[6].Replace("\r", ""), new List<Prestamo>());
                        else
                            return new Empleado(persona[0], persona[1], persona[2], persona[3], persona[4].Replace("\r",""));
                    }
                }
            }
           return null;
        }
        public Cliente buscarClientePorDocumento(string documento)
        {
            string texts = globalService.ReadAll(@"\data\clientes.txt") ?? "";
            string[] lineas = texts.Split("\n");
            foreach (string linea in lineas)
            {
                string documentoEnArchivo = linea.Split(";")[2];
                if (documentoEnArchivo == documento)
                {
                    string[] persona = linea.Split(";");
                    return new Cliente(persona[0], persona[1], persona[2], persona[3], persona[4], decimal.Parse(persona[5]), persona[6].Replace("\r", ""), new List<Prestamo>());
                }
            }
            return null;
        }
        public bool GuardarCliente(Cliente cliente)
        {
            return globalService.WriteLine(@$"\data\clientes.txt", cliente.ToString());
        }
    }
}
