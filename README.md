# Chain of Responsibility Pattern


# Benefits

* Parameter and result types are specific to the service method (use case).
* Increased extensibility - you can insert new code, or replace existing handlers with different functionality via chain builders/ chain factory.
  * Allows for custom solutions for SaaS customers.
  * Chain Builders/Factory could leverage feature flag attributes to switch between feature-flag centric handlers. In other words, it is possible to have two handlers that individually handle the two feature flag states - a handler that handles legacy implementation, and a handler that handles the new logic represented by the feature flag being turned on.
* Avoids potential flaky state handling, if a feature flag state were changed mid-request, because the handlers would be determined at one instant.
* Handlers have the option to short-circuit downstream flow, e.g. to handle error conditions, or exceptional cases. Potential examples:
  * A handler that throttles requests to gracefully control DDoS, or rage-clicking, via a bulk-head pattern.
  * A handler that circuit-breaks an integration with a third-party service or internal microservice, to gracefully handle failures.
  * A validation handler that validates a request before attempting to process it.
  * A security handler that validates the request authorization before allowing the operation to proceed.
* Handlers have the option to transform downstream results as they're passed back down the call stack. Since handlers have a specific context to a given request, downstream results may be naïve, and a given handler could have better knowledge for gracefully handling failures or misinformed messaging.
* Chain handler method arguments enable a shared scope for a request.
  * Allows for external transaction management, by providing repositories with database context through the context parameter (same entity passed to each handler).
* Chain implementation can provide additional context for logging, e.g. the chain knows the handlers the chain is composed of, and the order the handlers are invoked. This could potentially eliminate the need for call stack logging, and exceptions.
* Benefits of composition.
  * Because the chain is composed of handlers, the resulting handler files provide high-level insight the functions of given service method. In other words, you can look at the filenames of a folder of handlers and get a sense of what is being done by each.
  * In contrast to a service that calls internal methods, handlers make it easier to find the code for given functionality - scanning the Source Explorer files vs scanning a service class with thousands of lines of code, and switching back and forth between different lines.
* Benefits of generics in the chain of responsibility pattern.
  * Some handlers don't need to know the specifics of the request or result, such as circuit-breaker and bulkhead handlers. So, these could be implemented as abstracts and then registered with the concrete generic types (e.g. specific context, parameter, and result types).
  * Generic TUnitOfWork allows flexibility with the data layer, should we choose to switch to a different data infrastructure (e.g. move from MySQL to T-SQL, or Elasticsearch, etc.)
  * Chain factory and builders can honor cross-cutting concerns, such as feature flag logic, common service-level concerns like validation, authorization, bulkheading, and circuit-breaking via handler selection for a given chain instance.
* Context awareness at the time of chain formation allows for implementation choices.
  * Chain factory and builders receive request context that can identify the type of user, and which account the request pertains to. So, if handlers were to address specific concerns for different user types, the chain factory or builder could choose the handler specific to the given request. For example, a payment request could be between a PMC and vendor (CreatePaymentToVendor handler), or a rent payment from a resident to a property's operating account (CreateRentPayment handler), etc. As a result, API endpoint flexibility narrows the API breadth to simplify the API.
  * API flexibility makes endpoints to be more RESTful. Handlers can make the system handle state changes inside an object-centered endpoint, instead of calling verb-centric endpoints. For example, consider order submission on an ecommerce website. The verb-centric approach would be to have an endpoint called "submitOrder", where only the logic for submitting order is run. Instead, in a RESTful approach, the state change from "Pending" to "Submitted" order status that could trigger the logic to submit the order (via a SubmitOrder handler). Additionally, we could add a StatusValidation handler that would return an error if someone tried to update their order from "Submitted" to "Pending", avoiding duplicate orders (or payments).

# Trade-Offs

* There's a learning curve.
* Computational and memory overhead due to instantiating multiple handler instances per request.