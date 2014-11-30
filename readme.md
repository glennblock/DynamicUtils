# DynamicUtils
An object model and helpers for creating hybrid dynamic objects.

## Why do I need this?
```ExpandoObject``` in .NET is sealed and not designed for derivers. You can inherit from ```DynamicObject``` but that requires a bunch of heavy lifting:

Dynamic Utils provides the following:
* A simple utility class you can derive from and which will make any object Dynamic. 
* Allows you to mix dynamic and static members
* Provides helpers for programatically accessing members without having to cast to Dynamic.
* Provides helpers for making the objects serialization friendly. 

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
