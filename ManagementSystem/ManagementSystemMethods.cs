using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class ManagementSystemMethods
    {
        List<People> person = new List<People>
        {
            new People ("Gio", 22, "Male", "PH", "USC"), // 0 ID = 1
            new People ("Floyd", 21, "Male", "AUS", "USC - Downtown"), // 1 ID = 2
            new People ("Nestor", 19, "Male", "Brazil", "USC - Main") //2 ID = 3
        };
        public void DisplayMenu()
        {
            string? decision;
            do
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("1.Add People\n2.Delete People\n3.Show List of People\n4.Print the List of People\n5.Order List\n6.Show Age In Between\n7.Exit Program\nDecision: ");
                decision = (Console.ReadLine());

                switch (decision)
                {
                    case "1":
                        Console.Clear();
                        AddPeople(person);
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        DeletePeople(person);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        DisplayPerson(person);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        PrintListOfPeople(person);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        person = OrderList(person);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        ShowAgeInBetween(person);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":
                        Console.WriteLine("Thank for using the application!");
                        break;
                    default:
                        Console.WriteLine("Wrong Input!");
                        break;
                }
            } while (decision != "7");
        }

        public void AddPeople(List<People> person)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter name: ");
                    string? name = Console.ReadLine();

                    Console.Write("Enter age: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter gender: ");
                    string? gender = Console.ReadLine();

                    Console.Write("Enter country: ");
                    string? country = Console.ReadLine();

                    Console.Write("Enter school: ");
                    string? school = Console.ReadLine();

                    People people = new People(name!, age!, gender!, country!, school!);
                    person.Add(people);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }  
        }

        public void DeletePeople(List<People> person)
        {
            try
            {
                int idInput;

                Console.Write("Enter Person ID that you want to delete: ");
                idInput = Convert.ToInt32(Console.ReadLine());

                if (idInput > person.Count)
                {
                    throw new Exception($"Person ID: {idInput} does not exist within the list!");
                }
                else
                {
                    Console.WriteLine($"Person ID: {idInput} has been removed from the list.");
                    Console.WriteLine($"Name:\t\t {person[idInput-1].Name}");
                    Console.WriteLine($"Age:\t\t {person[idInput - 1].Age}");
                    Console.WriteLine($"Gender:\t\t {person[idInput - 1].Gender}");
                    Console.WriteLine($"Country:\t {person[idInput - 1].Country}");
                    Console.WriteLine($"School:\t\t {person[idInput - 1].School}");
                    Console.WriteLine();
                    
    

                       person.RemoveAt(idInput - 1); // -1 to access the index
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid Input! {ex}");
            }
        }

        public void DisplayPerson(List<People> person)
        {
            int idNum = 1;
            Console.WriteLine();
            foreach (People persons in person)
            {
                Console.WriteLine($"Person ID:\t {idNum}");
                Console.WriteLine($"Name:\t\t {persons.Name}");
                Console.WriteLine($"Age:\t\t {persons.Age}");
                Console.WriteLine($"Gender:\t\t {persons.Gender}");
                Console.WriteLine($"Country:\t {persons.Country}");
                Console.WriteLine($"School:\t\t {persons.School}");
                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
                idNum++;
            }

            Console.WriteLine("Enter any key to go back to the menu.");
        }

        public void PrintListOfPeople(List<People> person)
        {
            string path = @"C:\Users\Skanlog-test\Desktop\ManagementSystem.txt";
            string complete_string = "";
            StringBuilder sb = new StringBuilder();

            int idNum = 1;

            foreach (People persons in person)
            {
                sb.Append($"Person ID:\t {idNum}\n");
                sb.Append($"Name:\t\t {persons.Name}\n");
                sb.Append($"Age:\t\t {persons.Age}\n");
                sb.Append($"Gender:\t {persons.Gender}\n");
                sb.Append($"Country:\t {persons.Country}\n");
                sb.Append($"School:\t {persons.School}\n");
                sb.AppendLine("");
                sb.Append("--------------------------------\n");
                sb.AppendLine("");
                complete_string = sb.ToString();
                idNum++;
            }

            File.WriteAllText(path, complete_string);
            Console.WriteLine("File created! Enter any key to go back to the main menu.");
        }

        public List<People> OrderList(List<People> person)
        {
            PropertyInfo propertyInfo = null!;
            try
            {
                string? propertyInput;

                while (propertyInfo == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a property that you want to order or sort ('Name', 'Age', 'Gender', 'School', 'Country')");
                    Console.ForegroundColor = ConsoleColor.Green;
                    propertyInput = Console.ReadLine();
                    Console.ResetColor();

                    propertyInfo = typeof(People).GetProperty(propertyInput!)!;
                    if (propertyInfo == null)
                    {
                        Console.WriteLine("Invalid input, please try again!");

                    }
                    else
                    {
                        person = person.OrderBy(p => propertyInfo.GetValue(p, null)).ToList();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"({propertyInput}) property have been sorted! Press any key to continue!");
                    }
                }
                return person;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return person;
            }
        }

        public void ShowAgeInBetween(List <People> person)
        {
            try
            {
                Console.Write("Enter lower limit: ");
                int lowerLimit = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter upper limit: ");
                int upperLimit = Convert.ToInt32(Console.ReadLine());

                if (lowerLimit > upperLimit)
                {
                    throw new Exception("Lower limit must be lesser than the upper limit!");
                }

                var ageRange = person.OrderBy(p => p.Age).Where(p => p.Age >= lowerLimit && p.Age <= upperLimit).ToList();
                DisplayPerson(ageRange);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Invalid Input!");
            }
        }
    }
}
