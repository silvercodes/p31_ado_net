
using System.Data;
using Microsoft.Data.SqlClient;

string connString = @"Server=.\SQLEXPRESS;Database=p31_company_db;Trusted_Connection=True;Encrypt=False;";
string connStringWithoutPooling = @"Server=.\SQLEXPRESS;Database=p31_company_db;Trusted_Connection=True;Encrypt=False;Pooling=False";

//string procQuery = @"
//    CREATE PROCEDURE uspGetEmployeesOf1982
//	AS
//	BEGIN
//		SELECT
//			id, email
//		FROM employees
//		WHERE YEAR(birthday) = 1982;
//	END
//";

//using (SqlConnection conn = new SqlConnection(connString))
//{
//    try
//    {
//        conn.Open();
//        Console.WriteLine("Connection opened...");

//        // SqlCommand cmd = new SqlCommand(procQuery, conn);
//        // cmd.ExecuteNonQuery();

//        SqlDataReader reader = ExecuteProcedure(conn, "uspGetEmployeesOf1982");
//        Render(reader);
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






string procQuery = @"
    CREATE PROCEDURE uspCountUsersByEmail
        @pattern nvarchar(30),
        @count int OUT
    AS
    BEGIN
        SET @count = (
            SELECT COUNT(email)
            FROM employees
            WHERE email LIKE @pattern
        );
    END
";

using (SqlConnection conn = new SqlConnection(connString))
{
    try
    {
        conn.Open();
        Console.WriteLine("Connection opened...");

        // SqlCommand cmd = new SqlCommand(procQuery, conn);
        // cmd.ExecuteNonQuery();

        int result = CountByEmail(conn, "[abs]%");
        Console.WriteLine($"Result = {result}");
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


int CountByEmail(SqlConnection conn, string pattern)
{
    string procName = "uspCountUsersByEmail";

    SqlCommand cmd = new SqlCommand(procName, conn)
    {
        CommandType = CommandType.StoredProcedure,
    };

    cmd.Parameters.Add(new SqlParameter()
    {
        ParameterName = "@pattern",
        SqlDbType = SqlDbType.NVarChar,
        Size = 30,
        Value = pattern
    });

    SqlParameter countPrm = new SqlParameter()
    {
        ParameterName = "@count",
        SqlDbType = SqlDbType.Int,
        Direction = ParameterDirection.Output,
    };
    cmd.Parameters.Add(countPrm);

    cmd.ExecuteNonQuery();

    return (int)countPrm.Value;
}

SqlDataReader ExecuteProcedure(SqlConnection conn, string procName)
{
    SqlCommand cmd = new SqlCommand()
    {
        Connection = conn,
        CommandType = CommandType.StoredProcedure,
        CommandText = procName
    };

    return cmd.ExecuteReader();
}
void Render(SqlDataReader reader)
{
    int columnCount = reader.FieldCount;

    DataTable dt = new DataTable();
    dt.Load(reader);

    foreach(DataColumn col in dt.Columns)
        Console.Write($"{col.ColumnName}\t");
    Console.WriteLine();

    foreach(DataRow row in dt.Rows)
    {
        for(int i = 0; i < columnCount; i++)
            Console.Write($"{row[i]}\t");
        Console.WriteLine();
    }
}
