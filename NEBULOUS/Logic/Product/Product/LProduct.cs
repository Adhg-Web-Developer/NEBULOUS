using System.Data.SqlClient;
using System.Xml.Linq;

namespace NEBULOUS.Logic.Product.Product
{
    public class LProduct
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private readonly List<object> AllProducts = new List<object>();
        private object ObjOneProduct;

        public LProduct(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }
        public List<object> Products()
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getRegisters", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@tableName", "Product");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllProducts.Add(new
                    {
                        id = (int)reader["id"],
                        idProductSubCategory = reader["idProductSubCategory"].ToString(),
                        idBrand = reader["idBrand"].ToString(),
                        idCategory = reader["idCategory"].ToString(),
                        unity = reader["unity"].ToString(),
                        extent = reader["extent"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return AllProducts;
        }
        public object ReadOneProduct(int id)
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
                command.Parameters.AddWithValue("@tableName", "Product");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjOneProduct = new
                    {
                        id = (int)reader["id"],
                        idProductSubCategory = reader["idProductSubCategory"].ToString(),
                        idBrand = reader["idBrand"].ToString(),
                        idCategory = reader["idCategory"].ToString(),
                        unity = reader["unity"].ToString(),
                        extent = reader["extent"].ToString(),
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return ObjOneProduct;
        }
        public bool CreateProduct(Models.Product.Product.Product product)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("iProduct", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@idProductSubCategory", product.idProductSubCategory);
                command.Parameters.AddWithValue("@idBrand", product.idBrand);
                command.Parameters.AddWithValue("@idCategory", product.idCategory);
                command.Parameters.AddWithValue("@unity", product.unity);
                command.Parameters.AddWithValue("@extent", product.extent);

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
        public bool DeleteProduct(int id)
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
                command.Parameters.AddWithValue("@tableName", "Product");
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
        public bool ModifyProduct(Models.Product.Product.Product product)
        {
            bool res = false;

            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("mProduct", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@id", product.id);
                command.Parameters.AddWithValue("@idProductSubCategory", product.idProductSubCategory);
                command.Parameters.AddWithValue("@idBrand", product.idBrand);
                command.Parameters.AddWithValue("@idCategory", product.idCategory);
                command.Parameters.AddWithValue("@unity", product.unity);
                command.Parameters.AddWithValue("@extent", product.extent);
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
