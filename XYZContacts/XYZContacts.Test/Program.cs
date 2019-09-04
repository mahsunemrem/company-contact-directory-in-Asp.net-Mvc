using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZContacts.BusinessLogicLayer;
using XYZContacts.DataAccessLayer.Context;
using XYZContacts.Entities;

namespace XYZContacts.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeBusiness EB = new EmployeeBusiness();

            var list=EB.GetAll();

            Console.WriteLine("successful");

            Console.ReadLine();
        }
    }
}
