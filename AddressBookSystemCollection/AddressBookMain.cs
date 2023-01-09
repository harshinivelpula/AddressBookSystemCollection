using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemCollection
{
    public class AddressBookMain
    {
        //list for storing objects for person class
        public List<Person> ContactList;
        public static Dictionary<string, List<Person>> contactsDictionary = new Dictionary<string, List<Person>>();
        public static string adrBookName;

        public AddressBookMain()
        {
            this.ContactList = new List<Person>();
        }

        //starting application
        public void Book()
        {
            Console.WriteLine(" Welcome to Address Book Program \n");
            Console.WriteLine(" No contacts in address book... \n Please provide following details : ");
            NewAdrBook();
        }

        //new address book / dictionary
        public static void NewAdrBook()
        {
            Console.Write(" Creating a new AddressBook. Please provide name : ");
            adrBookName = Console.ReadLine();

            if (contactsDictionary.ContainsKey(adrBookName))
            {
                Console.WriteLine(" This name already exists.. Please add new name..");
                NewAdrBook();
            }
            else
            {
                contactsDictionary[adrBookName] = new List<Person>();
                Console.WriteLine(" Here are available address books : ");
                foreach (var ab in contactsDictionary)
                {
                    Console.Write("\t" + ab.Key);
                }
                Console.WriteLine("\n\n Now you can add person details.");
                AddPersonInfo(adrBookName);
            }
        }


        // add contact method
        public static void AddPersonInfo(string adrBookName)
        {
            if (contactsDictionary.ContainsKey(adrBookName))
            {

                Console.WriteLine("\n Working on address book : " + adrBookName);
                Person persn = new Person();

                Console.Write("\n Enter First Name : ");
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

                contactsDictionary[adrBookName].Add(persn);
                ContactManager.Operations();
            }
            else
            {
                Console.WriteLine(" Address book not found. Please retry.");
                ContactManager.Operations();
            }
        }
        //edit contact method
        public static void ModifyPersonInfo(string adrBookName, string findName)
        {
            Console.WriteLine("\n Working on address book : " + adrBookName);
            if (contactsDictionary[adrBookName].Count > 0)
            {
                foreach (Person per in contactsDictionary[adrBookName])
                {
                    if (findName.ToUpper().Equals(per.FirstName.ToUpper()))
                    {
                        Console.WriteLine("\n [ EDIT CONTACT ] Select Field to edit -\n 1.First_name\t2.Last_name\t3.Address\t4.City\t5.State\t6.Zipcode\t7.Phone_Number\t8.EmailId ");
                        Console.WriteLine(" Type 0 to Exit Edit operation. ");
                        Console.Write(" Please provide an option : ");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Write(" Modify FirstName : ");
                                per.FirstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write(" Modify LastName : ");
                                per.LastName = Console.ReadLine();
                                break;
                            case 3:
                                Console.Write(" Modify AddressLine : ");
                                per.Address = Console.ReadLine();
                                break;
                            case 4:
                                Console.Write(" Modify City : ");
                                per.City = Console.ReadLine();
                                break;
                            case 5:
                                Console.Write(" Modify State : ");
                                per.State = Console.ReadLine();
                                break;
                            case 6:
                                Console.Write(" Modify ZipCode : ");
                                per.ZipCode = int.Parse(Console.ReadLine());
                                break;
                            case 7:
                                Console.Write(" Modify PhoneNumber : ");
                                per.PhoneNumber = Console.ReadLine();
                                break;
                            case 8:
                                Console.Write(" Modify EmailId : ");
                                per.EmailId = Console.ReadLine();
                                break;
                            case 0:
                                break;
                            default:
                                Console.WriteLine(" Invalid value entered.");
                                break;
                        }
                    }
                }
            }
        }
        //delete selected contact
        public static void DeletePersonInfo(string adrBookName, string findName)
        {
            if (contactsDictionary.ContainsKey(adrBookName))
            {
                Console.WriteLine("\n Working on address book : " + adrBookName);
                int deleted = 0;

                if (contactsDictionary[adrBookName].Count > 0)
                {
                    foreach (Person contact in contactsDictionary[adrBookName])
                    {
                        if (findName.ToUpper() == contact.FirstName.ToUpper())
                        {
                            contactsDictionary[adrBookName].Remove(contact);
                            deleted = 1;
                            Console.WriteLine(" Contact of {0} removed.", findName);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" - - ");
                        }
                    }
                }
                if (deleted == 0)
                {
                    Console.WriteLine(" Contact not present. ");
                }
            }
            else
            {
                Console.WriteLine(" address book not found.");
            }
        }

        //display saved Contacts
        public static void DisplayContacts(string adrBookName)
        {
            if (contactsDictionary[adrBookName].Count > 0)
            {
                Console.WriteLine(" Displaying contacts in addresss book : " + adrBookName);
                foreach (Person person in contactsDictionary[adrBookName])
                {
                    Console.WriteLine(" First Name \t: {0} \n Last Name \t: {1} ", person.FirstName, person.LastName);
                    Console.WriteLine(" Address \t: {0} \n City \t\t: {1} ", person.Address, person.City);
                    Console.WriteLine(" State \t\t: {0} \n ZipCode \t: {1} ", person.State, person.ZipCode);
                    Console.WriteLine(" Phone Number \t: {0} \n EmailId \t: {1} \n", person.PhoneNumber, person.EmailId);
                }
            }
            else
            {
                Console.WriteLine(" No contacts Present. Please add new contact. \n");
            }
        }
    }
}