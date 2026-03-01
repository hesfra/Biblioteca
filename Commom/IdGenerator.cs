using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Commons
{
    public class IDCreator
    {
        public static string NewId()
        {
            return Ulid.NewUlid().ToString();
        }   
    }
}