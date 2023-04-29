using Amazon.Runtime;
using Amazon.S3.Transfer;
using Amazon.S3;
using Business.Services.AWS_S3.Abstract;
using Business.Services.AWS_S3.Entity;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.AWS_S3.Concrete
{
    using Amazon.S3;
    using Amazon.S3.Transfer;
    using Microsoft.Extensions.Configuration;
    using Amazon.Runtime;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Core.Utilities.Results;
    using System.Net;

    namespace AwsS3.Services
    {
        public class StorageService : IStorageService
        {
            private readonly IConfiguration _config;

            public StorageService(IConfiguration config)
            {
                _config = config;
            }

            public S3ResponseDto UploadFile(S3Object obj)
            {
                var awsCredentialsValues = new AwsCredentials()
                {
                    AccessKey = _config["AwsConfiguration:AWSAccessKey"],
                    SecretKey = _config["AwsConfiguration:AWSSecretKey"]
                };

                var credentials = new BasicAWSCredentials(awsCredentialsValues.AccessKey, awsCredentialsValues.SecretKey);

                var config = new AmazonS3Config()
                {
                    RegionEndpoint = Amazon.RegionEndpoint.EUCentral1
                };

                var response = new S3ResponseDto();
                try
                {
                    var uploadRequest = new TransferUtilityUploadRequest()
                    {
                        InputStream = obj.InputStream,
                        Key = obj.Prefix + obj.Name,
                        BucketName = obj.BucketName,
                        CannedACL = S3CannedACL.NoACL,
                    };

                    // initialise client
                    using var client = new AmazonS3Client(credentials, config);

                    // initialise the transfer/upload tools
                    var transferUtility = new TransferUtility(client);

                    // initiate the file upload
                    transferUtility.Upload(uploadRequest);

                    var objectUrl = $"https://{obj.BucketName}.s3.{config.RegionEndpoint.SystemName}.amazonaws.com/{obj.Prefix}{obj.Name}";


                    response.StatusCode = 201;
                    response.Message = $"{obj.Name} has been uploaded sucessfully";
                    response.ObjectUrl = objectUrl;
                    
                }
                catch (AmazonS3Exception s3Ex)
                {
                    response.StatusCode = (int)s3Ex.StatusCode;
                    response.Message = s3Ex.Message;
                }
                catch (Exception ex)
                {
                    response.StatusCode = 500;
                    response.Message = ex.Message;
                }
                return response;
            }

            public async Task<IResult> DeleteFile(string objectKey)
            {
                var awsCredentialsValues = new AwsCredentials()
                {
                    AccessKey = _config["AwsConfiguration:AWSAccessKey"],
                    SecretKey = _config["AwsConfiguration:AWSSecretKey"]
                };

                var credentials = new BasicAWSCredentials(awsCredentialsValues.AccessKey, awsCredentialsValues.SecretKey);

                var config = new AmazonS3Config()
                {
                    RegionEndpoint = Amazon.RegionEndpoint.EUCentral1
                };

                try
                {
                    using var client = new AmazonS3Client(credentials, config);

                    var deleteObjectRequest = new Amazon.S3.Model.DeleteObjectRequest()
                    {
                        BucketName = "ecommerce-demo1",
                        Key = objectKey,
                    };

                    var response = await client.DeleteObjectAsync(deleteObjectRequest);

                    return new SuccessResult();
                }
                catch (Exception ex)
                {
                    // hata yönetimi yapılabilir
                    return new ErrorResult();
                }
            }



        }
    }

}
