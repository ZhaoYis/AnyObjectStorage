namespace OStorage.UnitTest;

public interface IImgBase64ObjectStorage : IAnyObjectStorage<string>
{
}

public class ImgBase64ObjectStorage : AnyObjectStorage<string>, IImgBase64ObjectStorage
{
}