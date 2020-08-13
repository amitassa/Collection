using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string>() { "mamas", "aram", "sigit"};
            ListOperations(ref myList);
        }

        public static void ListOperations (ref List<string> stringsList)
        {
            if (stringsList.Count == 0)
            {
                Console.WriteLine("List is null. Please try again.");
                return;
            }

            // Avoiding false regections caused by case sensitive strings:
            stringsList = stringsList.Select(str => str.ToLower()).ToList();

            // Remove the middle placed item:
            if (stringsList.Count % 2 == 0)
                Console.WriteLine("Cannot remove the middle placed item at the list because the list contains even number of items.");
            else
            {
                stringsList.RemoveAt(stringsList.Count / 2);
                Console.WriteLine(string.Format("Middle placed item at the list has been removed. Here's the list: ({0}).", string.Join(", ", stringsList)));
            }

            // If the list contains "mamas", adds to list the item "6"

            if (stringsList.Contains("mamas"))
            {
                stringsList.Add("6");
                Console.WriteLine(string.Format("The list contains 'mamas' string => '6' added to the list. Here's the list: ({0}).", string.Join(", ", stringsList)));
            }

            // If the index of 'aram' is odd, reverse the list
            if (stringsList.Contains("aram") && stringsList.IndexOf("aram") % 2 == 1)
            {
                Console.WriteLine(string.Format("The list contains 'aram' string => list is now at reversed order. Here's the list: ({0}).", string.Join(", ", stringsList)));
                stringsList.Reverse();
            }

            // Unique values:
            IEnumerable<string> uniqueStrings = stringsList.Distinct();
            try
            {
                if (uniqueStrings.Count() == 3)
                {
                    stringsList.Insert(2, "4");
                    stringsList.Insert(2, "3");
                    stringsList.Insert(2, "2");
                    
                    Console.WriteLine(string.Format("2,3,4 added to the list, starting from index 2. Here's the list: ({0}).", string.Join(", ", stringsList)));
                }
                else
                {
                    Console.WriteLine("Unique strings count is gt / lt 3.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("list is null, no unique values");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                stringsList.Add("2");
                stringsList.Add("3");
                stringsList.Add("4");
            }

        }
    }
}
