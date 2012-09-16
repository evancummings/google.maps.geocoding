google.maps.geocoding
=====================

A C# wrapper class for simple geocoding and reverse geocoding requests to the Google Maps Geocoder API. 

## How it works ##

The geocoder class wraps calls to the Google Maps GeoCoder API to provide a simplified way to extract geographic information
from an address or coordinate pair. Under the hood, the class will make an <tt>HttpWebRequest</tt> to the Google Maps API,
parse the response using JSON.NET, and return a C# representation of the Maps API response.

## How to use it ##

The functionality of the wrapper is exposed via the <tt>GeoCoder</tt> class. To begin using it, incorporate this into
your project, and begin by instantiating the <tt>GeoCoder</tt> class:

    GeoCoder geoCoder = new GeoCoder();
    
At this point, you can make geocoding and reverse geocoding requests to the Maps API. The result of the operation will
return a <tt>GeoCodeResponse</tt> object matching the Maps API JSON response.

### Making a geocoding request ###

To make a geocode request, call the <tt>GeoCoder.GetCoordinates()</tt> method, passing in the geographic address and a flag to
enable or disable sensor support. A <tt>GeoCodeResult</tt> object is returned.

    GeoCodeResult geoCodeResult = geoCoder.GetGeographicInfo("123 Main St, Anytown, CA", false);
    
The <tt>GeoCodeResult</tt> contains a collection of data, mapped directly to the Google Maps API JSON response. 

#### Example: Extracting Latitude and Longitude ####

To extract the latitude and longitutde coordinates, first check the status of the response to see if it was successful, then work with
the response collection as needed.

    if (geoCodeResult.status == "OK")
    {
      //Latitude
      string latitude = geoCodeResult.results[0].geometry.location.lat;

      //Longitude
      string longitude = geoCodeResult.results[0].geometry.location.lng;
    }
    
### Making a reverse geocoding request ###

To get geopraphic data based on a lat/lng coordinate pair, make a call to <tt>GeoCoder.GetGeographicInfo</tt> passing in the
latitude, longitude, and a flag to enable or disable sensors.

    GeoCodeResult geoCodeResult = geoCoder.GetGeographicInfo(39.9612, -82.9988, false);
    
#### Example: Exracting a list of matching ZIP codes based on a coordinate pair ####

To get the ZIP code(s) associated with a provided latitude and longitude, first extract the ZIP code related records
with a simple lambda expression, the loop over the <tt>address_components</tt> collection, extracting the ZIP code:

    var postalAddresses = geoCodeResult.results.Where(x => x.types[0] == "postal_code");
            
    List<string> zipCodes = new List<string>();

    foreach (var addr in postalAddresses)
    {
        zipCodes.Add(addr.address_components[0].long_name);
    }
    
## Notes ##

Licensing information coming soon

    
    
    
