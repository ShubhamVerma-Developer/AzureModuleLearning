# Web servers and web applications

A web server is a piece of software that responds to requests from clients. A web application sits on top of the web server. Some environments, like Node.js, provide both the web server and the web application in a framework. In this module, the web server is provided by the HTTP module. The web application is provided by the Express.js framework and includes the web server.

Learn more:

- Web applications: The application delivers a web app to the client:
  Visually with HTML, CSS, and JavaScript
  Data with APIs
  Both visual and data with a combination of HTML, CSS, JavaScript, and APIs. This is considered a monolithic application.
- URL Routing: URL routing is a mechanism to provide functionality of the web server when a specific URL address is requested. For example, the URL /products might be associated with a function that returns a list of products. The URL /products/1 might be associated with a function that returns a specific product.
- HTTP Headers: These are key-value pairs that are sent from the client to the server. They contain information about the request or response.
  Support for different content types: A client can request data in a specific format and may return in that format such as plain text, JSON, HTML, or CSV.
  Authentication/Authorization: Some data might be sensitive. A user might need to sign in or have a specific role or permission level to access the data. This is handled in the HTTP header.
- Data exchange: Users may need to view and add data to the system. To add data, users might enter data in a form or upload files.
  Time to market: To create web applications and APIs efficiently, choose tools and frameworks that provide solutions to common problems. These choices help the developer quickly meet the business requirements of the job.

## HTTP module in Node.js
