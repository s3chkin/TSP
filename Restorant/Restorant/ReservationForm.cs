using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restorant
{
    public partial class ReservationForm : Form
    {
        private static string _conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\ТСП-ресторант\Restorant\Restorant\Database1.mdf;Integrated Security=True";

        public ReservationForm()
        {
            InitializeComponent();
            LoadRestorants();
            LoadReservations();
        }

        // ===================== Load Restaurants for ComboBox =====================
        private void LoadRestorants()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Name FROM Restorant", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
        }

        // ===================== Load Reservations =====================
        private void LoadReservations()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                string sql = @"SELECT r.Id, rs.Name AS RestorantName, r.ClientName, r.NumberOfGuests, r.Date, r.Time 
                               FROM Reservation r
                               JOIN Restorant rs ON r.RestorantId = rs.Id";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // ===================== Add =====================
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                string sql = @"INSERT INTO Reservation (RestorantId, ClientName, NumberOfGuests, Date, Time)
                               VALUES (@RestorantId, @ClientName, @NumberOfGuests, @Date, @Time)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@RestorantId", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@ClientName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@NumberOfGuests", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Time", dateTimePicker2.Value.TimeOfDay);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadReservations();
        }

        // ===================== Update =====================
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    string sql = @"UPDATE Reservation 
                                   SET RestorantId=@RestorantId, ClientName=@ClientName, NumberOfGuests=@NumberOfGuests, Date=@Date, Time=@Time
                                   WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RestorantId", comboBox1.SelectedValue);
                        cmd.Parameters.AddWithValue("@ClientName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@NumberOfGuests", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@Time", dateTimePicker2.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadReservations();
            }
        }


        // ===================== Delete =====================
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    string sql = "DELETE FROM Reservation WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadReservations();
            }
        }

        // ===================== Fill Form on Row Click =====================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["RestorantId"].Value;
                textBox1.Text = dataGridView1.CurrentRow.Cells["ClientName"].Value.ToString();
                numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["NumberOfGuests"].Value);
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Date"].Value);
                dateTimePicker2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells["Time"].Value.ToString());
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

       

       

        
    }
}
