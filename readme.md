# DynamicUtils
An object model and helpers extending DynamicObject to handle dynamic properties.

## Nuget
`Install-Package DynamicUtils`

## Using extensions
Classes deriving from ```ExtensibleObject``` are all extensible to allow for using  extensions as e.g. Collection+JSON has. There are three different methods for working with extensions. 

### Setting Extensions by using the Extensions() method.
Extensions can be set by using the `Extensions` method which returns a dynamic object. Below is an example setting the Model extension*.
```csharp
var item = new Item { Href = new Uri(_requestUri, "/friends/" + friend.Id) };
item.Extensions().Model = "friend";
```
*Note: `Extensions` is a method rather than a property to avoid from being serialized, and to make it compatible with multiple serializers.

### Casting to Dynamic
Each of the aforementioned classes can be cast directly to `dynamic`.
```csharp
var item = new Item { Href = new Uri(_requestUri, "/friends/" + friend.Id) };
dynamic dItem = item;
dItem.Model="friend";
```

### Using SetValue
Extensions can be set by calling the SetValue method.
```csharp
var item = new Item { Href = new Uri(_requestUri, "/friends/" + friend.Id) };
item.SetValue("Model", "friend");
```

### Using GetValue
Extensions can be retrieved by calling the GetValue method
```csharp
var model = item.GetValue<string>("Model");
```
