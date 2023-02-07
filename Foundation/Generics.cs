using System;
using System.Collections.Generic;
using System.Text;

namespace Foundation
{
    public class Generics
    {
        public static void Execute()
        {



            int first = 20;
            int second = 50;

            Swap(ref first, ref second);

            //Sometimes we want to do the same code on different data types.
            //This is restricted to ints. Generics help with that.
            //CREATE SWAP<T> method
            //The <int> tells the generic what type of objects its dealing with.
            //Swap<int>(ref first, ref second);

            float hamburger = 4.99f;
            float cheeseburger = 5.99f;

            Swap<float>(ref hamburger, ref cheeseburger);


            //string hello = "Hello";
            //string world = "World";
            //Swap<string>(ref hello, ref world);

            //How can we make GetConsoleInt/Float() from the ConsoleLibrary assignment generic and save code?
            double dblReturn = GetConsoleNumber<double>("Enter number: ", 20, 50);
            ConsoleLibrary.IO.Print(dblReturn.ToString());

            //add where statement to Swap<T> method Swap<T>(ref T first,ref T second) : where T : stuct
            //This restricts it to ref types
            // Could do where T : Animal (and anything that derives from it)


            //ADD CLASS STACK<T>
            //reference type
            Stack<int> stack = new Stack<int>();
            stack.Push(10); // [10]
            stack.Push(20); //  [10, 20]
            Console.WriteLine(stack.Pop()); //  [10]
            Console.WriteLine(stack.Pop()); //  []

            //could change the above to {float, Animal, etc} and retest.

            //ADD INTSTACK class
            //Dont need to specify type
            IntStack intStack = new IntStack();
        }


        //How can we make GetConsoleInt/Float() from the ConsoleLibrary assignment generic and save code?
        //This is not the best use of generics, but it saves code and returns the type you want. 
        public static T GetConsoleNumber<T>(string message, double min, double max)
        {
            bool success = false;
            double dblTypedValue;

            do
            {
                Console.Write(message);
                //Attempt to parse it.
                success = double.TryParse(Console.ReadLine(), out dblTypedValue);

                //if parse was success, validate its in range. If any fail, it will stop evaluating
                success = success && dblTypedValue >= min && dblTypedValue <= max;

                //Check if all was good.
                if (!success)
                {
                    Console.WriteLine("You entered an invalid value. Must be between {0} and {1} and a valid number.", min, max);
                }

            } while (!success);

            return (T)Convert.ChangeType(dblTypedValue, typeof(T));
        }

        static void Swap(int first, int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        //Generic method. Takes in any type. T represents the type
        static void Swap<G>(ref G first, ref G second) where G : struct
        {
            G temp = first;
            first = second;
            second = temp;
        }

        //Data structure where you push and pop things on and off it.
        //First in last out
        //Generic class..allows us to store any type in the array
        class Stack<T>
        {
            int index = 0; //what layer we are on in the stack
            T[] elements = new T[100]; //elements on the stack

            //add data to stack
            public void Push(T element)
            {
                elements[index++] = element;
            }

            //add data to stack
            public T Pop()
            {
                if (index > 0)
                {
                    //decrement index before you pop...since index is set for next new item
                    return elements[--index];
                }
                return default(T);
            }
        }

        //Derived off the base class, but forcing it to int
        class IntStack : Stack<int>
        {

        }
    }
}
