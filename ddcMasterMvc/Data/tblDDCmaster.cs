using System.Data.SqlClient;

namespace ddcMasterMvc.Data
{
    public class tblDDCmaster
    {
        public string connectionString { get; set; }

        public string getDHAcode(string mohapCode)
        {
            // Create a connection to the database
            connectionString = "Data Source=localhost;Initial Catalog=DDC_Master;User ID=myUsername;Password=myPassword;Integrated Security=True;MultipleActiveResultSets=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            // Open the connection
            connection.Open();

            // Create a command to execute a SQL query
            SqlCommand command = new SqlCommand("SELECT Drug_DHA FROM tbl_ddc_master$ WHERE Drug_MOHAP = '" + mohapCode +"'", connection);

            // Execute the query and read the results
            string code = (string)command.ExecuteScalar();
                      
            connection.Close();
            return code;

        }

    }
}
