using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Application.Interfaces.Gateways;

public interface IUploadService
{
    Task<Result> UploadAsync(byte[] byteArray, string path);

    Task<Result> UploadAllAsync(ICollection<byte[]> bytesArrays, string path);
}