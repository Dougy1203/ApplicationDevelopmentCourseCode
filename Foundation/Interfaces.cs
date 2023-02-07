using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    class Interfaces
    {
        public static void Execute()
        {
            Animal bird = new Bird();
            //bird.Fly(); /Not working because Fly is not part of Animal

            if(bird is Bird flyingBird)
            {
                flyingBird.Fly(); // a way to call "Fly" when bird is really an Animal type
                //bird.Fly() / still doens't work because flyingBird is the iteration that works.
            }
            ((Bird)bird).Fly(); // casting bird as a Bird works to resolve the issue

            Animal bear = new Bear();
            if (bear is ISleep)
            {
                //bear.Sleep(); /Animal doesn't include ISleep interface
                ((ISleep)bear).Sleep();
            }    
        }

    }

    class Bear : Animal, ISleep
    {
        //when body of interface method is defined it's just inherited as is. 

        public void Sleep()
        {
            Console.WriteLine("Bear zzzzzzzzzzz");
        }
    }

    interface ISleep
    {
        void Sleep()
        {
            Console.WriteLine("Zzzzzzzzzzzz");
        }
    }

    interface IFly
    {
        public void Fly();
        public void Tweet();
    }

    class Bird : Animal, IFly
    {
        public void Fly()
        {
            Console.WriteLine("I'm Flying!");
        }

        public void Tweet()
        {
            Speak();
        }
    }
}
