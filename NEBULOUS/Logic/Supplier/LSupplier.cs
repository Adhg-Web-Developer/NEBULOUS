using System.Data.SqlClient;

namespace NEBULOUS.Logic.Supplier
{
    public class LSupplier
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private readonly List<object> AllSuppliers = new List<object>();
        private object ObjOneSupplier;

        public LSupplier(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }
        public List<object> Suppliers()
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getRegisters", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@tableName", "Supplier");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllSuppliers.Add(new
                    {
                        id = (int)reader["id"],
                        supplier = reader["supplier"].ToString(),
                        details = reader["details"].ToString(),
                        date = reader["date"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return AllSuppliers;
        }
        public object ReadOneSupplier(int id)
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
                command.Parameters.AddWithValue("@tableName", "Supplier");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjOneSupplier = new
                    {
                        id = (int)reader["id"],
                        supplier = reader["supplier"].ToString(),
                        details = reader["details"].ToString(),
                        date = reader["date"].ToString(),

                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return ObjOneSupplier;
        }
        public bool CreateSupplier(Models.Supplier.Supplier supplier)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("iSupplier", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@supplier", supplier.supplier);
                command.Parameters.AddWithValue("@details", supplier.details);

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
        public bool DeleteSupplier(int id)
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
                command.Parameters.AddWithValue("@tableName", "Supplier");
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
        public bool ModifySupplier(Models.Supplier.Supplier supplier)
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
                command.Parameters.AddWithValue("@id", supplier.id);
                command.Parameters.AddWithValue("@supplier", supplier.supplier);
                command.Parameters.AddWithValue("@details", supplier.details);
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
