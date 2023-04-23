using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlClient;

interface IExample
{

}

internal class GenericExample<T, U> where T: class
                                    where U : class, new()
{

    public T? Tclass { get; set; }


    public void GetFirstItem<T>( List<T> items) where T:class
    {

        var a = items.FirstOrDefault();

    }
}
