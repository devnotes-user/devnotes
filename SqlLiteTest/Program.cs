using System;
using System.Data.SQLite;

namespace SqlLiteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = CreateConnection();
            CreateTable(conn);
            InsertData(conn);
            PrintTable(conn);
            RemoveRow(conn);
            PrintTable(conn);
            conn.Close();
            Console.Read();
        }

        static SQLiteConnection CreateConnection()
        {
            const string CONNECTION_ARGUMENTS = "Data Source = database.db;Version=3;New=True;Compress=True";
            var conn = new SQLiteConnection(CONNECTION_ARGUMENTS);
            RemoveDatabase();
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to create database");
            }
            return conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            const string TABLE_ARGUMENTS = "CREATE TABLE Projects" +
                "(ID INT PRIMARY KEY, ProjectName INT)";
            var command = conn.CreateCommand();
            command.CommandText = TABLE_ARGUMENTS;
            command.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection conn)
        {
            const string DATA_ARGUMENTS = "INSERT INTO Projects (ProjectName) VALUES ('Test')";
            var command = conn.CreateCommand();
            command.CommandText = DATA_ARGUMENTS;
            command.ExecuteNonQuery();
        }

        static void RemoveRow(SQLiteConnection conn)
        {
            var command = conn.CreateCommand();
            command.CommandText = "delete from Projects where ProjectName='Test'";
            command.ExecuteNonQuery();
        }

        static void PrintTable(SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Projects";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetString(1)}");
            }
        }

        static void RemoveDatabase()
        {
            const string DB_PATH = "C:\\Users\\absna\\source\\repos\\DevNotes\\SqlLiteTest\\bin\\Debug\\database.db";
            if (System.IO.File.Exists(DB_PATH))
            {
                System.IO.File.Delete(DB_PATH);
            }
        }
    }
}
