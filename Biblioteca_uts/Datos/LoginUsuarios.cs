using Biblioteca_uts.Models;
using System.Data.SqlClient;
using System.Data;


namespace Biblioteca_uts.Datos
{
    public class LoginUsuarios
    {
        public bool Registro(UsariosModels model)
        {
            bool respuesta;
            if (existeIdentificador(model.Identificador))
            {
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
                        cmd.Parameters.AddWithValue("Calle", model.Calle);
                        cmd.Parameters.AddWithValue("Colonia", model.Colonia);
                        cmd.Parameters.AddWithValue("NroCasa", model.NroCasa);
                        cmd.Parameters.AddWithValue("tipo", model.tipo);
                        cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
                        cmd.Parameters.AddWithValue("Id_Lector", model.Usuario);//Id_Lector
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

            }
            else
            {
                respuesta = false;
            }

            return respuesta;
        }
        public bool existeIdentificador(int Identificador)
        {
            string eIdentificador = "";
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_validarUsuario", conexion);
                cmd.Parameters.AddWithValue("Identificador", Identificador);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        eIdentificador = dr["identificador"].ToString();

                    }
                }

            }
            if (eIdentificador == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public UsariosModels ValidarUsuario(string Identificador, string contraseña)
        {
            UsariosModels _usuario = new UsariosModels();
            var cn = new Conexion();
         
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conexion);
                cmd.Parameters.AddWithValue("identificador", Identificador);
                cmd.Parameters.AddWithValue("contraseña", contraseña);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario.Identificador = Convert.ToInt32(dr["Identificador"]);
                        usuario.Nombres = dr["Nombres"].ToString();
                        usuario.ApePa = dr["ApPa"].ToString();
                        usuario.ApeMa = dr["ApMA"].ToString();
                        usuario.Calle = dr["calle"].ToString();
                        usuario.Colonia = dr["Colonia"].ToString();
                        usuario.NroCasa = dr["NroCasa"].ToString();
                        usuario.tipo = dr["Tipo"].ToString();
                        usuario.Contraseña = dr["Contraseña"].ToString();
                        usuario.Usuario = dr["Usuario"].ToString();
                    }
                }
            }
            return _usuario;

        }
        public bool CambiarContraseña(string Identificador, string contraseña)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CambiarContraseña", conexion);
                    cmd.Parameters.AddWithValue("identificador", Identificador);
                    cmd.Parameters.AddWithValue("contraseña", contraseña);
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
    }
}
