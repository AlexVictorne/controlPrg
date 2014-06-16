using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace controlPrg
{
    class DBWorker
    {
        public DBWorker()
        { }
        public void saveXml_to_database(string set, string decsription, string xml_data)
        {
            string str = "INSERT INTO [Table_Data] (Classifier, Description, Data) VALUES (N'" + set + "', N'" + decsription + "', N'" + xml_data + "')";
            string strConnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(strConnection);
            connection.Open();
            SqlCommand command = new SqlCommand(str, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public void Save_to_DataBase(int neuron,double weight,string classifier)
        {
            string str = "INSERT INTO [Table] (neuron, classifier, weight) VALUES (" + neuron + ", N'" + classifier + "', "+weight + ")";
            string strConnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(strConnection);
            
            connection.Open();
            SqlCommand command = new SqlCommand(str, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public string ReadXml_from_DataBase(string Classifier,string description)
        {
            Skeleton sk = new Skeleton();
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
            string queryString = "SELECT Description, Data FROM  [Table_Data] where classifier=N'" + Classifier + "' and Description=N'"+description+"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader[1].ToString();
                }
                reader.Close();
                connection.Close();
            }
            return "000";
        }
        public List<NeuronWithWeight> Read_from_DataBase(string classifier)
        {
            List<NeuronWithWeight> list_nww = new List<NeuronWithWeight>();
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
            string queryString = "SELECT neuron, weight FROM  [Table] where classifier=N'" + classifier + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list_nww.Add(new NeuronWithWeight(Convert.ToInt32(reader[0]), Convert.ToDouble(reader[1])));
                }
                reader.Close();
                connection.Close();
            }
            return list_nww;
        }
        

    }
}
