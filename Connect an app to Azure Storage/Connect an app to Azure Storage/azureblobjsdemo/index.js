const { BlobServiceClient } = require("@azure/storage-blob");

const connectionString =
  "DefaultEndpointsProtocol=https;AccountName=fsfsd;AccountKey=hJYJOVQRCJNWP0IJH4WwyEShV2NfOnx5NfihBsAKFWprcWpUxMvRSzHibtlTwV/2ZJgntzkjxPPk+AStiWWmNg==;EndpointSuffix=core.windows.net";
const containerName = "democonstainer";

const blobServiceClient =
  BlobServiceClient.fromConnectionString(connectionString);
const containerClient = blobServiceClient.getContainerClient(containerName);

async function listBlobs() {
  const blobs = containerClient.listBlobsFlat();
  for await (const blob of blobs) {
    console.log(
      `${blob.name} --> Created: ${blob.properties.createdOn}   Size: ${blob.properties.contentLength}`
    );
  }
}

listBlobs().catch((error) => {
  console.error("Error listing blobs:", error.message);
});
