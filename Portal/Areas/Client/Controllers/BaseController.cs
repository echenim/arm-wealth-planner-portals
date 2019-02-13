using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Portal.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portal.Business.Contracts;
using Portal.Business.TestServices;

namespace Portal.Areas.Client.Controllers
{
    public class BaseController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        //public ArmClientServices _clientService;

        public readonly ILogger<BaseController> _logger;
        public readonly IConfiguration _configuration;

        public readonly IDistributedCache _cache;
        public readonly DistributedCacheEntryOptions _cacheEntryOptions;

        public ApplicationDbContext db;

        //test
        private readonly IArmOneServiceConfigManager _configSettingManager;
        public TestArmClientServices _clientService;

        public BaseController(IHostingEnvironment hostingEnvironment, ILogger<BaseController> logger, IConfiguration configuration, 
                              IDistributedCache cache, ApplicationDbContext _db, IArmOneServiceConfigManager configManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _webRootPath = _hostingEnvironment.WebRootPath;
            _contentRootPath = _hostingEnvironment.ContentRootPath;

            _logger = logger;
            _configuration = configuration;
            _cache = cache;

            _cacheEntryOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

            _configSettingManager = configManager;

            //_clientService = new ArmClientServices(_appSettings, _contentRootPath, _configuration);
            _clientService = new TestArmClientServices(_configSettingManager, _contentRootPath);

            db = _db;
        }
    }
}