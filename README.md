# NumberSystem
A number system to convert between strings and integers.

## How to use
Create an instance of NumberConverter and apply to the constructor the possible characters.

~~~csharp
var converter = new NumberConverter("0123456789ABCDEF");
~~~

Now you can convert between strings and numbers:

~~~charp
var result = converter.ToString(255); // returns "FF"
~~~

~~~charp
var result = ns.ToNumber("FF"); // returns 255
~~~

You can define some other number systems as well.

## For what?
You can use the number converter to create unique strings for numbers e.g. a shortenizer for a webpage.
