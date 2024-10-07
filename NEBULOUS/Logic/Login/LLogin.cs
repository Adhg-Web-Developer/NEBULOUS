using System.Data.SqlClient;

namespace NEBULOUS.Logic.Login
{
    public class LLogin
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private object ObjSession;
        private object ObjUser;

        public LLogin(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }

        public object authSession(Models.User.User user) {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getSession", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@user_", user.user_);
                command.Parameters.AddWithValue("@password_", user.password_);
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjSession = new
                    {
                        id = (int)reader["id"],
                        idUser = (int)reader["idUser"],
                        user_ = reader["user_"].ToString(),
                        password_ = reader["password_"].ToString(),
                        idUserType = (int)reader["idUserType"],
                        state = reader["state"].ToString(),
                        date = reader["date"].ToString(),

                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sql_connection.Close();

                // Actualizar el estado de sesión del usuario
                this.updateSession(ObjSession);
            }

            return this.updateSession(ObjSession);
        }
        public object updateSession(object session)
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                if (session != null)
                {
                    // Invocar el procedimiento de almacenado
                    SqlCommand command = new SqlCommand("mSession", sql_connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Parámetros
                    command.Parameters.AddWithValue("@id", session.GetType().GetProperty("id").GetValue(ObjSession, null));
                    command.Parameters.AddWithValue("@state", "Activo");
                    // Ejecutar el procedimiento
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }
            if (session != null) { 
                return this.getOneRegister(int.Parse(session.GetType().GetProperty("id").GetValue(ObjSession, null).ToString()), "Activo", int.Parse(session.GetType().GetProperty("idUserType").GetValue(ObjSession, null).ToString()));
            }
            else
            {
                return new
                {
                    id = false,
                    firstName = "",
                    lastName = "",
                    idUserType = false,
                    stateSession = "False"
                };
            }
        }
        public object getOneRegister(int id, string state_session, int id_user_type)
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getOneRegister", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@tableName", "User_");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjUser = new
                    {
                        id = (int)reader["id"],
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        idUserType = id_user_type,
                        stateSession = state_session,
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }

            return ObjUser;
        }
        public bool logOut(string id)
        {
            bool res = false;

            Console.WriteLine(id);

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("mSession", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@id", int.Parse(id));
                command.Parameters.AddWithValue("@state", "Inactivo");
                // Ejecutar el procedimiento
                command.ExecuteNonQuery();
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sql_connection.Close();
            }

            return res;
        }
    }
}
