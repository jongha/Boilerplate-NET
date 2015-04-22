# Boilerplate-NET

## Web

This is boilerplate project for .NET using C#. This project requires MVC framework and API controller library. JavaScript and other external libraries such as CSS has installed using the NuGet Package Manager. All pages use a AngularJS JavaScript library. AngularJS is a convenient way to show and bind to elements using data format such as JSON. I also use JavaScript to make CoffeeScript. It can help reduce development time, concise grammar and reduce the grammar error in your code. Stylesheet used the less. Separated by inheritance structure and developing multiple files to the advantage that it can be used conveniently and intuitively.

## Web.Lib

The project for the library that is referenced in the Web project. Util and Helper classes keep responsibility principle (SRP). The Single Responsibility Principle is a class should have only one reason to change. Util class can contain static method and Helper class can not.

## Web.Tests

The project for Unit-Test. It refers to the Web and Web.Lib project.

## License

boilerplate-net is available under the terms of the [MIT License](https://github.com/jongha/boilerplate-net/blob/master/LICENSE).
