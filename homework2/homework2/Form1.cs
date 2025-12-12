namespace homework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, x;
            int filled = 0;

            bool hasA = double.TryParse(textBox1.Text, out a);
            bool hasB = double.TryParse(textBox2.Text, out b);
            bool hasX = double.TryParse(textBox3.Text, out x);

            if (hasA) filled++;
            if (hasB) filled++;
            if (hasX) filled++;

            if (filled != 2)
            {
                label4.Text = "Моля, въведете точно две променливи!";
                return;
            }

            try
            {
                if (hasA && hasB)
                {
                    if (a <= 0 || a == 1 || b <= 0)
                    {
                        label4.Text = "Невалидни стойности за a или b!";
                        return;
                    }
                    x = Math.Log(b) / Math.Log(a);
                    label4.Text = $"X = {x:F4}";
                }
               
                else if (hasA && hasX)
                {
                    if (a <= 0 || a == 1)
                    {
                        label4.Text = "Невалидна стойност за a!";
                        return;
                    }
                    b = Math.Pow(a, x);
                    label4.Text = $"b = {b:F4}";
                }

                else if (hasB && hasX)
                {
                    if (b <= 0)
                    {
                        label4.Text = "Невалидна стойност за b!";
                        return;
                    }
                    if (x == 0)
                    {
                        label4.Text = "X не може да е 0!";
                        return;
                    }
                    a = Math.Pow(b, 1 / x);
                    label4.Text = $"a = {a:F4}";
                }
            }
            catch (Exception ex)
            {
                label4.Text = "Грешка при изчислението: " + ex.Message;
            }
        }
    }
}
