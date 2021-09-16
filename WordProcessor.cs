using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Game_Logic {
    class WordProcessor {

        /*public async Task LoadWord(String word = "") {
            string url = "";

            if (!word.Equals("")) {
                url = $"https://wordsapiv1.p.rapidapi.com/words/{ word }";
            }
            else {

            }

            

            using (HttpResponseMessage response = await API.ApiClient.GetAsync(url)) {
                if (response.IsSuccessStatusCode) {

                }

            }


        }*/

        public bool isWordAsync(string word) {
            var client = new RestClient($"https://wordsapiv1.p.rapidapi.com/words/{ word }");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "de4ddcec3fmsh8fdbc2eee30df00p13e9a3jsn6ac2c2d3a074");
            request.AddHeader("x-rapidapi-host", "wordsapiv1.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            var statusCode = response.StatusCode;

            return statusCode == System.Net.HttpStatusCode.OK;
            
            
            
        }


    }
}
