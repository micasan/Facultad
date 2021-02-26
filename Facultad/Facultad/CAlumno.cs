using System;
using System.Collections;

namespace Facultad
{
    public class CAlumno:CPersona, IComparable
    {
        //Variables miembro de instancia
        private float beca;

        //Variables miembro de clase
        private static float cuota;

        //Metodos miembro de instancia
        //Constructores
        //Por defecto
        public CAlumno()
        {
            this.SetLegajo(0);
            this.SetNombres("sin asignar");
            this.SetApellidos("sin asignar");
            this.beca = 0.0F;
        }
        //Parametrizados
        public CAlumno(ulong leg)
        {
            this.SetLegajo(leg);
        }
        public CAlumno(ulong leg, string apes, string noms, float bec)
        {
            this.SetLegajo(leg);
            this.SetNombres(noms);
            this.SetApellidos(apes);
            this.beca = bec;
        }

        //Setters de instancia
        public void SetBeca(float bec)
        { this.beca = bec; }

        //Getters de instancia
        public float GetBeca()
        { return this.beca; }

        //Metodos funcionales de instancia
        public override string DarDatos()
        {
            string ret = "\n\n" + this.GetLegajo().ToString();
            ret += " - " + this.GetApellidos() + ", " + this.GetNombres();
            ret += "\nBeca: " + this.beca.ToString() + "%";
            ret += " - Cuota General: $" + CAlumno.cuota.ToString();
            ret += " - Cuota Personal: $ " + this.DarCuotaPersonal().ToString();
            ret += "\nMaterias que cursa: " + this.MostrarMaterias();
            return ret;
        }
        public float DarCuotaPersonal()
        {
            return CAlumno.cuota * (1 - this.beca / 100);
        }

        //Finalizadores
        //Por defecto
        ~CAlumno()
        {
            //Procedimiento a realizar inmediatamente antes de la destrucción. No es invocable
            Console.Write("AUXILIOOO!!!");
        }
        //Alternativa invocable
        public void Dispose()
        {
            //Tarea a realizar al momento de la invocacion
            System.GC.SuppressFinalize(this); //No ejecutar el finalizador por defecto
        }

        //Metodos miembro de clase
        //Setter de cuota
        public static void SetCuota(float cuot)
        { CAlumno.cuota = cuot; }
        //Getter de cuota
        public static float GetCuota()
        { return CAlumno.cuota; }

        
        public int CompareTo(object obj)
        {
            if (obj is CAlumno)
            {
                return (int)(this.GetLegajo() - ((CAlumno)obj).GetLegajo());
            }
            return int.MaxValue;
        }
    } //Fin de la clase
} //Cierra del espacio de nombre Facultad
