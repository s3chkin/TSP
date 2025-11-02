namespace Salary
{
    public partial class Form1 : Form
    {
        string filePath = "C:\\Users\\Sechkin\\Documents\\TSP\\Salary\\Salary\\rabotnici.txt";


        public Form1()
        {
            InitializeComponent();
            LoadDataFromFile();
        }

        private void LoadDataFromFile()
        {
            listBox1.Items.Clear();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);
                }
            }
        }

        private void SaveDataToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in listBox1.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataFromFile();
            MessageBox.Show("Данните са заредени успешно!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string salary = textBox2.Text.Trim();
            string month = textBox3.Text.Trim();
            string year = textBox4.Text.Trim();

            if (name == "" || salary == "" || month == "" || year == "")
            {
                MessageBox.Show("Моля, попълнете всички полета!");
                return;
            }

            string record = $"{name}, {salary}, {month}, {year}";
            listBox1.Items.Add(record);

            SaveDataToFile();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                SaveDataToFile();
            }
            else
            {
                MessageBox.Show("Моля, изберете запис за изтриване!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveDataToFile();
            MessageBox.Show("Данните са записани успешно!");

        }
    }
}
