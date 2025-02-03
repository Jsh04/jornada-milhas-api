using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using JornadaMilhas.Application.Constants;
using JornadaMilhas.Application.Interfaces.Gateways;
using JornadaMilhas.Common.Results;
using Microsoft.Extensions.Configuration;

namespace JornadaMilhas.Infrastruture.Gateway;

public class UploadS3Service : IUploadService
{
    private readonly string _bucketName;
    private readonly IConfiguration _configuration;

    private readonly IAmazonS3 s3Client;

    public UploadS3Service(IConfiguration configuration)
    {
        _configuration = configuration;
        s3Client = GetClientsS3();
        _bucketName = _configuration["bucketName"];
    }

    public async Task<Result> UploadAsync(byte[] byteArray, string path)
    {
        try
        {
            var fileTransferUtility = new TransferUtility(s3Client);
            await fileTransferUtility.UploadAsync(path, _bucketName);
            return Result.Ok();
        }
        catch
        {
            return Result.Fail(FileErrors.CannotUploadFile);
        }
    }

    public async Task<Result> UploadAllAsync(ICollection<byte[]> bytesArrays, string path)
    {
        var listTasks = bytesArrays.Select(byteArray => UploadAsync(byteArray, path)).Cast<Task>().ToList();

        await Task.WhenAll(listTasks);

        return Result.Ok();
    }

    private IAmazonS3 GetClientsS3()
    {
        var awsCredentials = new BasicAWSCredentials(_configuration["KeyAccessUser"], _configuration["KeySecretUser"]);
        return new AmazonS3Client(awsCredentials, RegionEndpoint.USEast2);
    }
}