using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class Inheritance
    {
        public static void Execute()
        {
            //Animal animal = new Animal();
            //animal.Name = "Cat";
            //Animal animal = new Animal() { Name = "Cat" };
            Animal animal = new Animal("Cat", 17);
            
            Mammal humanM = new Mammal("Bob", 75, true, true, false);
            humanM.Speak();

            Animal humanA = new Mammal("Bob", 75, true, true, false);
            humanA.Speak();
        }

        class Animal
        {
            private int lifeSpan;

            public string Name { get; set; }

            public bool isNocturnal { get; }

            public Animal() { }

            public Animal(string name, int lifeSpan, bool isNocturnal = false) 
            {
                Name = name;
                this.lifeSpan = lifeSpan;
                this.isNocturnal = isNocturnal;

            }

            public virtual void Speak()
                //public void Speak()
                //Virtual makes the parent/base class overridable 
            {
                Console.WriteLine(Name + " Speaks (Animal class)");
            }

        }

        class Mammal : Animal
        {
            public bool isCarnivore { get; set; }

            public bool LivesOnLand { get; set; }

            public Mammal(string name, int lifeSpan, bool isCarnivore, bool livesOnLand, bool isNocturnal = false)
                : base(name, lifeSpan, isNocturnal)
            {
                this.isCarnivore = isCarnivore;
                this.LivesOnLand = livesOnLand;
            }

            public override void Speak()
                //public void Speak()
                //allows for overriding parent/base class functions/methods
            {
                Console.WriteLine(Name + " Speaks (Mammal Class)");
            }

        }
    }

    class Animal
    {
        private int lifeSpan;

        public string Name { get; set; }

        public bool isNocturnal { get; }

        public Animal() { }

        public Animal(string name, int lifeSpan, bool isNocturnal = false)
        {
            Name = name;
            this.lifeSpan = lifeSpan;
            this.isNocturnal = isNocturnal;

        }

        public virtual void Speak()
        //public void Speak()
        //Virtual makes the parent/base class overridable 
        {
            Console.WriteLine(Name + " Speaks (Animal class)");
        }

    }
}
