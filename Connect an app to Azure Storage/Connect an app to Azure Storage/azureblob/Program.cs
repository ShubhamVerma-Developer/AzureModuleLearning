
using Azure.Storage.Blobs;
class Program
{
    static void Main()
    {
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=fsfsd;AccountKey=hJYJOVQRCJNWP0IJH4WwyEShV2NfOnx5NfihBsAKFWprcWpUxMvRSzHibtlTwV/2ZJgntzkjxPPk+AStiWWmNg==;EndpointSuffix=core.windows.net";
        string containerName = "democonstainer";

        BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

        var blobs = container.GetBlobs();
        foreach (var blob in blobs)
        {
            Console.WriteLine($"{blob.Name} --> Created On: {blob.Properties.CreatedOn:yyyy-MM-dd HH:mm:ss}  Size: {blob.Properties.ContentLength}");
        }
    }
}

