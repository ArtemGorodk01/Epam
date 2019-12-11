using System;
using Task2;

namespace Task2.Sample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Timer.Instance.Subscribe(TimerTest1.SayHello);
            Timer.Instance.Subscribe(TimerTest2.SayHello);

            Timer.Instance.Start(5000);
        }
    }
}
