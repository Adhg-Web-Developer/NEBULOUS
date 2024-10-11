using System.Data.SqlClient;

namespace NEBULOUS.Logic.Operation.Operation
{
    public class LOperation
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private readonly List<object> AllOperations = new List<object>();
        private object ObjOneOperation;

        public LOperation(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }
        public List<object> Operations()
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getRegisters", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@tableName", "Operation");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllOperations.Add(new
                    {
                        id = (int)reader["id"],
                        idMovementType = reader["idMovementType"].ToString(),
                        idSupplier = reader["idSupplier"].ToString(),
                        concept = reader["concept"].ToString(),
                        codeReference = reader["codeReference"].ToString(),
                        date = reader["date"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return AllOperations;
        }
        public object ReadOneOperation(int id)
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
                command.Parameters.AddWithValue("@tableName", "Operation");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjOneOperation = new
                    {
                        id = (int)reader["id"],
                        idMovementType = reader["idMovementType"].ToString(),
                        idSupplier = reader["idSupplier"].ToString(),
                        concept = reader["concept"].ToString(),
                        codeReference = reader["codeReference"].ToString(),
                        date = reader["date"].ToString(),
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return ObjOneOperation;
        }
        public bool CreateOperation(Models.Operation.Operation.Operation operation)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("iOperation", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@idMovementType", operation.idMovementType);
                command.Parameters.AddWithValue("@idSupplier", operation.idSupplier);
                command.Parameters.AddWithValue("@concept", operation.concept);
                command.Parameters.AddWithValue("@codeReference", operation.codeReference);

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
        public bool DeleteOperation(int id)
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
                command.Parameters.AddWithValue("@tableName", "Operation");
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
        public bool ModifyOperation(Models.Operation.Operation.Operation operation)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("mSupplier", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@id", operation.id);
                command.Parameters.AddWithValue("@idSupplier", operation.idSupplier);
                command.Parameters.AddWithValue("@concept", operation.concept);
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
