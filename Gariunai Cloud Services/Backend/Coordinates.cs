using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Device.Location;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Gariunai_Cloud_Services.Entities;
using GoogleMaps.LocationServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gariunai_Cloud_Services.Backend
{

    public class Coordinates
    {

        public class Coords
        {
            public double Longitude;
            public double Latitude;
        }


        private static Coords GetCoords(string address)
        {
            var mod = "&key=b2fed39c20974a4ca2ef3dbd25cabfe0&pretty=1&limit=1";
            var addressEncoded = HttpUtility.UrlEncode(address);
            Debug.WriteLine(address);

            using var client = new WebClient();
            var httpResult = client.DownloadString("https://api.opencagedata.com/geocode/v1/json?q=" + 
                                                       addressEncoded + mod);
            var obj = JObject.Parse(httpResult);

            var coords = new Coords()
            {
                Latitude = (double)obj.SelectToken("results[0].geometry.lat"),
                Longitude = (double)obj.SelectToken("results[0].geometry.lng")
            };

            return coords;

        }


        private static Coords GetIpLocation()
        {
            using var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla / 5.0(Windows NT 10.0; WOW64) "
                                             + "AppleWebKit / 537.36(KHTML, like Gecko)" + "Chrome / 85.0.4183.83 Safari / 537.36");
            var responseString = client.DownloadString("http://checkip.dyndns.org/");
            var removeChars = new Regex("[^0-9.]");
            var externalIp = removeChars.Replace(responseString, "");


            var url = "http://api.ipstack.com/" + externalIp + "?access_key=f16f539429f878f06def52e0e36a81d9";
            using var request = new WebClient();
            var json = request.DownloadString(url);

            var obj = JObject.Parse(json);

            var coords = new Coords()
            {
                Latitude = (double)obj["latitude"],
                Longitude = (double)obj["longitude"]
            };

            return coords;
        }

        private static double GetCoordsDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            var t = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));

            Debug.WriteLine(t);

            return t;
        }

        public static double[] GetDistance(string address)
        {
            Debug.WriteLine(address);
            if (address != null)
            {
                var shop = GetCoords(address);
                var user = GetIpLocation();
                var sCoords = new GeoCoordinate(shop.Latitude, shop.Longitude);
                var uCoords = new GeoCoordinate(user.Latitude, user.Longitude);

                var coords = new double[4];
                coords[0] = shop.Latitude;
                coords[1] = shop.Longitude;
                coords[2] = user.Latitude;
                coords[3] = user.Longitude;

                return coords;

            }
            else
            {
                return new double[0];
            }

            

        }
    }
}
