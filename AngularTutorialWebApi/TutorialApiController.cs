using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularTutorialWebApi
{
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class TutorialApiController: ApiController
    {
        static List<Hero> heroes = new List<Hero>()
        {
            new Hero { id= 11, name= "Mr. Nice" },
            new Hero{ id= 12, name="Narco" },
            new Hero{ id= 13, name= "Bombasto" },
            new Hero{ id= 14, name= "Celeritas" },
            new Hero{ id= 15, name= "Magneta" },
            new Hero{ id= 16, name= "RubberMan" },
            new Hero{ id= 17, name= "Dynama" },
            new Hero{ id= 18, name= "Dr IQ" },
            new Hero{ id= 19, name= "Magma" },
            new Hero{ id= 20, name= "Tornado" }
        };

        [HttpGet]
        [Route("api/Heroes")]
        public IHttpActionResult GetHeroes()
        {   
            Trace.WriteLine($"GetHeroes. Request URI: {ControllerContext.Request.RequestUri}");
            return Ok(heroes);
        }

        [HttpGet]
        [Route("api/Heroes/{id:int}")]
        public IHttpActionResult GetHero(int id)
        {
            Trace.WriteLine($"GetHero. Request URI: {ControllerContext.Request.RequestUri}");
            return Ok(heroes.FirstOrDefault(h => h.id == id));
        }
        [HttpGet]
        [Route("api/Heroes")]
        public IHttpActionResult GetHero(string name)
        {
            Trace.WriteLine($"GetHeroByName. Request URI: {ControllerContext.Request.RequestUri}");
            return Ok(heroes.Where(h=>h.name.Contains(name)));
        }

        [Route("api/Heroes/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteHero(int id)
        {
            Trace.WriteLine($"DeleteHero. Request URI: {ControllerContext.Request.RequestUri}");
            return Ok(heroes.Remove(heroes.FirstOrDefault(h => h.id == id)));
        }
        [HttpPost]
        [Route("api/Heroes")]
        public IHttpActionResult AddHero([FromBody] Hero heroToAdd)
        {
            Trace.WriteLine($"AddHero. Request URI: {ControllerContext.Request.RequestUri}");
            var hero = new Hero() { name = heroToAdd?.name, id = heroes.Max(t => t.id) + 1 };
            heroes.Add(hero);
            return Ok(hero);
        }
        [HttpPut]
        [Route("api/Heroes")]
        public IHttpActionResult UpdateHero([FromBody] Hero updatedHero)
        {
            Trace.WriteLine($"UpdateHero. Request URI: {ControllerContext.Request.RequestUri}");
            var hero = heroes.FirstOrDefault(h => h.id == updatedHero?.id);
            if (hero != null && !string.IsNullOrWhiteSpace(updatedHero?.name))
            {
                hero.name = updatedHero?.name;
            }
            return Ok(hero);
        }


    }
}
