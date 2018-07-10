using FluentValidation.Results;
using System;

namespace FluentValidationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets create & validate a store");

            StoreValidator validator = new StoreValidator();

            Store store = createStore();
            Console.WriteLine("\nValidating....");

            ValidationResult result = validator.Validate(store);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.PropertyName + " is invalid. Error: " + failure.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Validation successful");
                PrintStore(store);
            }


            Console.ReadLine();
        }

        public static Store createStore()
        {

            Store store = new Store();
            Console.WriteLine("\nEnter details for a store.");

            Console.WriteLine("\nStore name.  Max 10 characters");
            store.StoreName = Console.ReadLine();

            Console.WriteLine("\nStore number. From 0-9999");
            store.StoreNumber = RequestNumber();

            Console.WriteLine("\nStore type. From 0-4");
            store.StoreType = RequestNumber();


            return store;
        }

        public static void PrintStore(Store s)
        {
            Console.WriteLine("{0} | {1} | {2} | {3}", s.StoreNumber, s.StoreName, s.StoreType, s.IsOpen);
        }

        public static int RequestNumber()
        {
            while (true) { 

            try
            {
                return int.Parse(Console.ReadLine());

            } 
            catch (Exception e)
            { Console.WriteLine("Only numbers are permitted, try again."); }
        }
        }

    }
}
