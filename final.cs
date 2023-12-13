using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum MenuChoice
{
    Store = 1,
    Edit,
    Search,
    Exit
}

class ASEANStudent
{
    public int StudentNumber
    {
        get;
        set;
    }

    public string Surname
    {
        get;
        set;
    }

    public string FirstName
    {
        get;
        set;
    }

    public string Occupation
    {
        get;
        set;
    }

    public string Gender
    {
        get;
        set;
    }

    public int CountryCode
    {
        get;
        set;
    }

    public int AreaCode
    {
        get;
        set;
    }

    public int PhoneNumber
    {
        get;
        set;
    }
}

class ASEANPhonebook
{
    private static List<ASEANStudent> phonebook = new List<ASEANStudent>();

    static void Main(string[] args)
    {
        while (true)
        {
            DisplayMainMenu();
            MenuChoice choice = GetMenuChoice();

            switch (choice)
            {
                case MenuChoice.Store:
                    Store();
                    break;

                case MenuChoice.Edit:
                    Edit();
                    break;

                case MenuChoice.Search:
                    Search();
                    break;

                case MenuChoice.Exit:
                    Console.WriteLine("Thank you for using the ASEAN Phonebook!");
                    return;
            }
        }
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine("1. Store to ASEAN Phonebook");
        Console.WriteLine("2. Edit entry to ASEAN Phonebook");
        Console.WriteLine("3. Search ASEAN phonebook by country");
        Console.WriteLine("4. Exit");
    }

    static MenuChoice GetMenuChoice()
    {
        Console.Write("Enter your choice: ");
        string input = Console.ReadLine();

        if (TryParseInt(input, out int choice) && Enum.IsDefined(typeof(MenuChoice), choice))
        {
            return (MenuChoice)choice;
        }
        Console.WriteLine("Invalid choice. Please try again.");
        return GetMenuChoice();
    }
    static bool TryParseInt(string input, out int result)
    {
        return int.TryParse(input, out result);
    }

    static void Store()
    {    //get
        Console.Write("Enter student number: ");
        int studentNumber;
        while (!int.TryParse(Console.ReadLine(), out studentNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for student number.");
            Console.Write("Enter student number: ");
        }

        Console.Write("Enter surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter occupation: ");
        string occupation = Console.ReadLine();
        Console.Write("Enter gender: ");
        string gender = Console.ReadLine();
        Console.Write("Enter country code: ");
        int countryCode = int.Parse(Console.ReadLine());
        Console.Write("Enter area code: ");
        int areaCode = int.Parse(Console.ReadLine());
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        phonebook.Add(new ASEANStudent //set
        {
            StudentNumber = studentNumber,
            Surname = surname,
            FirstName = firstName,
            Occupation = occupation,
            Gender = gender,
            CountryCode = countryCode,
            AreaCode = areaCode,
            PhoneNumber = number,
        });

        Console.WriteLine("Entry stored successfully.");
        Console.Write("Do you want to enter another entry (Y/N): ");
        if (Console.ReadLine().ToUpper() == "Y")
        {
            Store();
        }
    }

    static void Edit()
    {
        Console.Write("Enter student number: ");
        int studentNumber = int.Parse(Console.ReadLine());
        ASEANStudent student = phonebook.FirstOrDefault(s => s.StudentNumber == studentNumber);

        if (student == null)
        {
            Console.WriteLine("There is no student found with that student number.");
            return;
        }

        while (true)
        {
            Console.WriteLine($"Here is the existing information about {student.FirstName} {student.Surname}:");
            Console.WriteLine($"Student number: {student.StudentNumber}");
            Console.WriteLine($"Surname: {student.Surname}");
            Console.WriteLine($"Gender: {student.Gender}");
            Console.WriteLine($"Occupation: {student.Occupation}");
            Console.WriteLine($"Country code: {student.CountryCode}");
            Console.WriteLine($"Area code: {student.AreaCode}");
            Console.WriteLine($"Phone number: {student.PhoneNumber}");

            Console.WriteLine("Which of the following information do you wish to change?");
            Console.WriteLine("1. Student number");
            Console.WriteLine("2. Surname");
            Console.WriteLine("3. Gender");
            Console.WriteLine("4. Occupation");
            Console.WriteLine("5. Country code");
            Console.WriteLine("6. Area code");
            Console.WriteLine("7. Phone number");
            Console.WriteLine("8. None – Go back to main menu");
            Console.Write("Enter choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter new student number: ");
                        student.StudentNumber = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Enter new surname: ");
                        student.Surname = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter new gender: ");
                        student.Gender = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter new occupation: ");
                        student.Occupation = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Enter new country code: ");
                        student.CountryCode = int.Parse(Console.ReadLine());
                        break;
                    case 6:
                        Console.Write("Enter new area code: ");
                        student.AreaCode = int.Parse(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Enter new phone number: ");
                        student.PhoneNumber = int.Parse(Console.ReadLine());
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice, PLease try again.");
                break;
            }
        }
    }

    static void Search()
    {
        List<ASEANStudent> SearchCountry = new List<ASEANStudent>();

        do
        {
            Console.WriteLine("\nSelect a Country: ");
            Console.WriteLine("[1] Philippines \n[2] Thailand \n[3] Singapore \n[4] Indonesia \n[5] Malaysia \n[6] All \n[0] No More");

            Console.Write("Enter the Country(Number): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
                break;

            int countryCode = GetCountryCode(choice);
            SearchCountry.AddRange(phonebook.Where(c => c.CountryCode == countryCode));

        } while (true);

        if (SearchCountry.Count == 0)
        {
            Console.WriteLine("There is no Students found for the selected countries.");
            return;
        }

        SearchCountry = SearchCountry.OrderBy(s => s.Surname).ToList();

        Console.WriteLine("\nHere are the Students: ");

        foreach (var student in SearchCountry)
        {
            Console.WriteLine($"{student.Surname}, {student.FirstName}, with student number {student.StudentNumber}, is a {student.Occupation}. His/Her phone number is {student.CountryCode}-{student.AreaCode}-{student.PhoneNumber}\n");
        }
    }

    static int GetCountryCode(int choice)
    {
        switch (choice)
        {
            case 1: return 63; // Philippines
            case 2: return 66; // Thailand
            case 3: return 65; // Singapore
            case 4: return 62; // Indonesia
            case 5: return 60; // Malaysia
            case 6: return 0;  // All
            default: return 0;
        }
    }
}
