namespace LYStudio.Settings
{
    public class MongoDbConfig
    {
        public string Name { get; init; }
        public string Host { get; init; }
        public int Port { get; init; }
        public string ConnectionString => $"mongodb://{Host}:{Port}";
        public string DatabaseName { get; set; } = null!;
        public string ProfilesCollectionName { get; set; } = $"Profiles";
    }
}
