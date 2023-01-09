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

        //starting application
        public void Book()
        {
            Console.WriteLine(" Welcome to Address Book Program \n");
            Console.WriteLine(" No contacts in address book... \n [ ADD CONTACT ] Please provide following details : \n");
            AddPersonInfo();
        }

        //options to select operation
        public static void Operations()
        {
            Console.WriteLine(" Available options : \t 1.Edit_contact\t\t 0.Exit ");
            Console.Write(" Provide option :  ");
            int check = int.Parse(Console.ReadLine());
            switch (check)
            {
                case 1:
                    Console.Write(" Enter Firstname to find and edit info : ");
                    string findName = Console.ReadLine();
                    foreach (var entry in ContactList)
                    {
                        if (entry.FirstName.ToLower() == findName.ToLower())
                        {
                            ModifyPersonInfo();
                            DisplayContacts();
                        }
                        else
                        {
                            Console.WriteLine(" Firstname does not match. Please retry. \n");
                            Operations();
                        }
                    }
                    Operations();
                    break;
                default:
                    break;
            }
        }

        // add contact method
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
            DisplayContacts();
            Operations();
        }
        //edit contact method
        public static void ModifyPersonInfo()
        {
            Console.WriteLine("\n [ EDIT CONTACT ] Select Field to edit -\n 1:First_name  2:Last_name  3:Address  4:City  5:State  6.Zipcode  7:Phone_Number  8.EmailId ");
            Console.WriteLine(" Type 0 to Exit Edit option. ");
            Console.Write(" Please provide an option : ");
            int choice = int.Parse(Console.ReadLine());

            foreach (var persn in ContactList)
            {
                switch (choice)
                {
                    case 1:
                        Console.Write(" Modify FirstName : ");
                        persn.FirstName = Console.ReadLine();
                        return;
                    case 2:
                        Console.Write(" Modify LastName : ");
                        persn.LastName = Console.ReadLine();
                        return;
                    case 3:
                        Console.Write(" Modify AddressLine : ");
                        persn.Address = Console.ReadLine();
                        return;
                    case 4:
                        Console.Write(" Modify City : ");
                        persn.City = Console.ReadLine();
                        return;
                    case 5:
                        Console.Write(" Modify State : ");
                        persn.State = Console.ReadLine();
                        return;
                    case 6:
                        Console.Write(" Modify ZipCode : ");
                        persn.ZipCode = int.Parse(Console.ReadLine());
                        return;
                    case 7:
                        Console.Write(" Modify PhoneNumber : ");
                        persn.PhoneNumber = Console.ReadLine();
                        return;
                    case 8:
                        Console.Write(" Modify EmailId : ");
                        persn.EmailId = Console.ReadLine();
                        return;
                    case 0:
                        break;
                    default:
                        Console.WriteLine(" Invalid value entered.");
                        break;
                }
            }
        }
        //delete selected contact
        public static void DeletePersonInfo(string findName)
        {
            int deleted = 0;
            for (int i = 0; i < ContactList.Count; i++)
            {
                if (ContactList[i].FirstName.Equals(findName))
                {
                    ContactList.RemoveAt(i);
                    Console.WriteLine(" Contact Removed. ");
                    deleted = 1;
                }
            }
            if (deleted != 1)
            {
                Console.WriteLine(" Contact not present. ");
            }
        }

        //display saved Contacts
        public static void DisplayContacts()
        {
            static void DisplayFormat(Person persn)
            {
                Console.WriteLine(" First Name \t: {0} \n Last Name \t: {1} ", persn.FirstName, persn.LastName);
                Console.WriteLine(" Address \t: {0} \n City \t\t: {1} ", persn.Address, persn.City);
                Console.WriteLine(" State \t\t: {0} \n ZipCode \t: {1} ", persn.State, persn.ZipCode);
                Console.WriteLine(" Phone Number \t: {0} \n EmailId \t: {1} \n", persn.PhoneNumber, persn.EmailId);
            }

            if (ContactList.Count >= 1)
            {
                Console.WriteLine("\n Displying saved contact details : \n");
                foreach (var persn in ContactList)
                {
                    DisplayFormat(persn);
                }
            }
            else
            {
                Console.WriteLine(" No contacts Present. Please add new contact. \n");
                AddPersonInfo();
            }
        }
    }
}