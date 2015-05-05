using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JsonPatchInAspNet5.DTO;
using Microsoft.AspNet.JsonPatch;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JsonPatchInAspNet5.MvcClient.Controllers
{
    public class BottlesOfWineController : Controller
    {
        // GET: BottlesOfWine
        public async Task<ActionResult> Index()
        {
            // get
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("http://localhost:1735/api/bottlesofwine/");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<DTO.BottleOfWine>>(content));
            }

            return View(result.StatusCode);

        }


        // GET: BottlesOfWine/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("http://localhost:1735/api/bottlesofwine/" + id.ToString());


            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<DTO.BottleOfWine>(content));
            }

            return View(result.StatusCode);

        }

        // POST: BottlesOfWine/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BottleOfWine model)
        {
            try
            {
                // we're only showing 2 properties that can be edited => not a 
                // full edit, so we'll want to use JsonPatch

                // create a JsonPatch document 
                JsonPatchDocument<BottleOfWine> patchDoc = new JsonPatchDocument<BottleOfWine>();
                patchDoc.Replace(b => b.Grape, model.Grape);
                patchDoc.Replace(b => b.Year, model.Year);

                // serialize
                var serializedPatchDoc = JsonConvert.SerializeObject(patchDoc);

                // create the patch request
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, "http://localhost:1735/api/bottlesofwine/" + id)
                {
                    Content = new StringContent(serializedPatchDoc,
                    System.Text.Encoding.Unicode, "application/json")
                };


                // send it, using an HttpClient instance
                HttpClient client = new HttpClient();
                var result = await client.SendAsync(request);


                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View(result.StatusCode);

            }
            catch
            {
                return View();
            }
        }

    }
}
