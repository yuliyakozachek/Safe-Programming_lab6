using System;
namespace Yuliya
{
    // визначення iнтерфейсу
    interface IDemo
    {
        void Show(); //оголошення методу
        double Dlina(); //оголошення методу
        int X { get; } //оголошення властивостi, доступного тiльки для читання
        int Y { get; } //оголошення властивостi, доступного тiльки для читання
        int this[int i] { get; set; } //оголошення iндексатора, доступного для
        //читання-запису
    }
    // клас DemoPoint успадковує iнтерфейс IDemo
    class DemoPoint : IDemo
    {
        protected int x;
        protected int y;
        public DemoPoint(int x, int y)
        {
            this.x = x; this.y = y;
        }
        public void Show() //реалiзацiя методу, оголошеного в iнтерфейсi
        {
            Console.WriteLine($"точка на площинi: ({ x}, { y})");
        }
        public double Dlina() //реалiзацiя методу, оголошеного в iнтерфейсi
        {
            return Math.Sqrt(x * x + y * y);
        }
        public int X //реалiзацiя властивостi, оголошеної в iнтерфейсi
        {
            get
            {
                return x;
            }
        }
         public int Y
        {
            get
            {
                return y;
            }
        }
        public int this[int i] //реалiзацiя iндексатора, оголошеного в iнтерфейсi
        {
            get
            {
                if (i == 0) return x;
                else if (i == 1) return y;
                else throw new Exception("Неприпустиме значення iндексу ");
            }
            set
            {
                if (i == 0) x = value;
                else if (i == 1) y = value;
                else throw new Exception("Неприпустиме значення iндексу ");
            }
        }
    }
    // клас DemoShape успадковує клас DemoPoint i iнтерфейс IDemo
    class DemoShape : DemoPoint, IDemo
    {
        protected int z;
        public DemoShape(int x, int y, int z) : base(x, y)
        {
            this.z = z;
        }
        // реалiзацiя методу, оголошеного в iнтерфейсi, з приховуванням
       // однойменного методу з базового класу
    public new void Show()
        {
            Console.WriteLine($"точка у просторi: ({ x}, { y}, { z})");
        }
        // реалiзацiя методу, оголошеного в iнтерфейсi, з приховуванням
        //однойменного методу з базового класу
    public new double Dlina()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        // реалiзацiя iндексатора, оголошеного в iнтерфейсi, з приховуванням
        // однойменного iндексатора з базового класу
        public new int this[int i]
        {
            get
            {
                if (i == 0) return x;
                else if (i == 1) return y;
                else if (i == 2) return z;
                else throw new Exception("Неприпустиме значення iндексу");
            }
            set
            {
                if (i == 0) x = value;
                else if (i == 1) y = value;
                else if (i == 2) z = value;
                else throw new Exception("Неприпустиме значення iндексу ");
            }
        }
    }
 
    
    class Program
    {
        static void Main()
        {
            // створення масиву iнтерфейсних посилань
            IDemo[] a = new IDemo[4];
            // заповнення масиву
            a[0] = new DemoPoint(0, 1);
            a[1] = new DemoPoint(-3, 0);
            a[2] = new DemoShape(3, 4, 0);
            a[3] = new DemoShape(0, 5, 6);
            // перегляд масиву
            foreach (IDemo x in a)
            {
                x.Show();
                Console.WriteLine("Dlina = "+ x.Dlina());
                Console.WriteLine("x = " +x.X);
                Console.WriteLine("y = " +x.Y);
                x[1] += x[0];
                Console.Write("Новi координати - ");
                x.Show();
                Console.WriteLine();
            }
        }
    }
}
