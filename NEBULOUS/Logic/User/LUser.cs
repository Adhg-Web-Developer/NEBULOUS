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
                command.Parameters.AddWithValue("@FirstName", user.firstName);
                command.Parameters.AddWithValue("@LastName", user.lastName);
                command.Parameters.AddWithValue("@User_", user.user_);
                command.Parameters.AddWithValue("@Password_", user.password_);
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
