using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace _02_single_adapter
{
    public partial class Form1 : Form
    {
        private string connString = string.Empty;
        private SqlConnection conn;
        private DataSet ds;
        private SqlDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();

            connString = ConfigurationManager
                .ConnectionStrings["sqlserver"]
                .ConnectionString;

            conn = new SqlConnection(connString);

            ds = new DataSet();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                dgwMain.DataSource = null;
                Update();

                adapter = new SqlDataAdapter(txtQuery.Text, conn);

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                Debug.WriteLine(builder.GetInsertCommand().CommandText);
                // INSERT INTO [users] ([email], [nickname], [password], [birthday], [deleted_at]) VALUES (@p1, @p2, @p3, @p4, @p5)
                Debug.WriteLine(builder.GetUpdateCommand().CommandText);
                // UPDATE [users] SET [email] = @p1, [nickname] = @p2, [password] = @p3, [birthday] = @p4, [deleted_at] = @p5 WHERE (([id] = @p6) AND ([email] = @p7) AND ([nickname] = @p8) AND ([password] = @p9) AND ([birthday] = @p10) AND ((@p11 = 1 AND [deleted_at] IS NULL) OR ([deleted_at] = @p12)))
                Debug.WriteLine(builder.GetDeleteCommand().CommandText);
                // DELETE FROM [users] WHERE (([id] = @p1) AND ([email] = @p2) AND ([nickname] = @p3) AND ([password] = @p4) AND ([birthday] = @p5) AND ((@p6 = 1 AND [deleted_at] IS NULL) OR ([deleted_at] = @p7)))



                ModifyUpdateCommand();
                ModifyDeleteCommand();
                //ModifyInsertCommand();


                adapter.Fill(ds);
                dgwMain.DataSource = ds.Tables[0];
   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            adapter.Update(ds.Tables[0]);


            //DataTable t = ds.Tables[0];
            //DataRow[] rows = t.Select(null, null, DataViewRowState.ModifiedCurrent | DataViewRowState.Added);
            //adapter.Update(rows);
        }

        private void ModifyUpdateCommand()
        {
            string query = @"
                UPDATE users
                SET nickname = @p_nickname, birthday = @p_birthday
                WHERE id = @p_id;
            ";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add(new SqlParameter("@p_nickname", SqlDbType.NVarChar, 50) 
            { 
                SourceColumn = "nickname",
                SourceVersion = DataRowVersion.Current
            });

            cmd.Parameters.Add(new SqlParameter("@p_birthday", SqlDbType.Date)
            {
                SourceColumn = "birthday",
                SourceVersion = DataRowVersion.Current
            });

            cmd.Parameters.Add(new SqlParameter("@p_id", SqlDbType.Int)
            {
                SourceColumn = "id",
                SourceVersion = DataRowVersion.Original
            });

            adapter.UpdateCommand = cmd;
        }

        private void ModifyDeleteCommand()
        {
            // string query = @"delete from users where id = @p_id;";

            string query = @"UPDATE users SET deleted_at = GETDATE() WHERE id = @p_id;";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add(new SqlParameter("@p_id", SqlDbType.Int)
            {
                SourceColumn = "id",
                SourceVersion = DataRowVersion.Original
            });

            adapter.DeleteCommand = cmd;
        }

        private void ModifyInsertCommand()
        {
            SqlCommand cmd = new SqlCommand("uspInsertUser", conn)
            {
                CommandType = CommandType.StoredProcedure,
            };

            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50)
            {
                SourceColumn = "email",
                SourceVersion = DataRowVersion.Current
            });

            cmd.Parameters.Add(new SqlParameter("@nickname", SqlDbType.NVarChar, 50)
            {
                SourceColumn = "nickname",
                SourceVersion = DataRowVersion.Current
            });

            cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)
            {
                SourceColumn = "password",
                SourceVersion = DataRowVersion.Current
            });

            cmd.Parameters.Add(new SqlParameter("@birthday", SqlDbType.Date)
            {
                SourceColumn = "birthday",
                SourceVersion = DataRowVersion.Current
            });

            adapter.InsertCommand = cmd;
        }
    }
}