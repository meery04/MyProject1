using Microsoft.AspNetCore.Mvc;

namespace praktika_2.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        public List<string> Get()
        {
            return Summaries;
        }
        /*public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }*/


        [HttpPost]
        public IActionResult Add(string name)
        {
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (string.Equals(name, Summaries[i])) { break; }
                else if (i + 1 == Summaries.Count && !string.Equals(name, Summaries[i]))
                {
                    Summaries.Add(name);
                }
            }
            return Ok();
        }



        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0)
            {
                return BadRequest("Индекс не может быть отрицательным");
            }

            if (index >= Summaries.Count)
            {
                return BadRequest("Индекса не существует");
            }
            else
            {
                for (int i = 0; i < Summaries.Count; i++)
                {
                    if (string.Equals(name, Summaries[i])) { break; }
                    else if (i + 1 == Summaries.Count && !string.Equals(name, Summaries[i]))
                    {
                        Summaries[index] = name;
                    }
                }
                return Ok();
            }

        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0)
            {
                return BadRequest("Индекс не может быть отрицательным!");
            }

            if (index >= Summaries.Count)
            {
                return BadRequest("Индекс не существует!");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public string GetByIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "Введенный текст некорректный!";
            }
            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int GetByName(string name)
        {
            int w = 0;
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i] == name)
                    w++;
            }
            return w;
        }

        [HttpGet("GetAll")]
        public List<string> GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
                return Summaries;

            if (sortStrategy == 1)
            {
                Summaries.Sort();
                return Summaries;
            }

            if (sortStrategy == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Summaries;
            }
            return Summaries;
        }
    }
}
