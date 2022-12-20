using System.Data.SqlClient;

namespace SQLAcademiesZR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetData(1);
            //GetAllDatas();
            //Insert();
            //Delete(6);
            //Update(5);
        }
        //***********GetData*****************************************************************************************************************************************
        public static void GetData(int id)
        {
            string connectionString = "Server=LAPTOP-TTJ08ARE\\SQLEXPRESS;Database=AcademiesDB_ZR;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT Name,Surname,Age,Adulthood,GroupID FROM Students WHERE id={id}", connection);

                string data = (string)command.ExecuteScalar();
                Console.WriteLine(data);
            }
        }
        //***********GetAllDatas*****************************************************************************************************************************************

        public static void GetAllDatas()
        {
            string connectionString = "Server=LAPTOP-TTJ08ARE\\SQLEXPRESS;Database=AcademiesDB_ZR;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM Students", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} - {reader[1]} - {reader[2]} - {reader[3]} - {reader[4]} - {reader[5]}");
                    }
                }
            }
        }
        //***********Insert*****************************************************************************************************************************************
        public static void Insert()
        {
            string connectionString = "Server=LAPTOP-TTJ08ARE\\SQLEXPRESS;Database=AcademiesDB_ZR;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Students Values ('Kerim','Malik',22,'true',1)", connection);

                int check = command.ExecuteNonQuery();

                if (check > 0)
                {
                    Console.WriteLine("Inserted");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        //***********Delete*****************************************************************************************************************************************

        public static void Delete(int id)
        {
            string connectionString = "Server=LAPTOP-TTJ08ARE\\SQLEXPRESS;Database=AcademiesDB_ZR;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM Students WHERE Id={id}", connection);

                int check = command.ExecuteNonQuery();

                if (check > 0)
                {
                    Console.WriteLine("Deleted");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }

        }
        //***********Update*****************************************************************************************************************************************
        public static void Update(int id)
        {
            string connectionString = "Server=LAPTOP-TTJ08ARE\\SQLEXPRESS;Database=AcademiesDB_ZR;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Students SET Name='Alqasim' WHERE id={id}", connection);

                int check = command.ExecuteNonQuery();

                if (check > 0)
                {
                    Console.WriteLine("Updated");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}