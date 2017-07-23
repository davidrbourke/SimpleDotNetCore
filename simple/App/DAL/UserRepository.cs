using System;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Simple.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Simple.DAL
{
    public class UserRepository : IRepository<User>
    {
        private string _connectionString;
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<User> _collection;

        public UserRepository()
        {
            _connectionString = "mongodb://localhost:27017";
            _client = new MongoClient(_connectionString);
            _db = _client.GetDatabase("SimpleUser");            
            _collection = _db.GetCollection<User>("Users");
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> predicate)
        {
            IAsyncCursor<User> users = await _collection.FindAsync<User>(predicate);
            User user = await users.FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> AddAsync(User user)
        {
            await _collection.InsertOneAsync(user);
            return user;
        }

        public async Task<User> UpdateAsync(string id, User entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id.Equals(id), entity, new UpdateOptions {
                IsUpsert = true
            });

            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id.Equals(id));
        }
    }
}