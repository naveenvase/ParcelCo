
# Parse the Parcel #
we're looking to make selling items even easier and so we've decided to build our very own package shipping network. We've dug a tunnel between the North and South Islands that enables us to offer the same rates for parcels sent anywhere in the country, and we've just finished fueling up our fleet of courier vans; all that remains to be done is to update the website so that users can be advised how much their items will cost to send.

Our new service shipping costs are based on size and we offer different prices for small, medium, and large boxes. Unfortunately we're currently unable to move heavy packages so we've placed an upper limit of 25kg per package.

| Package Type | Length | Breadth | Height | Cost |
| ------------ | ------ | ------- | ------ | ---- |
| Small | 200mm | 300mm | 150mm | $5.00 |
| Medium | 300mm | 400mm | 200mm| $7.50 |
| Large | 400mm | 600mm | 250mm | $8.50 |

# Parse the Parcel Developer Notes #
* This exercise is based on loosely coupled components. It utilises dependency injection, seperation of concerns, SOLID princples and strategy pattern. It relies on C#(7.1) and .net core 2.1 framework. It consists of 
  * console app - Only a stub to run the library services
  * Unit Tests - 65 test cases
  * library projects
	* ParcelCo.Parcel.ServiceContracts
	* ParcelCo.Parcel.ServiceImplementation
	* ParcelCo.Parcel.ModelContracts
	* ParcelCo.Parcel.ModelImplementation
	* ParcelCo.Json.ServiceContracts - Retrieves json data from a given file
	* ParcelCo.Json.ServiceImplementation
	* ParcelCo.Parcel.Resources - Caters for localised content. 
	* ParcelCo.Parcel.Exceptions
	* ParcelCo.Parcel.Constants
	* ParcelCo.InjectionHelper

* The Interfaces, classes are documented with xml comments.

* For package types Small, Medium and Large, the overall size is calculated and stored as 'OverallSize'. The calcuation is as follows: 
  * Length + (Breath multiplied by 2) + (Height multiplied by 2). This overall package size is used to recommend a package type that closely matches the user supplied package dimensions. For more details look into comments section for DimensionsCheck class in ParcelCo.Parcel.ServiceImplementation.Rules
  
* The data for package types Small, Medium and Large is stored in a json file. This data is used to recommend package types.

* Validation/Business logic for identifying best package solution is rules-based and new rules can be added by adding new classes that apply the IRule interface, rather than modifying the existing class.

* Solution caters for localised content i.e. user messages, user error messages. The default resource file and resurce file for 'en' clutures has been completed. Resource files for other culture can be added as required in ParcelCo.Parcel.Resources

