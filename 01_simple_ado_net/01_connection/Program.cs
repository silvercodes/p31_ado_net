
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

string connString = @"Server=.\SQLEXPRESS;Database=p31_company_db;Trusted_Connection=True;Encrypt=False;";
string connStringWithoutPooling = @"Server=.\SQLEXPRESS;Database=p31_company_db;Trusted_Connection=True;Encrypt=False;Pooling=False";

#region Connection
//using DbConnection conn = new SqlConnection(connString);

//try
//{
//    conn.Open();
//    Console.WriteLine("Connection OK");
//    Console.WriteLine(conn.ConnectionString);
//    Console.WriteLine(conn.State);
//    Console.WriteLine(conn.ServerVersion);

//    string query = @"CREATE TABLE pictures (
//                    id int NOT NULL PRIMARY KEY IDENTITY(1,1),
//                    title varchar(64) NOT NULL
//                );";

//    DbCommand cmd = new SqlCommand(query, conn as SqlConnection);
//    cmd.ExecuteNonQuery();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}
//finally
//{
//    if (conn.State == ConnectionState.Open)
//    {
//        conn.Close();
//        Console.WriteLine("Connection closed");
//    }
//}




//using (SqlConnection conn = new SqlConnection(connString))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//    conn.Close();
//}

//using (SqlConnection conn = new SqlConnection(connString))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//    conn.Close();
//}



//using (SqlConnection conn = new SqlConnection(connStringWithoutPooling))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//    conn.Close();
//}

//using (SqlConnection conn = new SqlConnection(connStringWithoutPooling))
//{
//    conn.Open();
//    Console.WriteLine(conn.ClientConnectionId);
//    conn.Close();
//}
#endregion

#region Command

// ==== ExecuteNonQuery()

//using (SqlConnection conn = new SqlConnection(connString))
//{
//    try
//    {
//        conn.Open();
//        Console.WriteLine("Connection opened...");

//        string query = @"INSERT INTO pictures(title) VALUES('ADO.NET')";

//        SqlCommand cmd = new SqlCommand()
//        {
//            Connection = conn,
//            CommandType = CommandType.Text,
//            CommandText = query,
//        };

//        cmd.ExecuteNonQuery();

//        conn.ChangeDatabase("p31_constraints_db");

//        cmd.CommandText = @"
//            CREATE TABLE logs (
//                id int NOT NULL PRIMARY KEY IDENTITY(1,1),
//                l_date datetime NOT NULL,
//                mesage varchar(1024) NOT NULL
//            );
//        ";

//        cmd.ExecuteNonQuery();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//    finally
//    {
//        if (conn.State == ConnectionState.Open)
//        {
//            conn.Close();
//            Console.WriteLine("Connection closed");
//        }
//    }
//}



// ==== ExecuteReader


//using (SqlConnection conn = new SqlConnection(connString))
//{
//    try
//    {
//        conn.Open();
//        Console.WriteLine("Connection opened...");

//        string query = @"SELECT * FROM employees;";

//        SqlCommand cmd = new SqlCommand(query, conn);

//        using (SqlDataReader reader = cmd.ExecuteReader())
//        {
//            Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}");

//            //while(reader.Read())
//            //{
//            //    //int id = (int)reader[0];
//            //    //int id = (int)reader["id"];
//            //    //int id = reader.GetInt32("id");
//            //    //int id = (int)reader.GetValue(0);
//            //    int id = (int)reader.GetFieldValue<int>("id");

//            //    string name = reader.GetFieldValue<string>("name");

//            //    DateTime birthday = reader.GetFieldValue<DateTime>("birthday");

//            //    Console.WriteLine($"{id}\t{name}\t{birthday}");
//            //}


//            DataTable dt = new DataTable();
//            dt.Load(reader);

//            foreach(DataRow row in dt.Rows)
//                Console.WriteLine($"{row["id"]}\t{row["name"]}\t{row["birthday"]}");

//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//    finally
//    {
//        if (conn.State == ConnectionState.Open)
//        {
//            conn.Close();
//            Console.WriteLine("Connection closed");
//        }
//    }
//}




// ==== ExecuteScalar
using (SqlConnection conn = new SqlConnection(connString))
{
    try
    {
        conn.Open();
        Console.WriteLine("Connection opened...");

        string query = @"SELECT MAX(id) FROM employees;";

        SqlCommand cmd = new SqlCommand(query, conn);

        int maxId = (int)cmd.ExecuteScalar();

        Console.WriteLine($"Max id = {maxId}");

    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR: {ex.Message}");
    }
    finally
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
            Console.WriteLine("Connection closed");
        }
    }
}





#endregion


