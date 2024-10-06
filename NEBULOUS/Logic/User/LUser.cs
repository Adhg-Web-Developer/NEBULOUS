using System.Data.SqlClient;

namespace NEBULOUS.Logic.User
{
    public class LUser
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private readonly List<object> AllUsers = new List<object>();
        private object ObjOneUser;

        public LUser(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }
        public List<object> Users()
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getRegisters", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@tableName", "allUser´sData");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllUsers.Add(new
                    {
                        id = (int)reader["id"],
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        state = reader["state"].ToString(),
                        user_ = reader["user_"].ToString(),
                        password_ = reader["password_"].ToString(),
                        date = reader["date"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return AllUsers;
        }
        public object ReadOneUser(int id)
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
                    ObjOneUser = new
                    {
                        id = (int)reader["id"],
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        state = reader["state"].ToString(),
                        user_ = reader["user_"].ToString(),
                        password_ = reader["password_"].ToString(),
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
            }

            return ObjOneUser;
        }
        public bool CreateUser(Models.User.User user) {
			bool res = false;

            try
			{
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("iUser", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@firstName", user.firstName);
                command.Parameters.AddWithValue("@lastName", user.lastName);
                command.Parameters.AddWithValue("@user_", user.user_);
                command.Parameters.AddWithValue("@password_", user.password_);

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
        public bool DeleteUser(int id)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("dataDelete", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@codeReferenceOp", "");
                command.Parameters.AddWithValue("@tableName", "User_");
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
        public bool ModifyUser(Models.User.User user)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("mUser", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@id", user.id);
                command.Parameters.AddWithValue("@firstName", user.firstName);
                command.Parameters.AddWithValue("@lastName", user.lastName);
                command.Parameters.AddWithValue("@user_", user.user_);
                command.Parameters.AddWithValue("@password_", user.password_);
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
