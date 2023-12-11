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
}
