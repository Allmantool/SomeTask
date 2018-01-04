using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HTTPClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var httpClientHandler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential("296874243", "geneva2788", "npm.by"),
            };

            var client = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(@"https://npm.by/"),
            };

            //id_departure_station: 36
            //departure_is_waypoint: 0
            //id_arrival_station: 63
            //arrival_is_waypoint: 0
            //date: 06 - 01 - 2018

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>( "id_departure_station", "36" ),
                new KeyValuePair<string, string>( "departure_is_waypoint", "0"  ),
                new KeyValuePair<string, string> ( "id_arrival_station", "63"  ),
                new KeyValuePair<string, string> ( "arrival_is_waypoint","0" ),
                new KeyValuePair<string, string> ( "date", "06-01-2018" )
            };
            var content = new FormUrlEncodedContent(pairs);

            var response = client.PostAsync(@"https://npm.by/booking/route-time", content).Result;


            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");

            //client.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue(
            //        "Basic",
            //        Convert.ToBase64String(
            //            System.Text.ASCIIEncoding.ASCII.GetBytes(
            //                string.Format("{0}:{1}", "yourusername", "yourpwd"))));
        }
    }
}
