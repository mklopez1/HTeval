using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.EnterpriseServices;

namespace HTeval.Models
{
    public class Contacts
    {
        public List<ContactModel> ContactList = new List<ContactModel>();

        public ContactModel GetContact(int id)
        {
            foreach (ContactModel listItem in ContactList)
            {
                if (listItem.ID == id) return listItem;
            }
            return null;

            // do NOT use Find as it won't return null when not found
            //return ContactList.Find(cm => cm.ContactId == id);
        }

        public void AddContact(ContactModel cm)
        {
            ContactList.Add(cm);
        }

        public void UpdateContact(ContactModel cm)
        {
            foreach (ContactModel listItem in ContactList)
            {
                if (listItem.ID == cm.ID)
                {
                    listItem.FirstName = cm.FirstName;
                    listItem.LastName = cm.LastName;
                    listItem.EmailAddress = cm.EmailAddress;
                    listItem.BirthDate = cm.BirthDate;
                    listItem.NumberOfComputers = cm.NumberOfComputers;
                    break;
                } 
            }
        }

        public void DeleteContact(ContactModel cm)
        {
            foreach (ContactModel listItem in ContactList)
                if (listItem.ID == cm.ID)
                {
                    ContactList.Remove(listItem);
                    break;
                }
        }

    }
}