using CardsApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CardsApi.Services
{
    public class CardsService
    {
        private readonly IMongoCollection<Card> _cardsCollection;

        public CardsService(
            IOptions<CardsStorageDatabaseSettings> cardsStorageDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                cardsStorageDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                cardsStorageDatabaseSettings.Value.DatabaseName);

            _cardsCollection = mongoDatabase.GetCollection<Card>(
                cardsStorageDatabaseSettings.Value.CardsCollectionName);
        }

        public async Task<List<Card>> GetAsync() =>
            await _cardsCollection.Find(_ => true).ToListAsync();

        public async Task<Card?> GetAsync(string id) =>
            await _cardsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Card card) =>
            await _cardsCollection.InsertOneAsync(card);

    }
}
