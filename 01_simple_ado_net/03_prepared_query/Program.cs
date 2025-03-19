
using System.Data;
using Microsoft.Data.SqlClient;

string connString = @"Server=.\SQLEXPRESS;Database=p31_practice_db;Trusted_Connection=True;Encrypt=False;";
string connStringWithoutPooling = @"Server=.\SQLEXPRESS;Database=p31_company_db;Trusted_Connection=True;Encrypt=False;Pooling=False";


using SqlConnection conn = new SqlConnection(connString);

//string title = "'P32'";

string title = "'my_title');INSERT INTO groups (title) VALUES ('admin looser :-|'";

//try
//{
//    conn.Open();
//    Console.WriteLine("Connection opened...");

//    string query = $@"INSERT INTO groups (title) VALUES ({title});";

//    SqlCommand cmd = new SqlCommand(query, conn);

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



//try
//{
//    conn.Open();
//    Console.WriteLine("Connection opened...");

//    string query = @"INSERT INTO groups (title) VALUES (@title);";

//    SqlCommand cmd = new SqlCommand(query, conn);

//    SqlParameter prm = new SqlParameter("@title", title)
//    { 
//        SqlDbType = SqlDbType.VarChar,
//        Size = 64,
//    };

//    cmd.Parameters.Add(prm);

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

