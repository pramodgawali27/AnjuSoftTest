using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using UserAPP.Models;

namespace UserAPP.Mapper
{
   public interface IUserMapper
    {
        UserViewModel GetUserDataToViewModel();
        string UpdateUserDataToViewModel(UserViewModel model);
    }

    public class UserMapper:IUserMapper
    {
        public UserViewModel GetUserDataToViewModel()
        {
            var model = new UserViewModel();
            try
            {
                using (var client = new HttpClient())
                {
                    string baseEndpoint = ConfigurationManager.AppSettings["UserAPIBaseEndpoint"]; 

                    client.BaseAddress = new Uri(baseEndpoint);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = baseEndpoint + "getuserdata";

                    HttpResponseMessage response = client.GetAsync(requestUri).Result;
                    var userResponse = response.Content.ReadAsStringAsync().Result;

                    model = JsonConvert.DeserializeObject<UserViewModel>(userResponse);
                    
                    return model;
                }
            }
            catch (Exception e)
            {
               
            }
            return model;
        }

        public string UpdateUserDataToViewModel(UserViewModel model)
        {
            string updatedFirstName = !string.IsNullOrWhiteSpace(model.FirstName) ? ReverseString(model.FirstName) : string.Empty;
            string updatedLastName = !string.IsNullOrWhiteSpace(model.LastName) ? ReverseString(model.LastName) : string.Empty;
            return updatedFirstName + " " + updatedLastName;
        }
       

        private static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}