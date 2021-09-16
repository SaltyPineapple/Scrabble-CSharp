using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Scrabble_Game_Logic.Game_Logic {
    public static class API {

        public static HttpClient ApiClient { get; set; } 

        public static void InitializeClient() {
            ApiClient = new HttpClient();
            
            ApiClient.DefaultRequestHeaders.Accept.Clear();

            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            






        }

        

    }
}
