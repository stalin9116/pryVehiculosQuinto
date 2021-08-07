using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data.Linq;

namespace Logica
{
    public class logicUsuarios
    {
        private static dcVehiculoDataContext dc = new dcVehiculoDataContext();

        public static List<USUARIO> getAllUser()
        {
            try
            {
                var resultUsuarios = dc.USUARIO.Where(users => users.usu_status == 'A')
                                                     .OrderBy(data => data.usu_apellidos);



                //SQL 
                //SELECT * FROM USUARIO U INNER JOIN ROL R ON U.rol_id=R.rol_id
                //WHERE usu_status='A'
                //ORDER BY usu_apellidos

                return resultUsuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }



        public static List<USUARIO> getAllUserXApellido(string apellidos)
        {
            try
            {
                var resultUsuarios = dc.USUARIO.Where(users => users.usu_status == 'A'
                                                      && users.usu_apellidos.StartsWith(apellidos)).
                                                      OrderBy(data => data.usu_apellidos);

                return resultUsuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<USUARIO> getAllUserXNombre(string nombre)
        {
            try
            {
                var resultUsuarios = dc.USUARIO.Where(users => users.usu_status == 'A'
                                                      && users.usu_nombres.StartsWith(nombre)).
                                                      OrderBy(data => data.usu_apellidos);

                return resultUsuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<USUARIO> getAllUserXCorreo(string correo)
        {
            try
            {
                var resultUsuarios = dc.USUARIO.Where(users => users.usu_status == 'A'
                                                      && users.usu_correo.StartsWith(correo)).
                                                      OrderBy(data => data.usu_apellidos);

                return resultUsuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<USUARIO> getAllUserXRol(string rolDescripcion)
        {
            try
            {
                var resultUsuarios = dc.USUARIO.Where(users => users.usu_status == 'A'
                                                      && users.ROL.rol_descripcion.StartsWith(rolDescripcion)).
                                                      OrderBy(data => data.usu_apellidos);

                return resultUsuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static USUARIO getUserxId(int userId)
        {
            try
            {
                var resultUsuario = dc.USUARIO.Where(users => users.usu_status == 'A'
                                                     && users.usu_id.Equals(userId)).FirstOrDefault();

                //SQL 
                //SELECT * FROM USUARIO WHERE usu_status='A'

                return resultUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static USUARIO getUserxLogin(string correo, string clave)
        {
            try
            {
                var resultUsuario = dc.USUARIO.FirstOrDefault(user => user.usu_status == 'A'
                                                     && user.usu_correo.Equals(correo)
                                                     && user.usu_password.Equals(clave));

                //SQL 
                //SELECT * FROM USUARIO WHERE usu_status='A'
                //AND usu_correo=@correo
                //AND usu_password=@clave

                return resultUsuario;
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener un Usuario");
            }
        }

        public static bool saveUser(USUARIO dataUsuario)
        {
            try
            {
                bool resultado = false;

                dataUsuario.usu_status = 'A';
                dataUsuario.usu_add = DateTime.Now;
                dataUsuario.usu_password = Logica.Validaciones.Encriptar.GetMD5Hash(dataUsuario.usu_password);

                dc.USUARIO.InsertOnSubmit(dataUsuario);
                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception )
            {
                throw new ArgumentException("Eror al guardar el usuario");
                //Guardar información en un archivo - base de datos - EventLog



            }
        }

        public static bool updateUser(USUARIO dataUsuario)
        {
            try
            {
                bool resultado = false;

                dataUsuario.usu_status = 'A';
                dataUsuario.usu_add = DateTime.Now;

                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool updateUser2(USUARIO dataUsuario)
        {
            try
            {
                bool resultado = false;

                dataUsuario.usu_status = 'A';
                dataUsuario.usu_add = DateTime.Now;

                dc.ExecuteCommand("UPDATE [dbo].[USUARIO] SET [usu_correo] = {0} " +
                                  ",[usu_password] = {1} " +
                                  ",[usu_apellidos] = {2} " +
                                  ",[usu_nombres] = {3} " +
                                  ",[usu_add] = {4} " +
                                  ",[rol_id] = {5} " +
                                  "WHERE [usu_id] = {6}", new object[] {
                    dataUsuario.usu_correo,
                    dataUsuario.usu_password,
                    dataUsuario.usu_apellidos,
                    dataUsuario.usu_nombres,
                    dataUsuario.usu_add,
                    dataUsuario.rol_id,
                    dataUsuario.usu_id
                });

                //Refresh del contexto de datos
                dc.Refresh(RefreshMode.OverwriteCurrentValues, dc.USUARIO);

                //commit de la base
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception )
            {

                throw;
            }
        }

        public static bool updateUser3(USUARIO dataUsuario)
        {
            try
            {
                dc = new dcVehiculoDataContext();

                bool resultado = false;

                dataUsuario.usu_status = 'A';
                dataUsuario.usu_add = DateTime.Now;

                var res = dc.Pcd_UpdateUser(dataUsuario.usu_id, dataUsuario.usu_correo,
                                            dataUsuario.usu_password, dataUsuario.usu_apellidos,
                                            dataUsuario.usu_nombres, dataUsuario.rol_id);

                var resStore = res.FirstOrDefault<Pcd_UpdateUserResult>();
                int resulta = resStore.Column1;
                if (resulta > 0)
                {
                    resultado = true;
                }


                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static bool bloquearUser(USUARIO dataUsuario)
        {
            try
            {
                bool resultado = false;

                dataUsuario.usu_status = 'B';
                dataUsuario.usu_add = DateTime.Now;

                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool deleteUser(USUARIO dataUsuario)
        {
            try
            {
                bool resultado = false;

                dataUsuario.usu_status = 'I';
                dataUsuario.usu_add = DateTime.Now;

                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
