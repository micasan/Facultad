using System;
using System.Collections;

namespace Facultad
{
    public class CDocente:CPersona, IComparable
    {
        //Variables miembro de instancia
        private float Sueldo;

        //Metodos miembro de instancia
        //Constructores
        //Por defecto
        public CDocente()
        {
            this.SetLegajo(0);
            this.SetNombres("sin asignar");
            this.SetApellidos("sin asignar");
            this.Sueldo = 0.0F;
        }
        //Parametrizados
        public CDocente (ulong Cod)
        {
            this.SetLegajo(Cod);
        }
        public CDocente (ulong cod, string apes, string noms)
        {
            this.SetLegajo(cod);
            this.SetNombres(noms);
            this.SetApellidos(apes);
            this.Sueldo = this.CalcularSueldo();
        }

        //Setters de instancia
        /*public void SetSueldo (float suel)
        { this.Sueldo = suel; }
        */
        //Getters de instancia
        public float GetSueldo()
        { return this.Sueldo; }

        //Metodos funcionales de instancia
        public override string DarDatos()
        {
            string ret = "\n\n" + this.GetLegajo().ToString();
            ret += "  -  " + this.GetApellidos() + ", " + this.GetNombres();
            ret += "\n  -  Sueldo: " + this.CalcularSueldo().ToString();
            ret += "\nMaterias que dicta: " + this.MostrarMaterias();
            return ret;
        }

        public void AsignarMateria(string NomMat)
        {
            this.AgregarMateria(NomMat);
        }

        public float CalcularSueldo ()
        {
            return 1000 * this.CantidadMaterias();
        }

        //Finalizadores
        //Por defecto
        ~CDocente()
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


        public int CompareTo(object obj)
        {
            if (obj is CDocente)
            {
                return (int)(this.GetLegajo() - ((CDocente)obj).GetLegajo());
            }
            return int.MaxValue;
        }
    }
}
