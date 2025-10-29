namespace Arrays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] nums = new int[30];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i * 3;
            }
            foreach (var item in nums)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
