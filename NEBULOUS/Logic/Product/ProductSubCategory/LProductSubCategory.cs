using System.Data.SqlClient;

namespace NEBULOUS.Logic.Product.ProductSubCategory
{
    public class LProductSubCategory
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private readonly List<object> AllProductSubCategory = new List<object>();
        private object ObjOneProductSubCategory;

        public LProductSubCategory(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }
        public List<object> ProductSubCategories()
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getRegisters", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@tableName", "ProductSubCategory");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllProductSubCategory.Add(new
                    {
                        id = (int)reader["id"],
                        idProductCategory = reader["idProductCategory"].ToString(),
                        product = reader["product"].ToString(),
                        details = reader["details"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return AllProductSubCategory;
        }
        public object ReadOneProductSubCategory(int id)
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
                command.Parameters.AddWithValue("@tableName", "ProductSubCategory");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjOneProductSubCategory = new
                    {
                        id = (int)reader["id"],
                        idProductCategory = reader["idProductCategory"].ToString(),
                        product = reader["product"].ToString(),
                        details = reader["details"].ToString(),
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return ObjOneProductSubCategory;
        }
        public bool CreateProductSubCategory(Models.Product.ProductSubCategory.ProductSubCategory productSubCategory)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("iProductSubCategory", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@idProductCategory", productSubCategory.idProductCategory);
                command.Parameters.AddWithValue("@product", productSubCategory.product);
                command.Parameters.AddWithValue("@details", productSubCategory.details);

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
        public bool DeleteProductSubCategory(int id)
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
                command.Parameters.AddWithValue("@tableName", "ProductSubCategory");
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
        public bool ModifyProductSubCategory(Models.Product.ProductSubCategory.ProductSubCategory productSubCategory)
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
                command.Parameters.AddWithValue("@id", productSubCategory.id);
                command.Parameters.AddWithValue("@idProductCategory", productSubCategory.idProductCategory);
                command.Parameters.AddWithValue("@product", productSubCategory.product);
                command.Parameters.AddWithValue("@details", productSubCategory.details);
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
