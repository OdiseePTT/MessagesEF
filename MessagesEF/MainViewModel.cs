using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Messages
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public Object SelectedPost { get; set; }
        private Object selectedAuthor;
        private List<Object> authors;
        private List<Object> posts;
        public List<Object> Authors
        {
            get => authors;
            set
            {
                authors = value;
                OnPropertyChanged();
            }
        }
        public List<Object> Posts
        {
            get => posts;
            set
            {
                posts = value;
                OnPropertyChanged();
            }
        }

        public Object SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                selectedAuthor = value;
            }
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public ActionCommand AddCommand { get; set; }
        public ActionCommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
