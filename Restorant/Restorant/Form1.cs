using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restorant
{
    public partial class Form1 : Form
    {
        private static string _conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\ТСП-ресторант\Restorant\Restorant\Database1.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            LoadRestorants();
        }

        // ===================== Load Data =====================
        private void LoadRestorants()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Restorant", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // ===================== Insert =====================
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                string sql = "INSERT INTO Restorant (Name, Type, Address, Discount) VALUES (@Name, @Type, @Address, @Discount)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Type", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Discount", numericUpDown1.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadRestorants();
        }

        // ===================== Update =====================

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Избери ред за редакция.");
                    return;
                }

                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    string sql = "UPDATE Restorant SET Name=@Name, Type=@Type, Address=@Address, Discount=@Discount WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 255).Value = textBox1.Text;
                        cmd.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = comboBox1.SelectedItem?.ToString() ?? "";
                        cmd.Parameters.Add("@Address", SqlDbType.VarChar, 255).Value = textBox2.Text;
                        cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = numericUpDown1.Value;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        int affected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{affected} rows updated.");
                        if (affected == 0)
                            MessageBox.Show("Няма ред, който да отговаря на Id (проверете дали Id е правилен).");
                    }
                }
                LoadRestorants();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }
        // ===================== Delete =====================
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Избери ред за изтриване.");
                    return;
                }

                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                var confirm = MessageBox.Show($"Сигурни ли сте че искате да изтриете Id={id}?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm != DialogResult.Yes) return;

                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    string sql = "DELETE FROM Restorant WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        int affected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{affected} rows deleted.");
                        if (affected == 0)
                            MessageBox.Show("Нищо не е изтрито (възможно е ID-то да не съвпада).");
                    }
                }
                LoadRestorants();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message);
            }
        }


        // ===================== Select Row to Edit =====================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells["Type"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
                numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Discount"].Value);
            }
        }

       
    }
}
