using System.Data.SqlClient;

namespace NEBULOUS.Logic.Product.ProductBrands
{
    public class LProductBrands
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private readonly List<object> AllProductBrands = new List<object>();
        private object ObjOneProductBrands;

        public LProductBrands(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }
        public List<object> ProductBrands()
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getRegisters", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@tableName", "ProductBrands");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllProductBrands.Add(new
                    {
                        id = (int)reader["id"],
                        supplier = reader["idSupplier"].ToString(),
                        details = reader["brand"].ToString(),

                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return AllProductBrands;
        }
        public object ReadOneProductBrands(int id)
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
                command.Parameters.AddWithValue("@tableName", "ProductBrands");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjOneProductBrands = new
                    {
                        id = (int)reader["id"],
                        supplier = reader["idSupplier"].ToString(),
                        details = reader["brand"].ToString(),


                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return ObjOneProductBrands;
        }
        public bool CreateProductBrands(Models.Product.ProductBrands.ProductBrands productBrands)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("iProductBrands", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@idSupplier", productBrands.idSupplier);
                command.Parameters.AddWithValue("@brand", productBrands.brand);

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
        public bool DeleteProductBrands(int id)
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
                command.Parameters.AddWithValue("@tableName", "ProductBrands");
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
        public bool ModifyProductBrands(Models.Product.ProductBrands.ProductBrands productBrands)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("mProductBrands", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@id", productBrands.id);
                command.Parameters.AddWithValue("@idSupplier", productBrands.idSupplier);
                command.Parameters.AddWithValue("@brand", productBrands.brand);
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
