namespace Task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void TransparencyButton_Click(object sender, EventArgs e)
        {
            // ���� ��������� �����
            this.Opacity -= 0.1;
        }

        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            // ���� ������� ���� �����
            this.BackColor = Color.FromArgb(
                255, // �����-����� (����� �����������)
                255, // ���������� ��������� �������
                0,   // ���������� �������� �������
                0    // ���������� ������� �������
            );
        }

        private void HelloWorldButton_Click(object sender, EventArgs e)
        {
            // ��������� �����������
            MessageBox.Show("Hello World!");
        }

        private void SuperMegaButton_Click(object sender, EventArgs e)
        {
            // ��������� �����������
            MessageBox.Show("� ���������������,\n� ����� ���� �� ��������!");

            // ������ ������ ���� ��������� �� ������� ����, ���� ������� ������� ����������
            if (changeTransparencyCheckBox.Checked)
            {
                TransparencyButton_Click(sender, e);
            }
            if (changeBackgroundColorCheckBox.Checked)
            {
                BackgroundColorButton_Click(sender, e);
            }
        }
    } 
}