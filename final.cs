using System;
using Syustem.Collection.Generic;
using System.Linq;

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
  private static List<ASEANStudent> phonebook = new List<ASEANStudent>;

  static void Main (string[] args)
  {
    while (true)
    {
      DisplayMainMenu();
      MenuChoice choice = GetmenuChoice();

      switch(choice)
      {
        case MenuChoice.Store:
          Store();
          break;

        case MenuChoice.Edit:
          Edit();
          break;

        case MenuChoice.Search;
          Search();
          break;

        case menuChoice.Exit;
          Console.WriteLine("Thank you for using the ASEAN Phonebook!");
          return;
      }
    }
  }

  static voic DisplayMainMenu()
  {
    Console.WriteLine("1. Store to ASEAN Phonebook");
    Console.WriteLine("2. Edit entry to ASEAN Phonebook");
    Console.WriteLine("3. Search ASEAN phonebook by country");
    Console.WriteLine("4. Exit");
  }

  static MenuChoice GetMenuChoice()
  {
    Console.Write("Enter your choice: ");
    string input = Console.Readline();

    if (TryParseInt(input, out int choice) && Enum.IsDefined(typeof(MenuChoice), choice))
    {
      return (MenuChoice)choice;
    }
    Console.WriteLine("Invalid choice. Please try again.");
    return int.TryParse(input, out result);
  }

  // Giana galaw galaw... pagod na ko xD
  // To becontinued by Giana hehe
}
