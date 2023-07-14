using System;

namespace Section02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Writing to the console with a line break
            Console.WriteLine("Hello, people");
            Console.WriteLine("Hello, people");

            // Writing to the console without a line break
            Console.Write("First");
            Console.Write("Second");    // Returns: "FirstSecond"

            // Maximum and minumum values of variables
            sbyte mySbyte = 127; 
            sbyte mySecondSbyte = -128;
            byte myByte = 255;
            byte mySecondByte = 0;
            short myShort = -32768;
            ushort myUshort = 65535;
            int myInt = 2147483647;
            int mySecondInt = -2147483648;
            long myLong = -9223372036854775808;

            Console.WriteLine(mySbyte);
            Console.WriteLine(mySecondSbyte);
            Console.WriteLine(myByte);
            Console.WriteLine(mySecondByte);
            Console.WriteLine(myShort);
            Console.WriteLine(myUshort);
            Console.WriteLine(myInt);
            Console.WriteLine(mySecondInt);
            Console.WriteLine(myLong);

            // Floats, Doubles, and Decimals
            float myFloat = 0.751f;                                 // At the end of a float, you have to add an "f"
            float mySecondFloat = 0.75f;

            double myDouble = 0.751;
            double mySecondDouble = 0.75d;                          // At the end of a double, it is optional to add a "d"

            decimal myDecimal = 0.751m;                             // At the end of a decimal, you have to add an "m"
            decimal mySecondDecimal = 0.75m;

            Console.WriteLine("");
            Console.WriteLine(myFloat - mySecondFloat);             // 0.0009999871
            Console.WriteLine(myDouble - mySecondDouble);           // 0.0010000000000000009
            Console.WriteLine(myDecimal - mySecondDecimal);         // 0.001

            // Only the decimal gives the correct answer because the float & double can't hold enough
            // information to discriminate from one thousandth to another 
            // Floats and doubles use less space.  But for this purpose, we always use decimals for
            // accuracy.  

            string myString = "new string";
            Console.WriteLine(myString);

            // Booleans
            bool myBool = true;
            bool mySecondBool = false;
            Console.WriteLine(myBool);
            Console.WriteLine(mySecondBool);

            // Arrays
            string[] myGroceryArray = new string[2];
            myGroceryArray[0] = "Apples";
            myGroceryArray[1] = "Oranges";
            Console.WriteLine(myGroceryArray[0]);
            Console.WriteLine(myGroceryArray[1]);

            string[] mySecondGroceryArray = {"Kiwi", "Bananas"};
            Console.WriteLine(mySecondGroceryArray[0]);
            Console.WriteLine(mySecondGroceryArray[1]);

            // Lists
            List<string> myGroceryList = new List<String>() {"Milk", "Cheese"};
            Console.WriteLine(myGroceryList[0]);
            Console.WriteLine(myGroceryList[1]);
            myGroceryList.Add("Bread");                             // Adding a new element to our dynamic list
            Console.WriteLine(myGroceryList[2]);

            // IEnumerables
            IEnumerable<string> myGroceryIEnumerable = myGroceryList;
            Console.WriteLine(myGroceryIEnumerable.First());        // Returns the 1st element

            // Arrays with Dimensions
            string[,] myTwoDimensionalArray = new string[,] {
                {"Milk", "Cheese"},
                {"Kiwi", "Bananas"}
            };
            Console.WriteLine(myTwoDimensionalArray[0, 0]);         // Returns: "Milk"

            // Dictionaries
            Dictionary<string, string> myGroceryDictionary = new Dictionary<string, string>(){
                {"Cheese", "Dairy"}
            };
            Console.WriteLine(myGroceryDictionary["Cheese"]);       // Returns: "Cheese"

            Dictionary<string, decimal> itemPrices = new Dictionary<string, decimal>(){
                {"cheese", 5.99m},
                {"carrots", 2.99m}
            };

            // Operators and Conditionals
            int myInteger = 5;
            int mySecondInteger = 10;
            myInteger++;                                            // Add 1 to myInteger
            Console.WriteLine(myInteger);                           // Returns: 6
            Console.WriteLine(mySecondInteger);                     // Returns: 10
            myInteger +=7;                                          // Add 7 to myInteger
            Console.WriteLine(myInteger);                           // Returns: 13


            // Multiplication, Division, Addition, & Subtraction
            Console.WriteLine(1 * 2);                               // Returns: 2     
            Console.WriteLine(2 / 2);                               // Returns: 1
            Console.WriteLine(2 + 2);                               // Returns: 4
            Console.WriteLine(2 - 2);                               // Returns: 0

            // Exponentiation & Square Root
            Console.WriteLine(Math.Pow(5, 2));                      // Returns: 25
            Console.WriteLine(Math.Pow(5, 4));                      // Returns: 625
            Console.WriteLine(Math.Sqrt(25));                       // Returns: 5

            // String Concatenation 
            string myString0 = "I love";
            myString0 += " pizza";
            Console.WriteLine(myString0);                           // Returns: "I love pizza"
            string myString1 = "I love";
            myString1 = myString1 + " candy";
            Console.WriteLine(myString1);                           // Returns: "I love candy"
            string myString2 = "I.love.muffins";
            string[] myString2Array = myString2.Split(".");
            Console.WriteLine(myString2Array[0]);                   // Returns: "I"
            Console.WriteLine(myString2Array[1]);                   // Returns: "love"
            Console.WriteLine(myString2Array[2]);                   // Returns: "muffins"

            // Comparisons
            int integer0 = 5;
            int integer1 = 10;
            Console.WriteLine(integer0.Equals(integer1));          // Returns: False
            Console.WriteLine(integer0.Equals(5));                 // Returns: True
            Console.WriteLine(integer0 == 5);                      // Returns: True
            Console.WriteLine(integer0 != 5);                      // Returns: False
            Console.WriteLine(integer0 >= 10);                     // Returns: False  
            Console.WriteLine(integer0 > 10);                      // Returns: False  
            Console.WriteLine(integer0 <= 10);                     // Returns: True
            Console.WriteLine(integer0 < 10);                      // Returns: True  

            // And Comparison
            Console.WriteLine(5 < 10 && 5 > 10);                   // Returns: False because one condition is false

            // Or Comparison
            Console.WriteLine(5 < 10 || 5 > 10);                   // Returns: True because one condition is true
        
            // If Statement
            int integer3 = 5;
            int integer4 = 10;
            if (integer3 < integer4)
            {
                integer3 = 1;
            }
            Console.WriteLine(integer3);                            // Returns: 1

            string cow1 = "cow";
            string cow2 = "Cow";

            if (cow1 == cow2)
            {
                Console.WriteLine("Equal");
            }                                                       // Doesn't return anything

            if (cow1 != cow2)
            {
                Console.WriteLine("Not Equal");
            }                                                       // Returns: Not Equal

            // If Else Statement
            if (cow1 == cow2)
            {
                Console.WriteLine("Equal");
            }                                                       
            else
            {
                Console.WriteLine("Not Equal");
            }                                                       // Returns: Not Equal

            if (cow1 == cow2)
            {
                Console.WriteLine("Equal");
            }                                                       
            else if (cow1 == cow2.ToLower())
            {
                Console.WriteLine("Loosely Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }                                                       // Returns: Loosely Equal

            // Switch Statement
            switch (cow1)
            {
                case "cow":
                    Console.WriteLine("Lowercase");
                    break;
                case "Cow":
                    Console.WriteLine("Uppercase");
                    break;
            }                                                       // Returns: Lowercase

            // For Loop
            int[] intsToCompress = new int[] {10, 15, 20, 25, 30, 12, 34};
            int totalValue = 0;
            for (int i = 0; i < intsToCompress.Length; i++)
            {
                totalValue += intsToCompress[i];
            }
            Console.WriteLine(totalValue);                          // Returns: 146

            // For Each Loop
            totalValue = 0;
            foreach(int intForCompression in intsToCompress)
            {
                totalValue += intForCompression;
            }
            Console.WriteLine(totalValue);                          // Returns: 146

            // While Loop
            int index = 0;
            totalValue = 0;
            while(index < intsToCompress.Length)
            {
                totalValue += intsToCompress[index];
                index ++;
            }
            Console.WriteLine(totalValue);                          // Returns: 146

            // Do While Loop
            index = 0;
            totalValue = 0;
            do
            {
                totalValue += intsToCompress[index];
                index ++;
            } while(index < intsToCompress.Length);
            Console.WriteLine(totalValue);                          // Returns: 146

            // Declaring a Method
            static int GetSum(int[] intsToCompress)
            {
                int totalValue = 0;
                foreach(int intForCompression in intsToCompress)
                {
                    totalValue += intForCompression;
                }
                return totalValue;
            }
            int[] intsToCompress2 = new int[] {1, 2, 3};
            Console.WriteLine(GetSum(intsToCompress2));             // Returns: 6 

            void RunExercise()                                      // void is needed for conditions that don't return a number
            {
                List<int> myNumberList = new List<int>(){
                    2, 3, 5, 6, 7, 9, 10, 123, 324, 54
                };
                
                foreach (int number in myNumberList)
                {
                    PrintIfOdd(number);
                }
            }
            
            
            void PrintIfOdd(int number)                             // void is needed for conditions that don't return a number
            {
                if (number % 2 != 0)
                {
                    Console.WriteLine(number);
                }
            }

            RunExercise();

            // A static class is bassically the same as a non-static class, but there is one difference:
            // A static class cannot be instatiated.  In other words, you can't use the new operator to 
            // create a variable of the class type.  Because there's no instance variable, you access the
            // members of a static class by using the class name itself.  For example, if you have a static
            // class that is named UtilityCLass that has a public static method named MethodA, you call 
            // the method as follows:   UtilityClass.MethodA();  

            // A static method can only call static variables outside of it's scope.  


        }

    }
}





