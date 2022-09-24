﻿# CodeHelper.API.Pinterest
CodeHelper.API.Pinterest is a lightweight and easy to use .NET Pinterest Wrapper letting you to manage your baords and pins (including create, update and delete
		

## Info + Question?
* [Twitter](https://twitter.com/@frederik_vl/)
* [LinkedIN](https://www.linkedin.com/company/codehelper-dotnet/)
* [Pinterest API](https://developers.pinterest.com/docs/api/v5/)
* [NuGet](https://www.nuget.org/packages/CodeHelper.API.Pinterest)
* [OAuth Access Token](https://frederik.today/codehelper/tools/oauth-app-access-tokens)

## Support
You can support the work if you want:
* [Buy Me A Coffee](https://www.buymeacoffee.com/codehelper.net)
* [Revolut](https://revolut.me/frederwa9)


## Version
* 1.0.3 : Boards (Get List, Create, Update, Delete,...), Pins (Create, Delete, Save,...)


## Use of Code	
 ```csharp
using CodeHelper.API.Pinterst;

PinterstHelper _helper = new() {AccessToken = "{accesstoken}" };
var _newboard = await _helper.BoardCreate("Code Helper", "The latest pin related to code helper packages");

await _helper.CreatePin("https://webstories.today/watch/the-beginnings-of-sergey-brin/webplayer"
            , "Sergey Brin's Beginnings In 1 Minute"
            , "1038220589036341017", "How did entrepreneur Sergey Brin, co-founder of Google started his success?", "images/jpeg", "https://webstories.today/images/s/the-beginnings-of-sergey-brin-cover.jpg");
```


## Authentication
Pinterest API uses OAuth2.0. Before you can request an Access Token for you Pinterest app, you need to [register your app](https://developers.pinterest.com/docs/getting-started/set-up-app/) and get your app ID and app secret key.
If you want an access code for your registered app, you can use this [online tool](https://frederik.today/codehelper/tools/oauth-access-token-pinterest)