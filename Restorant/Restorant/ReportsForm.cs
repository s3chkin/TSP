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
    public partial class ReportsForm : Form
    {
        private static string _conn =
         "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\ТСП-ресторант\\Restorant\\Restorant\\Database1.mdf;Integrated Security=True";

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadRestorantList();
        }

        //
        // 1) Зареждане на ресторантите в ComboBox
        //
        private void LoadRestorantList()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                string sql = "SELECT Id, Name FROM Restorant";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(rd);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "Id";
                }
            }
        }

        //
        // 2) Поръчки по период
        //
        private void LoadOrdersByPeriod()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        o.Id,
                        o.Date,
                        r.Name AS Restorant,
                        p.Name AS Product,
                        p.Price,
                        o.Quantity,
                        (p.Price * o.Quantity) AS Total
                    FROM Orders o
                    JOIN Restorant r ON o.RestorantId = r.Id
                    JOIN Products p ON o.ProductId = p.Id
                    WHERE o.Date BETWEEN @Start AND @End
                    ORDER BY o.Date";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Start", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@End", dateTimePicker2.Value);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void btnGeneratePeriod_Click(object sender, EventArgs e)
        {
            LoadOrdersByPeriod();
        }

        //
        // 3) Поръчки по ресторант
        //
        private void LoadOrdersByRestorant()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        o.Id,
                        o.Date,
                        p.Name AS Product,
                        p.Price,
                        o.Quantity,
                        (p.Price * o.Quantity) AS Total
                    FROM Orders o
                    JOIN Products p ON o.ProductId = p.Id
                    WHERE o.RestorantId = @RestId
                    ORDER BY o.Date";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@RestId", comboBox1.SelectedValue);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }
        }

        private void btnGenerateRestorant_Click(object sender, EventArgs e)
        {
            LoadOrdersByRestorant();
        }

        //
        // 4) Най-нисък и най-висок оборот по години
        //
        private void LoadYearTurnover()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();

                string sql = @"
            SELECT 
                YEAR(o.Date) AS Year,
                SUM(p.Price * o.Quantity) AS TotalTurnover
            FROM Orders o
            JOIN Products p ON o.ProductId = p.Id
            GROUP BY YEAR(o.Date)
            ORDER BY Year";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
            }
        }
 

        private void btnGenerateYearTurnover_Click(object sender, EventArgs e)
        {
            LoadYearTurnover();
        }

        //
        // 5) Статистика по заведения
        //
        private void LoadRestorantStats()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();

                string sql = @"
            SELECT 
                r.Name AS Restorant,
                COUNT(DISTINCT o.ClientId) AS UniqueClients,
                SUM(p.Price * o.Quantity) AS TotalSum
            FROM Orders o
            JOIN Restorant r ON o.RestorantId = r.Id
            JOIN Products p ON o.ProductId = p.Id
            GROUP BY r.Name
            ORDER BY r.Name";

                // Създаваме SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView4.DataSource = dt;
                }
            }
        }


        private void btnGenerateStats_Click(object sender, EventArgs e)
        {
            LoadRestorantStats();
        }

        
         //6) Графика: брой клиенти по ресторант



        private void LoadChartClients()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        r.Name,
                        COUNT(DISTINCT o.ClientId) AS Clients
                    FROM Orders o
                    JOIN Restorant r ON o.RestorantId = r.Id
                    GROUP BY r.Name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    chartClients.Series[0].Points.Clear();

                    while (rd.Read())
                    {
                        chartClients.Series[0]
                            .Points.AddXY(rd["Name"], rd["Clients"]);
                    }
                }
            }
        }




        
         //7) Графика: оборот по ресторант


        private void LoadChartTurnover()
        {
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        r.Name,
                        SUM(p.Price * o.Quantity) AS Total
                    FROM Orders o
                    JOIN Restorant r ON o.RestorantId = r.Id
                    JOIN Products p ON o.ProductId = p.Id
                    GROUP BY r.Name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    chartTurnover.Series[0].Points.Clear();

                    while (rd.Read())
                    {
                        chartTurnover.Series[0]
                            .Points.AddXY(rd["Name"], rd["Total"]);
                    }
                }
            }
        }




        private void btnGenerateCharts_Click(object sender, EventArgs e)
        {
            LoadChartClients();
            LoadChartTurnover();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
