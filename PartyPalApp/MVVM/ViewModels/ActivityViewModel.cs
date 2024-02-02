using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PartyPalApp.MVVM.Models;
using PropertyChanged;

namespace PartyPalApp.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ActivityViewModel
    {
        public ObservableCollection<Activity> Activities { get; set; }
        public Activity CurrentActivity { get; set; }
        public ObservableCollection<Activity> UpcomingActivities { get; set; }
        public ICommand? AddOrUpdateCommand { get; set; }
        public ICommand? DeleteCommand { get; set; }

        public ActivityViewModel()
        {
            Refresh();
            GeneratenewActivity();
            AddOrUpdateCommand = new Command(async () =>
            {
                App.ActivityRepo.SaveEntity(CurrentActivity);
                Console.WriteLine(App.ActivityRepo.StatusMessage);
                GeneratenewActivity();
                Refresh();
            });

            DeleteCommand = new Command((object parameter) =>
            {
                if (parameter is Activity activityToDelete)
                {
                    App.ActivityRepo.DeleteEntity(activityToDelete);
                    Refresh();
                    GeneratenewActivity();
                }
            });
        }


        private void GeneratenewActivity()
        {
            CurrentActivity = new Activity();
        }

        public void Refresh()
        {
            List<Activity> activitiesList = App.ActivityRepo.GetEntities();
            Activities = new ObservableCollection<Activity>(activitiesList);

            Console.WriteLine($"Number of Activities in the database: {Activities.Count}");
        }
    }


}
