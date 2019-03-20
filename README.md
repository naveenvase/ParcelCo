
# Not ready for review yet #
# Parse the Parcel Developer Notes #

* This exercise is based on loosely coupled components.It utilises dependency injection, seperation of concerns, SOLID princples and strategy pattern. It relies on C#(7.1) and .net core 2.1 framework. It consists of 
  * console app - Only a stub to run the library services
  * Unit Tests
  * library projects
	* ParcelCo.Parcel.ServiceContracts
	* ParcelCo.Parcel.ServiceImplementation
	* ParcelCo.Parcel.ModelContracts
	* ParcelCo.Parcel.ModelImplementation
	* ParcelCo.Json.ServiceContracts - to retrieve json data from a given file
	* ParcelCo.Json.ServiceImplementation
	* ParcelCo.Parcel.Resources - Caters for localised content. Designed the solution but needs resource files for various languages. 
	* ParcelCo.Parcel.Exceptions
	* ParcelCo.Parcel.Constants
	* ParcelCo.InjectionHelper

* The Interfaces, classes are documented with xml comments.

* For package types Small, Medium and Large, the overall size is calculated and stored as 'OverallSize'. The calcuation is as follow: 
  * Length + (Breath multipliedby 2) + (Height multipliedby 2). This Overall package Size is used to recommend a package type that closely matches the user supplied package dimensions. For more details look into comments section for DimensionsCheck class in ParcelCo.Parcel.ServiceImplementation.Rules
  
* The data for package types Small, Medium and Large is stored in a json file. The component retrieves this data and uses this data to recommend package types.

* Validation/Business logic for identifying best package solution is rules-based and new rules can be added by adding new classes that apply the IRule interface, rather than modifying the existing class.

* Solution caters for localised content i.e. user messages, user error messages. The default Resources file and Resurce file for en cluture has been completed. Resource files for other culture can be added as required.

# Parse the Parcel #

At Trade Me we're looking to make selling items even easier and so we've decided to build our very own package shipping network. We've dug a tunnel between the North and South Islands that enables us to offer the same rates for parcels sent anywhere in the country, and we've just finished fueling up our fleet of courier vans; all that remains to be done is to update the website so that users can be advised how much their items will cost to send.

Our new service shipping costs are based on size and we offer different prices for small, medium, and large boxes. Unfortunately we're currently unable to move heavy packages so we've placed an upper limit of 25kg per package.

| Package Type | Length | Breadth | Height | Cost |
| ------------ | ------ | ------- | ------ | ---- |
| Small | 200mm | 300mm | 150mm | $5.00 |
| Medium | 300mm | 400mm | 200mm| $7.50 |
| Large | 400mm | 600mm | 250mm | $8.50 |

## Coding Exercise ##

We need you to implement a component that, when supplied the dimensions (length x breadth x height) and weight of a package, can advise on the cost and type of package required. If the package exceeds these dimensions - or is over 25kg - then the service should not return a packaging solution.

### Guidelines ###

You will be expected to produce a solution that solves the above problem. While this is a simple component we would expect it demonstrate anything you’d normally require for a production ready and supportable solution - so think about standards, legibility, robustness, reuse etc. What we don’t require is a fancy user interface - a simple **command line** or **test harness** will suffice. 

You are free to choose how you implement the solution though your choices should ideally align with your skills and the role you are applying for. You are welcome to make assumptions about the solution along with any improvements you think enhance or add value to the solution - though please be aware of the original scope.

### Submissions ###

We will send you an invite to this git repository. Please **fork** this repository, where you can commit or upload your code. Once finished please create a **pull request** and we will review your code. We normally expect to hear back from you within five working days. 

Best of luck, and we look forwards to your response!