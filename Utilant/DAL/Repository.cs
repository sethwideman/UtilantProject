using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Utilant.Models;

namespace Utilant.DAL
{
    public class Repository
    {
        public List<AlbumViewModel> getAlbumsVM()
        {
            List<AlbumViewModel> albumVM = new List<AlbumViewModel>();
            List<Album> albums = this.getAlbums();
            List<User> users = this.getUsers();
            List<Photo> photos = this.getPhotos();

            foreach (Album album in albums)
            {
                AlbumViewModel tmp = new AlbumViewModel();
                User user = users.Find(x => x.id == album.userId);
                Photo photo = photos.Find(x => x.albumId == album.id);

                tmp.albumId = album.id;
                tmp.Title = album.title;
                tmp.thumbnail = photo.thumbnailUrl;
                tmp.UsersId = user.id;
                tmp.UsersName = user.name;
                tmp.UsersEmail = user.email;
                tmp.UsersPhone = user.phone;
                tmp.UsersAddress = user.getAddress();

                albumVM.Add(tmp);
            }

            return albumVM;
        }

        public List<Photo> getPhotosVM(int albumId)
        {
            List<Photo> tmp = this.getPhotos();
            var photos = from s in tmp
                         select s;

            photos = photos.Where(s => s.albumId == albumId);

            return photos.ToList();
        }

        public User getUser(int userId)
        {
            List<User> users = this.getUsers();
            User user = users.Find(x => x.id == userId);
            return user;
        }

        public List<Post> getPosts(int userId)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://jsonplaceholder.typicode.com/posts"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Post> allPosts = JsonConvert.DeserializeObject<List<Post>>(jsonString);
            var posts = from s in allPosts
                        select s;

            posts = posts.Where(s => s.userId == userId);
            return posts.ToList();
        }

        private List<Album> getAlbums()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://jsonplaceholder.typicode.com/albums"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(jsonString);
            return albums;
        }

        private List<Photo> getPhotos()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://jsonplaceholder.typicode.com/photos"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(jsonString);
            return photos;
        }

        private List<User> getUsers()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://jsonplaceholder.typicode.com/users"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return users;
        }
    }
}