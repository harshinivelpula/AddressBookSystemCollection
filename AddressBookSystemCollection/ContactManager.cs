using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemCollection
{
    public class ContactManager
    {
        public static int bookFound { get; private set; }

        public static void Operations()
        {
            Console.WriteLine("\n Available options :\n 1.Add_contact\t 2.Edit_contact\t 3.Delete_Contact\t 4.View_contacts\t 5.New_address_book\t 0.Exit \n");
            Console.Write(" Provide option :  ");
            int userAction = int.Parse(Console.ReadLine());
            string findName, searchAdrBookName;
            switch (userAction)
            {
                case 1:
                    Console.Write("\n  Enter addressbook name to select and add contact : ");
                    searchAdrBookName = Console.ReadLine();

                    AddressBookMain.AddPersonInfo(searchAdrBookName);
                    Operations();
                    break;

                case 2:
                    Console.Write("\n  Enter addressbook name to find and edit contact : ");
                    searchAdrBookName = Console.ReadLine();
                    Console.Write("\n  Enter Firstname to find and edit contact : ");
                    findName = Console.ReadLine();

                    AddressBookMain.ModifyPersonInfo(searchAdrBookName, findName);
                    AddressBookMain.DisplayContacts(searchAdrBookName);
                    Operations();
                    break;

                case 3:
                    Console.Write("\n  Enter addressbook name to find and delete contact : ");
                    searchAdrBookName = Console.ReadLine();
                    Console.Write("\n  Enter Firstname to find and delete contact : ");
                    findName = Console.ReadLine();

                    AddressBookMain.DeletePersonInfo(searchAdrBookName, findName);
                    AddressBookMain.DisplayContacts(searchAdrBookName);
                    Operations();
                    break;

                case 4:
                    Console.WriteLine(" Here are available address books : ");
                    foreach (var ab in AddressBookMain.contactsDictionary)
                    {
                        Console.Write("\t" + ab.Key);
                    }
                    Console.Write("\n Enter address book name : ");
                    searchAdrBookName = Console.ReadLine();
                    AddressBookMain.DisplayContacts(searchAdrBookName);
                    Operations();
                    break;

                case 5:

                    AddressBookMain.NewAdrBook();
                    Operations();
                    break;
                case 6:
                    AddressBookMain.SearchPerson();
                    Operations();
                    break;
                case 7:
                    AddressBookMain.DisplayByCityState();
                    Operations();
                    break;

                case 0: break;

                default:
                    break;
            }
            void CheckAddresssBook(string searchAdrBookName)
            {
                foreach (var ab in AddressBookMain.contactsDictionary)
                {
                    if ((ab.Key).ToUpper().Equals(searchAdrBookName.ToUpper()))
                    {
                        continue;
                    }
                    else
                    {
                        bookFound = 0;
                    }
                }
                if (bookFound == 0)
                {
                    Console.WriteLine(" --> Address book not found.");
                    Operations();
                }
            }

            void DisplayABList()
            {
                Console.Write("\n Here are available address books : ");
                foreach (var ab in AddressBookMain.contactsDictionary)
                {
                    Console.Write(" " + ab.Key);
                }
            }
        }
    }
}