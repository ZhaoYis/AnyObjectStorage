using Microsoft.Extensions.DependencyInjection;

namespace OStorage.UnitTest;

public class AnyObjectStorage_UnitTest
{
    private readonly IAnyObjectStorage<string> _anyObjectStorage;
    private readonly IImgBase64ObjectStorage _imgBase64ObjectStorage;

    public AnyObjectStorage_UnitTest()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddOStorage()
            .AddCustomOStorage<IImgBase64ObjectStorage, ImgBase64ObjectStorage>();

        var serviceProvider = services.BuildServiceProvider();
        _anyObjectStorage = serviceProvider.GetRequiredService<IAnyObjectStorage<string>>();
        _imgBase64ObjectStorage = serviceProvider.GetRequiredService<IImgBase64ObjectStorage>();
    }

    [Fact]
    public void AddOrUpdate_Add_Not_Null()
    {
        string key = "cache_key_1";
        _anyObjectStorage.AddOrUpdate(key, "OStorage");

        var value = _anyObjectStorage.Get(key);

        Assert.Equal(value, "OStorage");
    }

    [Fact]
    public void CustomStorage_AddOrUpdate_Add_Not_Null()
    {
        string key = "cache_key_2";
        _imgBase64ObjectStorage.AddOrUpdate(key, "Custom OStorage");

        var value = _imgBase64ObjectStorage.Get(key);

        Assert.Equal(value, "Custom OStorage");
    }
}