﻿using System;
using System.Collections.Generic;
using System.Text;
using Portal.Domain.Models;

namespace Portal.Domain.ViewModels
{
    public class ProductAndFeaturesView
    {
        public Products Product { get; set; }
        public IEnumerable<WhatYouNeedToKNowAboutThisProduct> WhatYouNeedToKNowAboutThisProducts { get; set; }
    }
}