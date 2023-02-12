using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Contratos
{
    public interface IRepositorio<T>
    {
        void Agregar(T entidad);
        void Eliminar(int id);
        void Actualizar(T entidad);
        T ObtenerPorId(int id);
        //int Contar(Expression<Func<T, bool>> where);
        //IEnumerable<T> EncontrarPor(ParametrosDeQuery<T> parametrosDeQuery);
    }
}
