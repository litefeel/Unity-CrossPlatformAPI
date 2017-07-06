Cross Platform API
==================

A unity plugin that provides a unified cross-platform API



#### Feature list

- save image to Album
- get/set text from clipboard
- share text
- share image & text
- more coming soon



#### How to use

~~~ C#
// save image to album
CrossPlatformAPI.SaveToAlbum(imagePath);

// set clipboard text
CrossPlatformAPI.SetToClipboard("this is clipboard text");

// get clipboard text
string text = CrossPlatformAPI.GetFromClipboard();

// share image with text(opation)
CrossPlatformAPI.ShareImage(imagePath, "this is text");

// share text
CrossPlatformAPI.ShareText("this is share text");
~~~

#### Support

- Create issues to: https://github.com/litefeel/UnityCrossPlatformApi/issues
- Send email to me: litefeel@gmail.com


Online Document:
https://litefeel.github.io/UnityCrossPlatformApi/Documentation/DoxygenOutput/html/
