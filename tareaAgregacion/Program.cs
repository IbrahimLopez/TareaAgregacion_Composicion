using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaAgregacionComposicion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ingresar datos
            Console.WriteLine("Ingrese la informacion del dispositivo.");
            Console.WriteLine("Ingrese el modelo");
            string modelo = Console.ReadLine();
            Console.WriteLine("Ingrese la marca");
            string Marca = Console.ReadLine();
            Console.WriteLine("Ingrese el tipo");
            string Tipo = Console.ReadLine();
            Console.WriteLine("Ingrese los megapixeles");
            string mpxCamara = Console.ReadLine();
            Console.WriteLine("Ingrese el sistema operativo");
            string sistemaOperativo = Console.ReadLine();
            Console.WriteLine("Ingrese Compañia telefonica");
            String chip = Console.ReadLine();
            Chip _chip = new Chip(chip);
            Telefono telefono = new Telefono(modelo, Marca, Tipo, mpxCamara, sistemaOperativo);
            telefono.agregarChip(_chip);
            telefono.getInfo();
            telefono.getSO();
            //Seleccion de Accion
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Desea Eliminar el Telefono? \n1-SI \n2-No");
            string request = Console.ReadLine();            
            while (request=="1")
            {                
                telefono = null;
                Console.WriteLine("Que desea Mostrar? \n1-Chip \n2-Sistema Operativo");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        _chip.getCompany();
                        Console.WriteLine("Desea Salir? 1-NO 2-SI");
                        request = Console.ReadLine();
                        break;
                    case "2":
                        try
                        {
                            telefono.getSO();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(ex.ToString());
                            Console.WriteLine("No se pudo mostrar los datos ya que el teleono junto con el sistema ha sido eliminado");
                            request = "2";
                        }
                        break;
                    default:
                        break;
                }
            }
           
            
            Console.ReadKey();
        }
    }

    class Telefono
    {
        private string ModeloTelefono;
        private string Marca;
        private string Tipo;
        private string mpxCamara;
        Chip chipTelefono;
        SistemaOperativo sistemaOperativo;

        public Telefono(string _modeloTelefono, string _marca, string _tipo, string _mpxCamara, string _sistemaOperativo)
        {
            this.ModeloTelefono = _modeloTelefono;
            this.Marca = _marca;
            this.Tipo = _tipo;
            this.mpxCamara = _mpxCamara;
            sistemaOperativo = new SistemaOperativo(_sistemaOperativo);

        }

        public void agregarChip(Chip chip)
        {
            this.chipTelefono = chip;
        }

        public void getInfo()
        {
            Console.WriteLine("Modelo: "+ ModeloTelefono);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Tipo: " + Tipo);
            Console.WriteLine("Mpx de la Camara: " + mpxCamara);            
            Console.Write("Compañia Telefonica: ");
            chipTelefono.getCompany();


        }

        public void getSO()
        {
            Console.Write("Sistema Operativo: ");
            sistemaOperativo.mostrar();
        }

    }

    class Chip
    {
        private string compania;        

        public Chip(string _compania)
        {
            this.compania = _compania;
        }

        public void getCompany()
        {
            Console.WriteLine(this.compania);
        }

    }

    class SistemaOperativo
    {
        private string nombre;
        
        public SistemaOperativo(string _nombre)
        {
            this.nombre = _nombre;

        }

        public void mostrar()
        {
            Console.WriteLine(this.nombre);
        }
    }
}
