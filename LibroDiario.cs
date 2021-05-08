using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A890222.Actividad03
{
    class LibroDiario
    {
        public List<Asiento> Asientos = new List<Asiento>();
        int numeroAsiento = 1;

        public void ingresoDeAsiento(List<Asiento> lista, TextWriter impresora, LibroDiario libro)
        {
            Asiento asiento = new Asiento();
            asiento.setNroAsiento(numeroAsiento);
            
            int nombre = 0;
            DateTime ahora = DateTime.Now;
            DateTime DosMil = new DateTime(2000, 1, 1);
            String fechaString;
            int condicion = -1;


            do
            {
                //System.FormatException
                int condicionDate = -1;
                DateTime Fecha;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese la fecha del asiento en formato yyyy-mm-dd");
                    if (DateTime.TryParse(Console.ReadLine(), out Fecha))
                    {
                        
                    }
                    else
                    {
                        Console.WriteLine("El formato de la fecha no es válido, presione enter para continuar");
                        Console.ReadKey();
                    }
                    if (Fecha.CompareTo(ahora) < 0 && Fecha.CompareTo(DosMil) > 0)
                    {
                        asiento.setFecha(Fecha);
                        condicionDate = 0;
                        condicion = 0;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar una fecha entre el año 2000 y hoy");
                        Console.ReadKey();
                    }
                } while (condicionDate < 0);
            } while (condicion < 0);
        



                /*do
                {
                    //System.FormatException
                    int condicionDate = -1;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese la fecha del asiento en formato yyyy-mm-dd");
                        fechaString = Console.ReadLine();
                        DateTime Fecha;
                        try { Fecha = DateTime.Parse(fechaString); }
                        catch (FormatException e) 
                        {
                            Console.WriteLine(e.Message + "\n El valor ingresado no corresponde al formato yyyy-mm-dd, intente de nuevo" ); ;
                                }
                        if(Fecha.CompareTo(ahora)<0 && Fecha.CompareTo(DosMil)>0)
                        {
                            asiento.setFecha(Fecha);
                            condicionDate = 0;
                            condicion = 0;

                        }
                        else
                        {
                            Console.WriteLine("Debe ingresar una fecha en formato yyyy-mm-dd");
                            Console.ReadKey();
                        }
                    } while (condicionDate < 0);
                } while (condicion < 0);*/

            do
            {
                nombre = 0;
                Console.Clear();
                Cuenta cuenta = new Cuenta();

                int numeroCuenta = -1;
                do
                {
                    int opcion2 = -1;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese el número de la cuenta");
                        if (!int.TryParse(Console.ReadLine(), out opcion2))
                        {
                            opcion2 = -1;
                        }
                        if (opcion2 < 0)
                        {
                            Console.WriteLine("El valor ingresado no es válido, intente nuevamente ingresando un numero entero positivo");
                            Console.ReadKey();
                        }
                    } while (opcion2 < 0);

                    if (10 < opcion2 || opcion2 < 35)
                    {
                        numeroCuenta = 0;
                        cuenta.setCodigoCuenta(opcion2);
                    }
                    else
                    {
                        Console.WriteLine("El valor ingresado no es válido, intente nuevamente ingresando un numero que se refiera al código de una cuenta");
                        Console.ReadKey();
                    }
                } while (numeroCuenta < 0);



                int opcion3 = -1;
                do
                {
                    Console.Clear();
                    Console.WriteLine("El ingreso de la siguiente cuenta pertenece al debe o al haber?\n" +
                    "1: Debe \n " +
                    "2: Haber \n ");
                    if (!int.TryParse(Console.ReadLine(), out opcion3))
                    {
                        opcion3 = -1;
                    }
                    if (opcion3 < 0)
                    {
                        Console.WriteLine("El valor ingresado no es válido, intente nuevamente ingresando un numero que corresponda a una opción");
                        Console.ReadKey();
                    }
                } while (opcion3 < 0);

                switch (opcion3)
                {
                    case 1:
                        cuenta.setDebe(true);
                        Console.ReadKey();
                        break;
                    case 2:
                        cuenta.setDebe(false);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, intente nuevamente");
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadKey();
                        break;
                }

                decimal opcion4 = -1;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el monto de la cuenta");
                    if (!decimal.TryParse(Console.ReadLine(), out opcion4))
                    {
                        opcion4 = -1;
                    }
                    if (opcion4 < 0)
                    {
                        Console.WriteLine("El valor ingresado no es válido, intente nuevamente ingresando un numero positivo");
                        Console.ReadKey();
                    }
                } while (opcion4 < 0);

                cuenta.setMonto(opcion4);

                asiento.Cuentas.Add(cuenta);

                Console.WriteLine("La cuenta se ingresó correctamente, desea agregar otra cuenta al asiento?\n" +
                    "1: Si \n " +
                    "2: No \n ");

                int opcion5 = -1;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out opcion5))
                    {
                        opcion5 = -1;
                    }
                    if (opcion5 < 0)
                    {
                        Console.WriteLine("El valor ingresado no es válido, intente nuevamente ingresando un numero entero positivo");
                        Console.ReadKey();
                    }
                } while (opcion5 < 0);

                switch (opcion5)
                {
                    case 1:

                        break;
                    case 2:
                        decimal debe = 0, haber = 0;
                        foreach (Cuenta cnta in asiento.Cuentas)
                        {
                            if (cnta.getDebe() == true)
                            {
                                debe += cnta.getMonto();
                            }
                            else
                            {
                                haber += cuenta.getMonto();
                            }
                        }
                        if (debe == haber)
                        {
                            lista.Add(asiento);
                            TextWriter escribir = File.AppendText("Diario.txt");
                            asiento.Imprimir(asiento, escribir);
                            escribir.Close();
                            Console.WriteLine("El asiento se ha agregado correctamente, presione enter para continuar");
                            nombre = 1;
                            numeroAsiento++;
                        }
                        else
                        {
                            Console.WriteLine("El debe no es igual al haber, intente nuevamente");
                            Console.ReadKey();
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, intente nuevamente");
                        Console.WriteLine("Presione enter para continuar");
                        Console.ReadKey();
                        break;
                }

            } while (nombre == 0);
        }


    }
}

