using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Messages
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public List<Author> Authors
        {
            get => authors;
            set
            {
                authors = value;
                OnPropertyChanged();
            }
        }
        public List<Post> Posts
        {
            get => posts;
            set
            {
                posts = value;
                OnPropertyChanged();
            }
        }

        public Author SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                selectedAuthor = value;
                LoadPosts(selectedAuthor);
            }
        }

        public Post SelectedPost { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public ActionCommand AddCommand { get; set; }
        public ActionCommand DeleteCommand { get; set; }

        private Author selectedAuthor;
        private List<Author> authors;
        private List<Post> posts;

        public event PropertyChangedEventHandler PropertyChanged;

        AuthorDataRepository authorDataRepository = new AuthorDataRepository();
        PostDataRepository postDataRepository = new PostDataRepository();

        public MainViewModel()
        {
            AddCommand = new ActionCommand(AddCommandAction);
            DeleteCommand = new ActionCommand(DeleteCommandAction);
            Authors = authorDataRepository.GetAllAuthors();
        }
        private void LoadPosts(Author selectedAuthor)
        {
            Posts = postDataRepository.GetPostsFor(selectedAuthor);
        }

        private void DeleteCommandAction()
        {
            if (SelectedPost != null)
            {
                postDataRepository.DeletePost(SelectedPost);
                LoadPosts(SelectedAuthor);
            }
        }

        private void AddCommandAction()
        {
            if (SelectedAuthor != null)
            {

                Post post = new Post();
                post.Content = Content;
                post.Date = DateTime.Now;
                post.Title = Title;

                SelectedAuthor.Posts.Add(post);

                authorDataRepository.UpdateAuthor(SelectedAuthor);

                LoadPosts(SelectedAuthor);

            }
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
