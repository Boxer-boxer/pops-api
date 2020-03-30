using ApiTest1.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest1.Services
{
    public class EventService
    {
        private readonly IMongoCollection<Event> _event;

        public EventService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _event = database.GetCollection<Event>(settings.EventsCollectionName);
        }
        public List<Event> Get() => _event.Find(ev => true).ToList();

        public Event Get(string id) =>
            _event.Find(e => e.Id == id).FirstOrDefault();

        public Event Create(Event ev)
        {
            _event.InsertOne(ev);
            return ev;
        }

        public void Update(string id, Event evIn) =>
            _event.ReplaceOne(user => user.Id == id, evIn);

        public void Remove(Event evIn)
        {
            _event.DeleteOne(e => e.Id == evIn.Id);
        }
        public void Remove(string id)
        {
            _event.DeleteOne(e => e.Id == id);
        }
    }
}
