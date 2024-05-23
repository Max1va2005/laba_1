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
            // Зміна прозорості форми
            this.Opacity -= 0.1;
        }

        private void BackgroundColorButton_Click(object sender, EventArgs e)
        {
            // Зміна кольору фону форми
            this.BackColor = Color.FromArgb(
                255, // Альфа-канал (повна непрозорість)
                255, // Компонента червоного кольору
                0,   // Компонента зеленого кольору
                0    // Компонента синього кольору
            );
        }

        private void HelloWorldButton_Click(object sender, EventArgs e)
        {
            // Виведення повідомлення
            MessageBox.Show("Hello World!");
        }

        private void SuperMegaButton_Click(object sender, EventArgs e)
        {
            // Виведення повідомлення
            MessageBox.Show("Я супермегакнопка,\nі цього мене не позбавиш!");

            // Виклик методів зміни прозорості та кольору фону, якщо відповідні галочки встановлені
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