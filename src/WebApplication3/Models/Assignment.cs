using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Assignment
    {
        private readonly List<ClientContact> clientContacts;

        public Assignment(int id, string clientName, string locationAddress,
                          DateTime countDate, string basicInstructions,
                          string finalDeliverable, int expectedNumberOfItems, bool isComplete)
        {
            this.clientContacts = new List<ClientContact>();

            this.Id = id;
            this.ClientName = clientName;
            this.LocationAddress = locationAddress;
            this.CountDate = countDate;
            this.BasicInstructions = basicInstructions;
            this.FinalDeliverable = finalDeliverable;
            this.ExpectedNumberOfItems = expectedNumberOfItems;
            this.IsComplete = isComplete;
        }

        public int Id { get; set; }

        public string ClientName { get; set; }

        public string LocationAddress { get; set; }

        public DateTime CountDate { get; set; }

        public string BasicInstructions { get; set; }

        public string FinalDeliverable { get; set; }

        public int ExpectedNumberOfItems { get; set; }

        public bool IsComplete { get; set; }

        public IEnumerable<ClientContact> ClientContacts
        {
            get { return this.clientContacts; }
        }

        public void AddContactItem(ClientContact contact)
        {
            this.clientContacts.Add(contact);
        }
    }
}
