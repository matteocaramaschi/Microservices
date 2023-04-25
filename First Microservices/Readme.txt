First microservices. Learning with "Pro Microservices in .NET 6" by Sean Whitesell, Robert Richardson, Matthew Groves

The idea is simulate a company which has to move from a monolith to a core + microservices infrastructure.

- The GoogleAPI folder contains three projects to simulate retrieving location data from GoogleAPIs, leveraging firstly REST, then gRPC.
- The main folder is MessageMicroservices. TestClient project simulates the monolith, while MessageContracts represents data model used and 
	Invoice and Payment are two microservices to manage invoice creation and payment answers. This microservices leverage RabbitMQ to communicate easily.