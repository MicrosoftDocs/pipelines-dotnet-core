using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace pipelines_dotnet_core.Controllers
{
    public class RedisController : Controller
    {
        private const string key = "key";

        private IDistributedCache _redisCacheClient;
        public RedisController(IDistributedCache redisCacheClient)
        {
            _redisCacheClient = redisCacheClient;
        }
        public async Task<IActionResult> Index()
        {
            var db = _redisCacheClient;

            if (await db.GetAsync(key) == null)
                await db.SetStringAsync(key, DateTime.Now.ToString());

            var value = await db.GetStringAsync(key);
            return Content($"{db.GetType().FullName} - {value}");
        }

        public async Task<IActionResult> Delete()
        {
            var db = _redisCacheClient;

            if (await db.GetAsync(key) != null)
            {
                await db.RemoveAsync(key);
                return Content("Deleted");
            }
            else
            {
                return Content("Not Deleted");
            }
        }
    }
}
