using System;
using System.Collections;

namespace Facultad
{
    public class CAlumnos
    {
        //Variables Miembro
        private ArrayList ListaAlum;

        //Constructor
        public CAlumnos()
        {
            this.ListaAlum = new ArrayList();
        }
        //Metodos
        public CAlumno BuscarAlumno(ulong leg)
        {
            foreach (CAlumno aux in this.ListaAlum)
            {
                if (aux.GetLegajo() == leg) return aux;
            }
            return null;
        }

        public bool CrearAlumno(ulong Leg, string Ape, string Nom, float Beca)
        {
            if (this.BuscarAlumno(Leg) == null)
            {
                this.ListaAlum.Add(new CAlumno(Leg,Ape,Nom,Beca));
                return true;
            }
            return false;
        }

        public string DarDatos(ulong Leg)
        {
            CAlumno Aux = this.BuscarAlumno(Leg);
            if (Aux != null) return Aux.DarDatos();
            return "Alumno inexistente";
        }

        public string DarDatos()
        {

            if (this.ListaAlum.Count != 0)
            {
                String datos = "";
                foreach (CAlumno aux in this.ListaAlum) datos += aux.DarDatos() + "\n";
                return datos;
            }
            return "No se registraron alumnos válidos";
        }


        public bool EliminarAlumno(ulong leg)
        {
            CAlumno aux = this.BuscarAlumno(leg);
            if (aux != null)
            {
                this.ListaAlum.Remove(aux);
                return true;
            }
            return false;
        }


        public void SetCuota(float cuo)
        {
            CAlumno.SetCuota(cuo);
        }


        public float GetCuota()
        {
            return CAlumno.GetCuota();
        }

        public float DarCuotaPersonal(ulong leg)
        {
            CAlumno aux = this.BuscarAlumno(leg);
            if (aux != null) return aux.DarCuotaPersonal();
            return 0.0f;
        }

        public int DarCantidad()
        {
            return ListaAlum.Count;
        }

        public void Ordenar()
        {
            this.ListaAlum.Sort();
        }
    }
}

