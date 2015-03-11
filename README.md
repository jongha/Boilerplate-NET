# Boilerplate-NET

## Web

웹사이트의 기본 프로젝트입니다. MVC프레임웍을 사용했으며 API 컨트롤러도 사용했습니다. Javascript, css등의 기타 외부 라이브러리는 NuGet Package Manager를 사용하여 설치했으며 기본적으로 뷰에서는 AngularJS를 사용하여 바인딩하도록 했습니다. AngularJS 를 사용한 이유는 반복되는 바인딩에 사용이 편해서 입니다.

임으로 추가한 Javascript는 CoffeeScript를 사용하여 개발했습니다. 문법이 간결해서 빠른시간에 개발이 가능하며 오류도 줄일 수 있기 때문에 사용했습니다.

Stylesheet는 less를 사용했습니다. 상속구조 및 개발시 여러 파일로 분리해서 직관적으로 사용할 수 있다는 장점이 있어서 편리합니다.


## Web.Lib

Web 프로젝트에서 참조하는 라이브러리용 프로젝트입니다. Util이나 Helper 클래서 그리고 또 다른 프로젝트와 공유할 코드가 있을경우 분리해서 사용합니다. Util과 Helper의 차이는 Util은 보통 정적 메소드가 포함되있고 Helper는 그렇지 않다는 것에 차이가 있습니다.

## Web.Tests

Unit-Test를 위한 프로젝트입니다. Web과 Web.Lib 프로젝트를 참조합니다.