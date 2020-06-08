using RegistroUsuario.DAL;
using RegistroUsuario.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace RegistroUsuario.BLL
{
    public class UsuariosBLL
    {

    public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.UsuarioId))
                return Insertar(usuario);
                    else
                return Modificar(usuario);
        }

        private static bool Insertar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Usuarios.Add(usuario);
                paso = contexto.SaveChanges() > 0;
            }
            catch 
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        
        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally 
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var usuario = contexto.Usuarios.Find(id);

                if (usuario != null)
                {
                    contexto.Usuarios.Remove(usuario);
                    paso = contexto.SaveChanges() > 0;
                }
                }
                    catch
                {
                    throw;
                }
                    finally
                {
                    contexto.Dispose();
                }

               return paso;
        }

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuario;

            try
            {
                usuario = contexto.Usuarios.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return usuario;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuarios.Any(e => e.UsuarioId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Usuarios.Where(criterio).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;

        }

        public static List<Usuarios> GetUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Usuarios.ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
