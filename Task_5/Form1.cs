namespace Task_5
{
    public delegate void ExecutionDelegate();

    public partial class Form1 : Form
    {
        private ExecutionDelegate _myDelegate;

        private bool IscheckBox1Active = false;
        private bool IscheckBox2Active = false;
        private bool IscheckBox3Active = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeTransparency();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeBackground();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintHelloWorld();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _myDelegate?.Invoke();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!IscheckBox1Active)
            {
                _myDelegate += ChangeTransparency;
                _myDelegate -= ChangeTransparencyToDefault;

                IscheckBox1Active = true;
            }
            else
            {
                _myDelegate -= ChangeTransparency;
                _myDelegate += ChangeTransparencyToDefault;

                IscheckBox1Active = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!IscheckBox2Active)
            {
                _myDelegate += ChangeBackground;
                _myDelegate -= ChangeBackgroundToDefault;

                IscheckBox2Active = true;
            }
            else
            {
                _myDelegate -= ChangeBackground;
                _myDelegate += ChangeBackgroundToDefault;

                IscheckBox2Active = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!IscheckBox3Active)
            {
                _myDelegate += PrintHelloWorld;
                IscheckBox3Active = true;
            }
            else
            {
                _myDelegate -= PrintHelloWorld;
                IscheckBox3Active = false;
            }
        }

        private void PrintHelloWorld()
        {
            MessageBox.Show("Hello world");
        }

        private void ChangeTransparency()
        {
            Opacity = 0.5;
        }

        private void ChangeTransparencyToDefault()
        {
            Opacity = 1;
        }

        private void ChangeBackground()
        {
            BackColor = Color.Yellow;
        }

        private void ChangeBackgroundToDefault()
        {
            BackColor = Color.White;
        }
    }
}