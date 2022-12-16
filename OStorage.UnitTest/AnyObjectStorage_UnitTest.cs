using Microsoft.Extensions.DependencyInjection;

namespace OStorage.UnitTest;

public class AnyObjectStorage_UnitTest
{
    private readonly IAnyObjectStorage<string> _anyObjectStorage;

    public AnyObjectStorage_UnitTest()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddOStorage();

        var serviceProvider = services.BuildServiceProvider();
        _anyObjectStorage = serviceProvider.GetRequiredService<IAnyObjectStorage<string>>();
    }

    [Fact]
    public void AddOrUpdate_Add_Not_Null()
    {
        string key = "cache_key_1";
        _anyObjectStorage.AddOrUpdate(key, "OStorage");

        var value = _anyObjectStorage.Get(key);

        Assert.Equal(value, "OStorage");
    }
}