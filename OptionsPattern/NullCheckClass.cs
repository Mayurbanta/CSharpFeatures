using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPattern;
internal class NullCheckClass
{

    public void DoSomething()
    {
        //    Person person = null;

        //    person.Name = "Test";

        //var ppl = GetPeople();
        //var count = ppl.Count();
    }


    public IList<Person>? GetPeople()
    {
        return null;
    }
}

class Person
{
    public int PersonId { get; set; }

    public string? Name { get; init; }

    public Address? Address { get; set; }
}

class Address
{
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
}