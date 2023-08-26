
using System.Data.SqlClient;
using System.Data;

using Biblioteca_uts.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Biblioteca_uts.Datos
{
    public class UsuarioDatos
    {
        public List<UsariosModels> Listar()
        {
            List<UsariosModels> Lista = new List<UsariosModels>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new UsariosModels()
                        {
                            Identificador = Convert.ToInt32(dr["Identificador"]),
                            Nombres = dr["Nombres"].ToString(),
                            ApePa = dr["ApePa"].ToString(),
                            ApeMa = dr["ApeMa"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Calle = dr["Calle"].ToString(),
                            Colonia = dr["Colonia"].ToString(),
                            NroCasa = dr["NroCasa"].ToString(),
                            tipo = dr["tipo"].ToString(),
                            Contraseña = dr["Contraseña"].ToString(),
                            Usuario = dr["Usuario"].ToString()
                        }
                        );
                    }
                }
            }
            return Lista;
        }
        public UsariosModels ObtenerUsuario(int Identificador)
        {
            UsariosModels Usuario = new UsariosModels();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Buscar_Usuario", conexion);
                cmd.Parameters.AddWithValue("Identificador", Identificador);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        Usuario.Identificador = Convert.ToInt32(dr["Identificador"]);
                        Usuario.Nombres = dr["Nombres"].ToString();
                        Usuario.ApePa = dr["ApePa"].ToString();
                        Usuario.ApeMa = dr["ApeMa"].ToString();
                        Usuario.Correo = dr["Correo"].ToString();
                        Usuario.Calle = dr["Calle"].ToString();
                        Usuario.Colonia = dr["Colonia"].ToString();
                        Usuario.NroCasa = dr["NroCasa"].ToString();
                        Usuario.tipo = dr["tipo"].ToString();
                        Usuario.Contraseña = dr["Contraseña"].ToString();
                        Usuario.Usuario = dr["Usuario"].ToString();

                    
                    }
                }
            }
            return Usuario;
        }
        //###########################################################################
        public bool GuardarUsuario(UsariosModels model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Registrar_Usuario", conexion);
                  
                    cmd.Parameters.AddWithValue("Identificador", model.Identificador);
                    cmd.Parameters.AddWithValue("Nombres", model.Nombres);
                    cmd.Parameters.AddWithValue("ApePa", model.ApePa);
                    cmd.Parameters.AddWithValue("ApeMa", model.ApeMa);
                    cmd.Parameters.AddWithValue("Correo",model.Correo);
                    cmd.Parameters.AddWithValue("Calle", model.Calle);
                    cmd.Parameters.AddWithValue("Colonia", model.Colonia);
                    cmd.Parameters.AddWithValue("NroCasa", model.NroCasa);
                    cmd.Parameters.AddWithValue("tipo", model.tipo);
                    cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
                    cmd.Parameters.AddWithValue("Usuario", model.Usuario);//Id_Lector
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EditarUsuario(UsariosModels model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_Modificar_Usuario", conexion);
                    cmd.Parameters.AddWithValue("Identificador", model.Identificador);
                    cmd.Parameters.AddWithValue("Nombres", model.Nombres);
                    cmd.Parameters.AddWithValue("ApePa", model.ApePa);
                    cmd.Parameters.AddWithValue("ApeMa", model.ApeMa);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Calle", model.Calle);
                    cmd.Parameters.AddWithValue("Colonia", model.Colonia);
                    cmd.Parameters.AddWithValue("NroCasa", model.NroCasa);
                    cmd.Parameters.AddWithValue("tipo", model.tipo);
                    cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
                    cmd.Parameters.AddWithValue("Usuario", model.Usuario);//Id_Lector
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        /*####################################################*/
        public bool EliminarUsuario(int Identificador)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_Eliminar_Usuario", conexion);
                    cmd.Parameters.AddWithValue("Identificador",Identificador);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}