using api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class ApiService
    {
        private readonly IMongoCollection<ChatDetails> _apiValue;

        public ApiService(IChatDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _apiValue = database.GetCollection<ChatDetails>(settings.ChatCollectionName);
        }

        public List<ChatDetails> Get() =>
            _apiValue.Find(book => true).ToList();

        public ChatDetails Get(string id) =>
            _apiValue.Find<ChatDetails>(book => book.Id == id).FirstOrDefault();

        public ChatDetails Create(ChatDetails book)
        {
            _apiValue.InsertOne(book);
            return book;
        }

        public void Update(string id, ChatDetails bookIn) =>
            _apiValue.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(ChatDetails bookIn) =>
            _apiValue.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _apiValue.DeleteOne(book => book.Id == id);


        public ChatDetails GetByName(string Uname)
        {
            return _apiValue.Find(name => name.Uname == Uname).FirstOrDefault();
        }

    }
}
