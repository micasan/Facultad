using System;
using System.Collections;

namespace Facultad
{
    public class CDocentes
    {
        private ArrayList ListaDocentes;

        public CDocentes()
        {
            this.ListaDocentes = new ArrayList();
        }

        public CDocente BuscaDocente (ulong Leg)
        {
            foreach (CDocente Aux in this.ListaDocentes)
            {
                if (Aux.GetLegajo() == Leg) return Aux;
            }
            return null;
        }

        public bool CrearDocente(ulong Leg, string Noms, string Apes)
        {
            if ( this.BuscaDocente(Leg) == null)
            {
                this.ListaDocentes.Add(new CDocente(Leg, Apes, Noms));
                return true;
            }
            return false;
        }

        public string DarDatos ()
        {
            string Ret = "";
            foreach (CDocente Aux in this.ListaDocentes)
            {
                Ret += Aux.DarDatos();
            }
            return Ret;
        }

        public string DarDatos (ulong Cod)
        {
            CDocente AuxDoc = this.BuscaDocente(Cod);
            if (AuxDoc != null) return AuxDoc.DarDatos();
            return "Docente no se encuentra en la lista";
        }

        public void OrdenarDocentes()
        {
            ListaDocentes.Sort();
        }

        public bool EliminarDocente(ulong Cod)
        {
            CDocente Aux = this.BuscaDocente(Cod);
            if (Aux != null)
            {
                this.ListaDocentes.Remove(Aux);
                return true;
            }
            return false;
        }

        public void AsignarMateria (ulong Leg, string NomMat)
        {
            CDocente Aux = this.BuscaDocente(Leg);
            Aux.AsignarMateria(NomMat);
        }
    }
}
