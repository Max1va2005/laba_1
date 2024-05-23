class Program
{
    class Timer
    {
        private Action methodToExecute;
        private int intervalInSeconds;

        public Timer(Action method, int interval)
        {
            methodToExecute = method;
            intervalInSeconds = interval;
        }

        public void Start()
        {
            while (true)
            {
                methodToExecute();
                Thread.Sleep(intervalInSeconds * 1000);
            }
        }
    }
    static void Main()
    {
        Timer timer = new Timer(PrintHello, 3);
        timer.Start();

        Thread.Sleep(10000);
    }

    static void PrintHello()
    {
        Console.WriteLine("Hello!");
    }
}


