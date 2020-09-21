using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Inheritance_Classes
{
    public class Cat : Animal
    {
        public double ClawLength { get; set; }

        public Cat()
        {
            Console.WriteLine("This is the Cat constructor");
            IsMammel = true;
            TypeOfDiet = DietType.Carnivore;
        }

        public override void Move()
        {
            Console.WriteLine($"The {GetType().Name} move quickly.");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Meow.");
        }
    }

    //Liger inherits from Cat which inherits from animal class 
    public class Liger : Cat
    {
        public Liger()
        {
            Console.WriteLine("This is the Liger Constructor");
        }

        public override void Move()
        {
            Console.WriteLine($"The {GetType().Name} stalks its prey");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Roar.");
        }
    }
}
