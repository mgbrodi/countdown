﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Countdown.Pages
{
    public class IndexModel : PageModel
    {
        string TextResult = "";
        public void OnGet()
        {
            ViewData["TextResult"] = "";
            Random rnd = new Random();
            var url = new Uri("http://countdown-service.apps.internal:8080/api/countdown/"+rnd.Next(1,2000).ToString());
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    //The HttpResponseMessage which contains status code, and data from response.
                    using (HttpResponseMessage res = client.GetAsync(url).Result)
                    {
                        ViewData["TextResult"] = res.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }

        }
    }
}
