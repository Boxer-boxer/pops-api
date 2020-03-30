using System;
using System.Collections.Generic;
using ApiTest1.Models;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest1.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Users> _users;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<Users>(settings.PopupsCollectionName);
        }
        public List<Users> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public Users Get(string id) =>
            _users.Find(user => user.Id == id).FirstOrDefault();

        public Users Create(Users user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, Users usersIn) =>
            _users.ReplaceOne(user => user.Id == id, usersIn);

        public void Remove(Users usersIn)
        {
            _users.DeleteOne(user => user.Id == usersIn.Id);
        }
        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }
    }
}
