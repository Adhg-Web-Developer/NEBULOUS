using System.Data.SqlClient;

namespace NEBULOUS.Logic.Product.ProductCategory
{
    public class LProductCategory
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private readonly List<object> AllProductCategory = new List<object>();
        private object ObjOneProductCategory;

        public LProductCategory(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }
        public List<object> ProductCategories()
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getRegisters", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@tableName", "ProductCategory");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllProductCategory.Add(new
                    {
                        id = (int)reader["id"],
                        category = reader["category"].ToString(),
                        details = reader["details"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return AllProductCategory;
        }
        public object ReadOneProductCategory(int id)
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
                command.Parameters.AddWithValue("@tableName", "ProductCategory");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjOneProductCategory = new
                    {
                        id = (int)reader["id"],
                        category = reader["category"].ToString(),
                        details = reader["details"].ToString(),
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return ObjOneProductCategory;
        }
        public bool CreateProductCategory(Models.Product.ProductCategory.ProductCategory productCategory)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("iProductCategory", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@category", productCategory.category);
                command.Parameters.AddWithValue("@details", productCategory.details);

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
        public bool DeleteProductCategory(int id)
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
                command.Parameters.AddWithValue("@tableName", "ProductCategory");
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
        public bool ModifySupplier(Models.Product.ProductCategory.ProductCategory productCategory)
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
                command.Parameters.AddWithValue("@id", productCategory.id);
                command.Parameters.AddWithValue("@supplier", productCategory.category);
                command.Parameters.AddWithValue("@details", productCategory.details);
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
