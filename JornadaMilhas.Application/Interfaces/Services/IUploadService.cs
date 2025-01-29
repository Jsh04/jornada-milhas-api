using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface IUploadService
{
    Task<Result> UploadAsync(byte[] byteArray, string path);

    Task<Result> UploadAllAsync(ICollection<byte[]> bytesArrays, string path);
}