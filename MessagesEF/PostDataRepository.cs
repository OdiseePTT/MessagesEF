using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages
{
    internal class PostDataRepository
    {
        MessagesDB messagesDB = new MessagesDB();

        public List<Post> GetPosts()
        {
            return messagesDB.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return messagesDB.Posts.First(post => post.Id == id);
        }

        public List<Post> GetPostsFor(Author selectedAuthor)
        {
            return messagesDB.Posts.Where(p => p.Author_id == selectedAuthor.Id).ToList();
        }

        public void CreatePost(Author selectedAuthor, string title, string content)
        {
            Post post = new Post();
            post.Author_id = selectedAuthor.Id;
            post.Title = title;
            post.Content = content;
            post.Date = DateTime.Now;

            messagesDB.Posts.Add(post);
            messagesDB.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            Post postToUpdate = messagesDB.Posts.First(p => p.Id == post.Id);

            postToUpdate.Author_id = post.Author_id;
            postToUpdate.Date = post.Date;
            postToUpdate.Content = post.Content;
            postToUpdate.Title = post.Title;

            messagesDB.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            Post postToDelete = messagesDB.Posts.First(p => p.Id == post.Id);
            messagesDB.Posts.Remove(postToDelete);
            messagesDB.SaveChanges();
        }
    }
}
