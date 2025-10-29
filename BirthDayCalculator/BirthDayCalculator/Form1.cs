namespace BirthDayCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age = DateTime.Now.Year - dateTimePicker1.Value.Year;
            if (DateTime.Now.Month < dateTimePicker1.Value.Month ||
             (DateTime.Now.Month == dateTimePicker1.Value.Month && DateTime.Now.Day < dateTimePicker1.Value.Day))
            {
                age--;
            }

            textBox1.Text = age.ToString();
        }
    }
}
