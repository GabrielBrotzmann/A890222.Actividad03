using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A890222.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            LibroDiario diario = new LibroDiario() ;

            TextWriter escribir = new StreamWriter("Diario.txt");
            escribir.WriteLine("NroAsiento | Fecha | CodigoCuenta | Debe | Haber");
            escribir.Close();

            bool menu = true;

            do
            {
                Console.Clear();
                Console.WriteLine(

                    "Menu principal: \n " +
                    "1: Ingresar un asiento nuevo \n " +
                    
                    "5: Salir del sistema \n ");

                int opcion = -1;

                do
                {
                    if (!int.TryParse(Console.ReadLine(), out opcion))
                    {
                        opcion = -1;
                    }
                    if (opcion < 0)
                    {
                        Console.WriteLine("El valor ingresado no es válido, intente nuevamente ingresando una de las opciones");
                    }
                } while (opcion < 0);

                switch (opcion)
                {
                    case 1:
                        diario.ingresoDeAsiento(diario.Asientos, escribir, diario);
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        break;
                    case 5:
                        menu = false;
                        Console.WriteLine("Presione cualquier tecla para finalizar");
                        break;


                    default:
                        Console.WriteLine("Opcion invalida, intente nuevamente");
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadKey();
                        break;
                }

            } while (menu);







        }
    }
}
