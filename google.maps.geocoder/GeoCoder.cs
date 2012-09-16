using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace google.maps.geocoder
{
    class GeoCoder
    {
        public GeoCodeResult GetCoordinates(String address, bool usesSensor)
        {
            String strUrl = String.Empty;

            strUrl = "http://maps.googleapis.com/maps/api/geocode/json?address=" + address;
            strUrl += usesSensor ? "&sensor=true" : "&sensor=false";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);

            request.ServicePoint.Expect100Continue = false;

            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();

            string strResponse = String.Empty;

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                strResponse = sr.ReadToEnd();

                return JsonConvert.DeserializeObject<GeoCodeResult>(strResponse);
            }


            return null;

        }

        public GeoCodeResult GetGeographicInfo(double latitude, double longitude, bool usesSensor)
        {
            String strUrl = String.Empty;

            strUrl = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitude + "," + longitude;
            strUrl += usesSensor ? "&sensor=true" : "&sensor=false";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);

            request.ServicePoint.Expect100Continue = false;

            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();

            string strResponse = String.Empty;

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                strResponse = sr.ReadToEnd();

                return JsonConvert.DeserializeObject<GeoCodeResult>(strResponse);
            }


            return null;
        }
        
    }
}
