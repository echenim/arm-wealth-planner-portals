﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Areas.Client.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Portal.Services;
using Portal.Domain;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Portal.Areas.Client.Controllers
{
    public class BaseController : Controller
    {
        public string _webRootPath;
        public string _contentRootPath;
        public readonly IHostingEnvironment _hostingEnvironment;
        public readonly AppSettings _appSettings;
        public JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        public ArmClientServices _clientService;

        public readonly ILogger<BaseController> _logger;
        public readonly IConfiguration _configuration;

        public readonly IDistributedCache _cache;
        public readonly DistributedCacheEntryOptions _cacheEntryOptions;

        public ApplicationDbContext db;

        public BaseController(IOptions<AppSettings> appSettings, IHostingEnvironment hostingEnvironment, 
                              ILogger<BaseController> logger, IConfiguration configuration, 
                              IDistributedCache cache, ApplicationDbContext _db)
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

            _appSettings = appSettings.Value;
            _clientService = new ArmClientServices(_appSettings, _contentRootPath, _configuration);
            db = _db;
        }
    }
}