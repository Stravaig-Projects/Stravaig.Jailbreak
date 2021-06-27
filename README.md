# Stravaig.Jailbreak

A library that assists with those difficult to test classes, and especially legacy classes that were not designed to be tested in the first place.

## Usage

To jailbreak object instances:

```csharp
// Jailbreak the object:
dynamic cracked = obj.Jailbreak();

// Call the private method/field/property
cracked.CallAPrivateMethod();
var fieldValue = cracked._somePrivateField;
var propertyValue = cracked.SomePropertyValue;
```

To jailbreak a static type or static members on a type:

```csharp
// Jailbreak the type:
dynamic cracked = typeof(StaticType).Jailbreak();

// Call the private static method/field/property
cracked.CallAPrivateMethod();
var fieldValue = cracked._somePrivateField;
var propertyValue = cracked.SomePropertyValue;
```

### dynamic

By the nature of dynamic objects, the results back from methods/fields/properties will also be dynamic and you may prefer to cast them to their original type:

```csharp
// Jailbreak the object:
dynamic cracked = obj.Jailbreak();

// Call the private method that returns a string.
var dynamicResult = cracked.CallAPrivateMethod();
var staticResult = (string)dynamicResult;
```