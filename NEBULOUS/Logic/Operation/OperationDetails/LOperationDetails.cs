using NEBULOUS.Models.Operation.OperationDetails;
using System.Data.SqlClient;

namespace NEBULOUS.Logic.Operation.OperationDetails
{
    public class LOperationDetails
    {
        private readonly string connection_sql;
        SqlConnection sql_connection;
        private readonly List<object> AllOperationDetails = new List<object>();
        private object ObjOneOperationDetail;

        public LOperationDetails(string connection_sql)
        {
            this.connection_sql = connection_sql;
            sql_connection = new SqlConnection(connection_sql);
        }
        public List<object> OperationDetails()
        {
            try
            {
                // Abrir conexión
                sql_connection.Open();
                // Invocar el procedimiento de almacenado
                SqlCommand command = new SqlCommand("getRegisters", sql_connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // Parámetros
                command.Parameters.AddWithValue("@tableName", "OperationDetail");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllOperationDetails.Add(new
                    {
                        id = (int)reader["id"],
                        idMovementType = reader["idMovementType"].ToString(),
                        codeReferenceOperation = reader["codeReferenceOperation"].ToString(),
                        idProduct = reader["idProduct"].ToString(),
                        unityCost = reader["unityCost"].ToString(),
                        unityPrice = reader["unityPrice"].ToString(),
                        amout = reader["amount"].ToString(),
                        subtotal = reader["subtotal"].ToString(),
                        date = reader["date"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return AllOperationDetails;
        }
        public object ReadOneOperationDetails(int id)
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
                command.Parameters.AddWithValue("@tableName", "OperationDetail");
                // Ejecutar el procedimiento
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ObjOneOperationDetail = new
                    {
                        id = (int)reader["id"],
                        idMovementType = reader["idMovementType"].ToString(),
                        codeReferenceOperation = reader["codeReferenceOperation"].ToString(),
                        idProduct = reader["idProduct"].ToString(),
                        unityCost = reader["unityCost"].ToString(),
                        unityPrice = reader["unityPrice"].ToString(),
                        amout = reader["amount"].ToString(),
                        subtotal = reader["subtotal"].ToString(),
                        date = reader["date"].ToString(),
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return ObjOneOperationDetail;
        }
        public bool CreateOperationDetails(Models.Operation.OperationDetails.OperationDetail operationDetail)
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
                command.Parameters.AddWithValue("@idMovementType", operationDetail.idMovementType);
                command.Parameters.AddWithValue("@codeReferenceOperation", operationDetail.codeReferenceOperation);
                command.Parameters.AddWithValue("@idProduct", operationDetail.idProduct);
                command.Parameters.AddWithValue("@unityCost", operationDetail.unityCost);
                command.Parameters.AddWithValue("@unityPrice", operationDetail.unityPrice);
                command.Parameters.AddWithValue("@amout", operationDetail.amout);
                command.Parameters.AddWithValue("@subTotal", operationDetail.subTotal);

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
        public bool DeleteOperationDetails(int id)
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
                command.Parameters.AddWithValue("@tableName", "OperationDetail");
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
        public bool ModifyOperationDetails(Models.Operation.OperationDetails.OperationDetail operationDetail)
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
                command.Parameters.AddWithValue("@id", operationDetail.id);
                command.Parameters.AddWithValue("@idMovementType", operationDetail.idMovementType);
                command.Parameters.AddWithValue("@codeReferenceOperation", operationDetail.codeReferenceOperation);
                command.Parameters.AddWithValue("@idProduct", operationDetail.idProduct);
                command.Parameters.AddWithValue("@unityCost", operationDetail.unityCost);
                command.Parameters.AddWithValue("@unityPrice", operationDetail.unityPrice);
                command.Parameters.AddWithValue("@amout", operationDetail.amout);
                command.Parameters.AddWithValue("@subTotal", operationDetail.subTotal);
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
