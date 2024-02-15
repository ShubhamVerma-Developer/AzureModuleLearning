// Include the HTTP module
const http = require("http");

// Set the port to 3000
const PORT = 3000;

// 1. Process incoming requests (req), reply with response (res)
const requestHandler = (req, res) => {
  res.writeHead(200, { "Content-Type": "text/plain" });
  res.end("hello world");
};

// 2. Create a server with the requestHandler
const server = http.createServer(requestHandler);

// 3. Start listening for incoming requests on port
server.listen(PORT, () => {
  console.log(`listening on port ${PORT}`);
});
