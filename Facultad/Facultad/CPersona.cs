using System.Collections;

namespace Facultad
{
    public abstract class CPersona
    {
        private string nombres;
        private string apellidos;
        private ulong legajo;
        private ArrayList NomsMat = new ArrayList();

        public void SetNombres(string noms)
        { this.nombres = noms; }
        public void SetApellidos(string apes)
        { this.apellidos = apes; }
        public void SetLegajo(ulong leg)
        { this.legajo = leg; }

        public string GetNombres()
        { return this.nombres; }
        public string GetApellidos()
        { return this.apellidos; }
        public ulong GetLegajo()
        { return this.legajo; }

        

        public void AgregarMateria (string Nom)
        {
            this.NomsMat.Add(Nom);
        }

        public void EliminarMateria (string Nom)
        {
            this.NomsMat.Remove(Nom);
        }

        public string MostrarMaterias()
        {
            string ret = "";
            if (this.NomsMat == null)
            {
                return "No hay materias asignadas";
            }
            foreach (string Aux in this.NomsMat)
            {
                ret += "\n\t" + Aux;
            }
            return ret;
        }

        public bool BuscarMateria (string Nom)
        {
            foreach (string Aux in this.NomsMat)
            {
                if (Aux == Nom) return true;
            }
            return false;
        }

        public int CantidadMaterias()
        {
            return this.NomsMat.Count;
        }

        public abstract string DarDatos();

    }
}
