
using PartyPalApp.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace PartyPalApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EventViewmodel
    {
        public ObservableCollection<Event> Events { get; set; }

        public Event CurrentEvent { get; set; }

        public ICommand? AddOrUpdateCommand { get; set; }
        public ICommand? DeleteWithChildrenCommand { get; set; }
        public ICommand? IncrementAttendanceCount {  get; set; }


        public EventViewmodel()
        {
            Refresh();
            GenerateNewEvent();
            AddOrUpdateCommand = new Command(async () =>
            {
                App.EventRepo.SaveEntity(CurrentEvent);
                Console.WriteLine(App.EventRepo.StatusMessage);
                GenerateNewEvent();
                Refresh();
            });

            DeleteWithChildrenCommand = new Command((object parameter) =>
            {
                if (parameter is Event EventToDelete)
                {
                    App.EventRepo.DeleteEntityWithChildren(EventToDelete);
                    Refresh();
                    GenerateNewEvent();
                }
            });

            IncrementAttendanceCount = new Command(() =>
            {
                CurrentEvent.AttendanceCount++;
                App.EventRepo.SaveEntity(CurrentEvent);
                Refresh();
            });
        }


        private void GenerateNewEvent()
        {
            CurrentEvent = new Event();
        }

        public void Refresh()
        {
            List<Event> eventsList = App.EventRepo.GetEntities();
            Events = new ObservableCollection<Event>(eventsList);
        }
    }
}
