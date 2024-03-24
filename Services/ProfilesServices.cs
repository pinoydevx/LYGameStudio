using LYStudio.Models;
using LYStudio.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NuGet.Configuration;

namespace LYStudio.Services;

/// <summary>
/// CRUD Service for gamer profiles
/// </summary>
public class ProfilesService
{
    private readonly IMongoCollection<Profile> _profilesCollection;

    public ProfilesService(
        IOptions<Settings.MongoDbConfig> profilesDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            profilesDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            profilesDatabaseSettings.Value.DatabaseName);

        _profilesCollection = mongoDatabase.GetCollection<Profile>(
            profilesDatabaseSettings.Value.ProfilesCollectionName);
    }

    public async Task<List<Profile>> GetAsync() =>
        await _profilesCollection.Find(_ => true).ToListAsync();

    public async Task<Profile?> GetAsync(string id) =>
        await _profilesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Profile newProfile) =>
        await _profilesCollection.InsertOneAsync(newProfile);

    public async Task UpdateAsync(string id, Profile updatedProfile) =>
        await _profilesCollection.ReplaceOneAsync(x => x.Id == id, updatedProfile);

    public async Task RemoveAsync(string id) =>
        await _profilesCollection.DeleteOneAsync(x => x.Id == id);
}