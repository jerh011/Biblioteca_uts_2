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
            if (existeUsuario(model.Contraseña))
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
                        cmd.Parameters.AddWithValue("Correo",model.Correo);
                        cmd.Parameters.AddWithValue("Calle", model.Calle);
                        cmd.Parameters.AddWithValue("Colonia", model.Colonia);
                        cmd.Parameters.AddWithValue("NroCasa", model.NroCasa);
                        cmd.Parameters.AddWithValue("tipo", model.tipo);
                        cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
                        cmd.Parameters.AddWithValue("Usuario", model.Usuario);
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
        /////////////////////////////////////////Validaciones con Usaurio//////////////////////////////////////////////////////////
        public bool existeUsuario(string Usuario)
        {
            string eIdentificador = "";
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario_existente", conexion);
                cmd.Parameters.AddWithValue("Usuario", Usuario);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        eIdentificador = dr["Usuario"].ToString();

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
        public UsariosModels ValidarUsuario(string Usuario, string contraseña)
        {
            UsariosModels usuario = new UsariosModels();


            UsariosModels _usuario = new UsariosModels();


            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conexion);
                cmd.Parameters.AddWithValue("Usuario", Usuario);
                cmd.Parameters.AddWithValue("Contraseña", contraseña);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario.Identificador = Convert.ToInt32(dr["Identificador"]);
                        usuario.Nombres = dr["Nombres"].ToString();
                        usuario.ApePa = dr["ApePa"].ToString();
                        usuario.ApeMa = dr["ApeMa"].ToString();
                        usuario.Correo = dr["Correo"].ToString();
                        usuario.Calle = dr["calle"].ToString();
                        usuario.Colonia = dr["Colonia"].ToString();
                        usuario.NroCasa = dr["NroCasa"].ToString();
                        usuario.tipo = dr["Tipo"].ToString();
                        usuario.Contraseña = dr["Contraseña"].ToString();
                        usuario.Usuario = dr["Usuario"].ToString();
                    }
                }
            }

            return usuario;




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
                    cmd.Parameters.AddWithValue("Usuario", Identificador);
                    cmd.Parameters.AddWithValue("Contraseña", contraseña);
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
        /////////////////////////////////////////Validaciones con cooreo//////////////////////////////////////////////////////////
        public bool existeCorreo(string Correo)
        {
            string eIdentificador = "";
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ValidarCorreo", conexion);
                cmd.Parameters.AddWithValue("Correo", Correo);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        eIdentificador = dr["Correo"].ToString();

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
        public UsariosModels ValidarCorreo(string Correo, string contraseña)
        {
            UsariosModels usuario = new UsariosModels();


            UsariosModels _usuario = new UsariosModels();


            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario_con_correo", conexion);
                cmd.Parameters.AddWithValue("Correo", Correo);
                cmd.Parameters.AddWithValue("Contraseña", contraseña);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        usuario.Identificador = Convert.ToInt32(dr["Identificador"]);
                        usuario.Nombres = dr["Nombres"].ToString();
                        usuario.ApePa = dr["ApePa"].ToString();
                        usuario.ApeMa = dr["ApeMa"].ToString();
                        usuario.Correo = dr["Correo"].ToString();
                        usuario.Calle = dr["calle"].ToString();
                        usuario.Colonia = dr["Colonia"].ToString();
                        usuario.NroCasa = dr["NroCasa"].ToString();
                        usuario.tipo = dr["Tipo"].ToString();
                        usuario.Contraseña = dr["Contraseña"].ToString();
                        usuario.Usuario = dr["Usuario"].ToString();
                    }
                }
            }

            return usuario;




        }






    }
}

