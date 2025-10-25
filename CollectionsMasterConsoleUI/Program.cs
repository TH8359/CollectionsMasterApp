using System;
using System.Collections.Generic;
using System.Collections.Immutable; 
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50 [COMPLETE]

            int[] numbers = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50 [COMPLETE]
            
            Populater(numbers);

            //TODO: Print the first number of the array [COMPLETE]
            
            Console.WriteLine(numbers[0]);

            //TODO: Print the last number of the array [COMPLETE]
            
            Console.WriteLine(numbers[numbers.Length - 1]);

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(numbers);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array. [COMPLETE]
            //Do this 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
                Then print BOTH reversed arrays to the console.
            */

            Console.WriteLine("All Numbers Reversed:");

            NumberPrinter(numbers.Reverse());

            Console.WriteLine("---------REVERSE CUSTOM------------");

            ReverseArray(numbers);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers [COMPLETE]
            Console.WriteLine("Multiple of three = 0: ");
            
            ThreeKiller(numbers);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now [COMPLETE]
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            
            Array.Sort(numbers);
            NumberPrinter(numbers);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List [COMPLETE]
            
            List<int> integerList = new List<int>();

            //TODO: Print the capacity of the list to the console [COMPLETE]
            
            Console.WriteLine($"integerList capacity: {integerList.Capacity}");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this [COMPLETE]            
            
            Populater(integerList);
            NumberPrinter(integerList);

            //TODO: Print the new capacity [COMPLETE]
            
            Console.WriteLine($"integerList capacity: {integerList.Capacity}");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list [COMPLETE]
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");

            bool inputCollected = false;
            int selectedNumber = -1;

            while (inputCollected == false)
            {
                Console.WriteLine("Please enter an integer from 0 to 50");
                string userNumber = (Console.ReadLine());
                for (int counter = 0; counter < 51 && inputCollected == false; counter++)
                {
                    if (userNumber == counter.ToString())
                    {
                        inputCollected = true;
                    }
                }

                if (inputCollected == false)
                {
                    Console.WriteLine("That is not valid input. Please try again.");
                }

                if (inputCollected == true)
                {
                    selectedNumber = int.Parse(userNumber);
                }
                
            }
            Console.WriteLine($"You have selected: {selectedNumber}");
            
            NumberChecker(integerList, selectedNumber);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(integerList);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results [COMPLETE]
            Console.WriteLine("Evens Only!!");


            
            OddKiller(integerList);
            
            
            
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results [COMPLETE]
            Console.WriteLine("Sorted Evens!!");
            
            integerList.Sort();
            NumberPrinter(integerList);
            
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable [COMPLETE]

            int[] convertedList = new int[integerList.Count];
            convertedList = integerList.ToArray();
            NumberPrinter(convertedList);


            //TODO: Clear the list [COMPLETE]
            
            Console.WriteLine("ClearedList:");
            integerList.Clear();
            NumberPrinter(integerList);


            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int counter = 0; counter < numbers.Length; counter++)
            {
                if (numbers[counter] % 3 == 0)
                {
                    numbers[counter] = 0;
                }
            }
            NumberPrinter(numbers);
        }

        private static void OddKiller(List<int> numberList)
        {
            bool readyToPrint = false;

            while (readyToPrint == false)
            {
                bool somethingWasRemoved = false;
                for (int counter = 0; counter < numberList.Count && somethingWasRemoved == false; counter++)
                {
                    if (numberList[counter] % 2 != 0)
                    {
                        numberList.RemoveAt(counter);
                        somethingWasRemoved = true;
                    }
                }

                if (somethingWasRemoved == false)
                {
                    readyToPrint = true;
                }
            }
            NumberPrinter(numberList);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            string result = "";
            for (int counter = 0; counter < numberList.Count && result == ""; counter++)
            {
                if (searchNumber == numberList[counter])
                {
                    result = "Your number is on the list!";
                }
            }

            if (result == "")
            {
                result = "Your number is not on the list!";
            }
            
            Console.WriteLine(result);
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();

            for (int counter = 0; counter < 50; counter++)
            {
                numberList.Add(rng.Next(0, 50));
            }

        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();

            for (int counter = 0; counter < numbers.Length; counter++)
            {
                numbers[counter] = rng.Next(0, 50);
            }

        }        

        private static void ReverseArray(int[] array)
        {
            int[] reversedArray = new int[array.Length];
            int reverseCounter = 0;
            for (int counter = array.Length - 1; counter >= 0; counter--)
            {
                reversedArray[reverseCounter] = array[counter];
                reverseCounter++;
            }
            NumberPrinter(reversedArray);
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
