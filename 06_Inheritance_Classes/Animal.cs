using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Inheritance_Classes
{
    //Enum
    public enum DietType { Herbivore, Omnivore, Carnivore}
    public abstract class Animal
    {
        //Properties
        public int numberOfLegs { get; set; }

        public bool IsMammel { get; set; }

        public bool HasFur { get; set; }

        public DietType TypeOfDiet { get; set; }

        //Constructors
        public Animal()
        {
            Console.WriteLine("This is the Animal Constructor");
        }

        public virtual void Move()
        {
            //Get Type gets the typr of the current instance
            Console.WriteLine($"This {GetType().Name} moves.");
        }
    }
}
