# AnyObjectStorage

> 开发中我们经常会对一些程序启动后就不会变化的数据进行缓存，例如当天日期图片base64字符串、各种Provider的映射关系等，我们比较常用的如`ConcurrentDictionary<,>`和`Dictionary<,>`这种字典来做本地缓存，为了不在项目中到处充斥着这样的零散代码，因此对字典中提供的常用方法进行二次封装，方便快速集成。

### 快速集成

```bash
> dotnet add package OStorage --version 1.0.1
```

然后注入服务：

```c#
public void ConfigureServices(IServiceCollection services)
{
    //其他代码
    services.AddOStorage();
}
```

最后在你的项目中注入`IAnyObjectStorage<TKey, TValue>`服务，就可以愉快的使用它保存你想保存的任何数据了。

项目还提供了默认以字符串为Key的实现，可注入`IAnyObjectStorage<TValue>`快速集成，当然如果你有其他自定义实现，可继承`AnyObjectStorage<TKey, TValue>`或者`AnyObjectStorage<TValue>`完成自定义逻辑，最后手动注入服务，示例如下：

```c#
public void ConfigureServices(IServiceCollection services)
{
   //其他代码
   services.AddOStorage()
      .AddCustomOStorage<IImgBase64ObjectStorage, ImgBase64ObjectStorage>();
}

public interface IImgBase64ObjectStorage : IAnyObjectStorage<string>
{
  	
}

public class ImgBase64ObjectStorage : AnyObjectStorage<string>, IImgBase64ObjectStorage
{
    
}
```

最后注入`IImgBase64ObjectStorage`服务，完成集成。