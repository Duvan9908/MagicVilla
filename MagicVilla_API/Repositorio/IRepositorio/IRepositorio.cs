﻿using System.Linq.Expressions;
using MagicVilla_API.Modelos.Especificaciones;

namespace MagicVilla_API.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task Crear(T entidad);

        Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null, string incluirPropiedades = null);

        PagedList<T> ObtenerTodosPaginado(Parametros parametros, Expression<Func<T, bool>>? filtro = null, string incluirPropiedades = null);

        Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true, string incluirPropiedades = null);

        Task Remover(T entidad);

        Task Grabar();
    }
}
