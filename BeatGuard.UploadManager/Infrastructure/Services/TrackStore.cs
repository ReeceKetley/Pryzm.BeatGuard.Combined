using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using BeatGuard.UploadManager.Domain;
using BeatGuard.UploadManager.Domain.Entities;

namespace BeatGuard.UploadManager.Infrastructure.Services
{
    public class TrackStore
    {
        public async Task<bool> Upload(Track track, Stream stream)
        {
            var s3Client = new AmazonS3Client(CredentialsProvider.GetAwsCredentials(), RegionEndpoint.EUWest2);
            var request = new PutObjectRequest();
            request.BucketName = "beatguard-private-storage";
            request.Key = track.UploadKey;
            request.InputStream = stream;
            try
            {
                var result = await s3Client.PutObjectAsync(request);
                if (result.HttpStatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return false;
        }
    }
}
