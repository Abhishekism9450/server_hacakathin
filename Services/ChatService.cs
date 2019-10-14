using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Cors;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace api.Services
{
    public class ChatService
    {
        private readonly IMongoCollection<ChatDetails> _books;

        public ChatService(IChatDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<ChatDetails>(settings.ChatCollectionName);
        }

        public List<ChatDetails> Get() =>
            _books.Find(book => true).ToList();

        public ChatDetails Get(string id) =>
            _books.Find<ChatDetails>(book => book.Id == id).FirstOrDefault();

        public ChatDetails Create(ChatDetails book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, ChatDetails bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(ChatDetails bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);

        public List<ChatDetails> GetByUser(string id) =>
            _books.Find(Confession => Confession.Uname == id).ToList();
    }
}
