Cross Platform API
==================

A unity plugin that provides a unified cross-platform API for Android/iOS



#### Feature list

- save image to Album
- get/set text from clipboard
- share text
- share image & text
- show alert
- show toast
- more coming soon



#### How to use

~~~ C#
// save image to album
Album.SaveImage(imagePath);

// set clipboard text
Clipboard.SetText("this is clipboard text");

// get clipboard text
string text = Clipboard.GetText();

// share image with text(opation)
Share.ShareImage(imagePath, "this is text");

// share text
Share.ShareText("this is share text");


// show toast
UI.ShowToast("this is toast");

// show alert
UI.ShowAlert("the title", "this is alert message", "OK");

// or
AlertParams param = new AlertParams()
{
    title = "the title",
    message = "this is alert message",
    yesButton = "Yes",
    noButton = "No",
    neutralButton = "Neutral"
};
param.onButtonPress = (AlertButton button) =>
{
    print("the alert button press " + button.ToString());
};
UI.ShowAlert(param);
~~~

#### Support

- Create issues to: https://github.com/litefeel/Unity-CrossPlatformApi/issues
- Send email to me: litefeel@gmail.com


Online Document:
https://litefeel.github.io/UnityCrossPlatformApi/Documentation/DoxygenOutput/html/

GitHub:
https://github.com/litefeel/Unity-CrossPlatformApi
