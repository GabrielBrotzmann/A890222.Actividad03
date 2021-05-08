using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A890222.Actividad03
{
    class Asiento
    {

        private int nroAsiento;
        private DateTime fecha;
        private Decimal debe;
        private Decimal haber;
        
        public void setNroAsiento(int entrada)
        {
            this.nroAsiento = entrada;
        }

        public int getNroAsiento()
        {
            return this.nroAsiento;
        }

        public void setFecha(DateTime entrada)
        {
            this.fecha = entrada;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }

        public List<Cuenta> Cuentas = new List<Cuenta>();

        public void Imprimir(Asiento asiento, TextWriter impresora)
        {
            String asientoCuentas = "";
            String Debe = "           ";
            String Haber = "                  ";
            impresora.WriteLine(asiento.nroAsiento + "           " + asiento.fecha.ToShortDateString() + " ");

            foreach (Cuenta cuenta in Cuentas)
            {
                asientoCuentas = "";
                asientoCuentas += "\n                      " + cuenta.getCodigoCuenta().ToString();
                if(cuenta.getDebe() == true) 
                { asientoCuentas += Debe + cuenta.getMonto() + "\n                "; }
                else { asientoCuentas += Haber + cuenta.getMonto(); }
                impresora.Write(asientoCuentas);
            }
            
        }

        public Asiento() { }

        public Asiento(int nroasiento, DateTime fecha, String codigoCuenta, Decimal debe, Decimal haber)
        {
            this.nroAsiento = nroasiento;
            this.fecha = fecha;
            this.debe = debe;
            this.haber = haber;
        }

        





    }
}
