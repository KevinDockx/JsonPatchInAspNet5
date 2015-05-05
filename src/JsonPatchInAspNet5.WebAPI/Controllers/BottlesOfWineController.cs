using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonPatchInAspNet5.DTO;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.JsonPatch;
using Microsoft.AspNet.Mvc;

namespace JsonPatchInAspNet5.WebAPI.Controllers
{
    [Route("api/bottlesofwine")]
    public class BottlesOfWineController : Controller
    {




        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(Datastore.WineStore.BottlesOfWine);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // find the bottle with the correct id
            var bottles = Datastore.WineStore.BottlesOfWine;
            var correctBottle = bottles.FirstOrDefault<BottleOfWine>(b => b.Id == id);

            if (correctBottle == null)
                return HttpNotFound();

            return new ObjectResult(correctBottle);
        }



        [HttpPatch("{id}")]
        public IActionResult Patch(int id, 
            [FromBody]JsonPatchDocument<BottleOfWine> bottleOfWinePatchDocument)
        {
            // find the bottle with the correct id
            var bottles = Datastore.WineStore.BottlesOfWine;
            var correctBottle = bottles.FirstOrDefault<BottleOfWine>(b => b.Id == id);
               
            if (correctBottle == null)        
                return HttpNotFound();

            // apply patch document
            bottleOfWinePatchDocument.ApplyTo(correctBottle);

            return new ObjectResult(correctBottle);
        }
         
    }
}
