using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Создание_сайтов_Четверть_2_Lesson_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudControllers : ControllerBase
    {
        private readonly Temperture _temp;

        List<DateTime> dateTimes = new List<DateTime>();
       
        private readonly ValuesHolder _holder;

        public CrudControllers(ValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] int Nemtemp,[FromQuery] DateTime dateTime)
        {
            dateTimes.Add(dateTime);
            _temp.Temperatura.Add(Nemtemp);
            return Ok();

        }
        [HttpPut("Update")]
        public IActionResult Update([FromQuery] int TempForSearch,[FromQuery] int NewTemp,[FromQuery] DateTime DateTimes)
        {
            for (int i = 0; i < _temp.Temperatura.Count; i++)
            {
                for (int y = 0; y < dateTimes.Count; y++)
                {


                    if (_temp.Temperatura[i] == TempForSearch ||dateTimes[y]==DateTimes)
                    {
                        _temp.Temperatura[i] = NewTemp;

                    }
                }
            }
            return Ok();
            
        }

        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime dateTime)
        {
            for (int i = 0; i < dateTimes.Count; i++)
            {
                if(dateTimes[i]==dateTime)
                {
                    return Ok(_temp.Temperatura);
                }
            }
            return Ok();
           
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] int TempeForDelete,[FromQuery] DateTime dateTime)
        {
            for (int i = 0; i < dateTimes.Count; i++)
            {
                if(dateTimes[i]==dateTime)
                {
                    _temp.Temperatura = _temp.Temperatura.Where(w => w != TempeForDelete).ToList();
                }
            }
            return Ok();
          

        }



        [HttpPost("create")]
        public IActionResult Create([FromQuery]string input)
        {
            _holder.Values.Add(input);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_holder.Values);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery]string stringToUpdate,[FromQuery] string newValue)
        {
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if(_holder.Values[i]==stringToUpdate)
                {
                    _holder.Values[i] = newValue;
                }
               
            }
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] string stringToDelete )
        {
            _holder.Values = _holder.Values.Where(w => w != stringToDelete).ToList();
            return Ok();
        }
    }
}
