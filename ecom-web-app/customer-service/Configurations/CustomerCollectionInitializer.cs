using MongoDB.Driver;

namespace ecom_web_app.Configurations;

public class CustomerCollectionInitializer
{
    private readonly IMongoDatabase database;
    

    public CustomerCollectionInitializer(IMongoDatabase database)
    {
        this.database = database;


    }

    public async Task CreateIfNotExistsAsync()
    {
        var collections = await database.ListCollectionNames().ToListAsync();
        if (!collections.Contains("customers"))
        {
            await database.CreateCollectionAsync("customers");  
        }
    }
}