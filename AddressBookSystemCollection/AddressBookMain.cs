using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemCollection
{
    public class AddressBookMain
    {
        public static List<Person> ContactList = new List<Person>();

        public static void AddPersonInfo()
        {
            Person persn = new Person();

            Console.Write(" Enter First Name : ");
            persn.FirstName = Console.ReadLine();

            Console.Write(" Enter Last Name : ");
            persn.LastName = Console.ReadLine();

            Console.Write(" Enter Address/landmark : ");
            persn.Address = Console.ReadLine();

            Console.Write(" Enter City : ");
            persn.City = Console.ReadLine();

            Console.Write(" Enter State : ");
            persn.State = Console.ReadLine();

            Console.Write(" Enter PinCode : ");
            persn.ZipCode = Convert.ToInt32(Console.ReadLine());

            Console.Write(" Enter Phone Number (+91) : ");
            persn.PhoneNumber = Console.ReadLine();

            Console.Write(" Enter EmailId : ");
            persn.EmailId = Console.ReadLine();

            ContactList.Add(persn);
        }

        public static void DisplayData(Person persn)
        {
            Console.WriteLine(" First Name \t: {0} \n Last Name \t: {1} ", persn.FirstName, persn.LastName);
            Console.WriteLine(" Address \t: {0} \n City \t\t: {1} ", persn.Address, persn.City);
            Console.WriteLine(" State \t\t: {0} \n ZipCode \t: {1} ", persn.State, persn.ZipCode);
            Console.WriteLine(" Phone Number \t: {0} \n EmailId \t: {1} \n", persn.PhoneNumber, persn.EmailId);
        }

        public void Book()
        {
            Console.WriteLine(" Welcome to Address Book Program \n");

            Console.WriteLine(" [ ADDING CONTACT ] Please provide following details : \n");
            AddPersonInfo();

            Console.WriteLine("\n Displying saved contact details : \n");
            foreach (var persn in ContactList)
            {
                DisplayData(persn);
            }
        }
    }
}
