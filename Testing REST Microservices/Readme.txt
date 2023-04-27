Simulation of contract consumer-driven testing of REST Microservices.

- OrderSvc-Consumer: code example of a "consumer" in which I define prefixed values to test. The microservice generates the "order-discounts.json" file,
						which is the contract will be used by the provider, and to test.

- DiscoverSvc-Provider: code example of a "producer" that try to call the consumer. The test verifies that the provider satisfies the contract.