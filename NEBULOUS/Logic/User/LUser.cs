using NEBULOUS.Models.User;
using System.Data.SqlClient;

namespace NEBULOUS.Logic.User
{
    public class LUser
    {
        private readonly string connection_sql;
        SqlConnection sql_connection; 
        public LUser(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
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
        public SqlDataReader Users()
        {
            SqlDataReader reader = null;

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
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return reader;
        }
    }
}
