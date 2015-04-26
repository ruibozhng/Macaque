using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(15);
            new Alerter(car);
            car.Run(120);
            Console.ReadLine();
        }
    }

    class Car
    {
        public delegate void Notify(int value);
        public event Notify notifier;

        private int petrol = 0;
        public int Petrol
        {
            get { return petrol; }
            set
            {
                petrol = value;
                if (petrol < 10)  //当petrol的值小于10时，出发警报
                {
                    if (notifier != null)
                    {
                        notifier.Invoke(Petrol);
                    }
                }
            }
        }

        public Car(int petrol)
        {
            Petrol = petrol;
        }

        public void Run(int speed)
        {
            int distance = 0;
            while (Petrol > 0)
            {
                Thread.Sleep(500);
                Petrol--;
                distance += speed;
                Console.WriteLine("Car is running... Distance is " + distance.ToString());
            }
        }
    }

    class Alerter
    {
        public Alerter(Car car)
        {
            car.notifier += new Car.Notify(NotEnoughPetrol);
        }

        public void NotEnoughPetrol(int value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You only have " + value.ToString() + " gallon petrol left!");
            Console.ResetColor();
        }
    }
}
