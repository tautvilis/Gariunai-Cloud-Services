using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gariunai_Cloud_Services.Backend
{
    public class Coordinates
    {

        class shopCoords
        {
            public double longitude;
            public double latitude;
        }

        class userCoords
        {
            public double longitude;
            public double latitude;
        }

        internal static async void GetCoordinatesAsync(string address)
        {

            var reg = new Regex("[., /]");
            address = reg.Replace(address, "+");
            Debug.WriteLine(address);

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("user-agent",
                    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                var httpResult = await httpClient.GetAsync(
                    "https://nominatim.openstreetmap.org/search?q=" + address +"&format=json&addressdetails=1");
                try
                {
                    var result = await httpResult.Content.ReadAsStringAsync();
                    var coordinates = (JArray)JsonConvert.DeserializeObject(result);
                    var latString = ((JValue)coordinates[0]["lat"]).Value as string;
                    var longString = ((JValue)coordinates[0]["lon"]).Value as string;

                    Debug.WriteLine("Coordinates are: {0} {1}", latString, longString);

                    var coords = new shopCoords {latitude = Convert.ToDouble(latString), longitude = Convert.ToDouble(longString)};

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("exception \n" + e.Message);
            }
        }


        private static void GetIpLocation()
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla / 5.0(Windows NT 10.0; WOW64) "
                                             + "AppleWebKit / 537.36(KHTML, like Gecko)" + "Chrome / 85.0.4183.83 Safari / 537.36");
            var getExternalIp = client.DownloadString("http://checkip.dyndns.org/");
            var removeChars = new Regex("[^0-9.]");
            var externalIp = removeChars.Replace(getExternalIp, "");
            
            var url = "http://api.ipstack.com/" + externalIp + "?access_key=f16f539429f878f06def52e0e36a81d9";
            var request = System.Net.WebRequest.Create(url);

            using var wrs = request.GetResponse();
            using var stream = wrs.GetResponseStream();
            using var reader = new StreamReader(stream);

            var json = reader.ReadToEnd();
            var obj = JObject.Parse(json);

            var coords = new userCoords
            {
                latitude = (double) obj["latitude"], longitude = (double) obj["longitude"]
            };

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

        public static string GetDistance(string address)
        {
            GetCoordinatesAsync(address);
            GetIpLocation();
            var shop = new shopCoords();
            var user = new userCoords();

            return Convert.ToString(GetCoordsDistance(user.longitude, user.latitude, shop.longitude, shop.latitude)) ;
        }
    }
}
