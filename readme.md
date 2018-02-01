# Hotwire Car Stalker

This is a utility to track the pricing of a vehicle type on Hotwire and notify if/when it meets your specified price.  Notification is in the form of an email to your given address with a link to the vehicle listing that matches your search.

All data comes from the Hotwire API which you can find more about at <http://developer.hotwire.com/>.

![Screenshot](screenshot.png?raw=true "Screenshot of the app in action")

## Prerequisites

1. .NET Core 2.0+
1. Hotwire API Developer Key - <http://developer.hotwire.com/>.

## Usage

1. Copy the `appsettings.sample.json` and rename it `appsettings.json`.
1. Enter your Hotwire API Key in the `HotwireApi.Key` of your `appsettings.json`.
1. Configure your search criteria in your `appsettings.json`.

    1. VehicleType & VehicleTypeName can be found in the `sample-response.json` file at the top.
    1. Fill out the remainder of the search criteria as you like to find you a rental car.

1. Enter the SMTP Server details, as well as the Alert To, From, and Subject so that you know when your price has been met.

1. `dotnet run` the application and you should see the results.

By default it is set to only poll Hotwire every 10 mins.  Results show in red when there is no match, green when there is a match.  The application will also send out an email when there is a match if you've configured your SMTP correctly.

