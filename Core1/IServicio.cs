using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core1
{
    public interface IServicio
    {
        void Validar(string token);

        int GetNota(int CI);

        List<Alumno> GetAlumnos();
        string GetEstadoNota(int nota);
    }
}
