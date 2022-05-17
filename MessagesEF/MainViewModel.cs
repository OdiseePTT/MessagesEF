using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    internal class MainViewModel
    {
        public ObservableCollection<Object> Users { get; set; }
        public ObservableCollection<Object> Messages { get; set; }

        public Object SelectedUser { get; set; }
        public Object SelectedMessage { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public ActionCommand AddCommand { get; set; }
        public ActionCommand DeleteCommand { get; set; }

        public MainViewModel()
        {
            AddCommand = new ActionCommand(AddCommandAction);
            DeleteCommand = new ActionCommand(DeleteCommandAction);
        }

        private void DeleteCommandAction()
        {
            throw new NotImplementedException();
        }

        private void AddCommandAction()
        {
            throw new NotImplementedException();
        }
    }
}
