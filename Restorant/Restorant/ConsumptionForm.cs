using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restorant
{
    public partial class ConsumptionForm : Form
    {
        private static string _conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\ТСП-ресторант\Restorant\Restorant\Database1.mdf;Integrated Security=True";

        public ConsumptionForm()
        {
            InitializeComponent();
            LoadReservations();
            LoadConsumptions();
        }

        private void LoadReservations()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, ClientName FROM Reservation", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "ClientName";
                comboBox1.ValueMember = "Id";
            }
        }

        // ===================== Load Consumptions =====================
        private void LoadConsumptions()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                string sql = @"SELECT c.Id, r.ClientName, c.OrderDate, c.TotalAmount, c.PaymentType, c.ReservationId
                               FROM Consumption c
                               JOIN Reservation r ON c.ReservationId = r.Id";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                string sql = @"INSERT INTO Consumption (OrderDate, TotalAmount, PaymentType, ReservationId)
                               VALUES (@OrderDate, @TotalAmount, @PaymentType, @ReservationId)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderDate", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@TotalAmount", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@PaymentType", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ReservationId", comboBox1.SelectedValue);

                    cmd.ExecuteNonQuery();
                }
            }

            LoadConsumptions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    string sql = @"UPDATE Consumption 
                                   SET OrderDate=@OrderDate, TotalAmount=@TotalAmount, PaymentType=@PaymentType, ReservationId=@ReservationId
                                   WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderDate", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@TotalAmount", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@PaymentType", comboBox2.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ReservationId", comboBox1.SelectedValue);
                        cmd.Parameters.AddWithValue("@Id", id);

                        cmd.ExecuteNonQuery();
                    }
                }

                LoadConsumptions();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    string sql = "DELETE FROM Consumption WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadConsumptions();
            }
        }

        // ===================== Fill form on row click =====================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["OrderDate"].Value);
                numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["TotalAmount"].Value);
                comboBox2.SelectedItem = dataGridView1.CurrentRow.Cells["PaymentType"].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["ReservationId"].Value;
            }
        }


    }
}
