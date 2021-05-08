using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A890222.Actividad03
{
    class Cuenta
    {
        private int codigoCuenta;
        private decimal monto;
        private bool debe;
        public override string ToString()
        {
            String debeHaber;
            if (debe == true) 
            { debeHaber = "debe"; }
            else { debeHaber = "haber"; }
            return this.codigoCuenta + this.monto + debeHaber;
        }

        public Cuenta() { }

        public int getCodigoCuenta()
        {
            return this.codigoCuenta;
        }

        public decimal getMonto()
        {
            return this.monto;
        }

        public bool getDebe()
        {
            return this.debe;
        }

        public void setCodigoCuenta(int entrada)
        {
            this.codigoCuenta = entrada;
        }

        public void setMonto(decimal entrada)
        {
            this.monto = entrada;
        }

        public void setDebe(bool entrada)
        {
            this.debe = entrada;
        }


    }
}
