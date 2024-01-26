using PartyPalApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.MVVM.ViewModels
{
    public class FriendViewModel
    {
        public ObservableCollection<Account> Accounts { get; set; }

        public FriendViewModel()
        {
            InitializeAccounts();
        }

        private void InitializeAccounts()
        {
            // Mimic fetching accounts from a database (hardcoded for now)
            Accounts = new ObservableCollection<Account>
            {
                new Account { Name = "User1", Email = "user1@example.com" },
                new Account { Name = "User2", Email = "user2@example.com" },
                new Account { Name = "User3", Email = "user3@example.com" },
                // Add more accounts as needed
            };

            // You can order the accounts if necessary
            Accounts = new ObservableCollection<Account>(Accounts.OrderBy(a => a.Name));
        }
    }
}
