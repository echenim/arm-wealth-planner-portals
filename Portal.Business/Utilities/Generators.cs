//using System;
//using System.Collections.Generic;
//using System.Text;
//using Portal.Business.Contracts;
//using Portal.Domain.Models;

//namespace Portal.Business.Utilities
//{
//    public class Generators
//    {
//        private readonly ICartManager _cartManager;

//        public Generators(ICartManager cartManager)
//            => _cartManager = cartManager;

//        /// <summary>
//        /// method to generator uniques transaction number
//        /// that be used as tracking no for session and Transaction Number in Transactional table
//        /// this will ensure uniques transaction and cart id is alway genenrated
//        /// trhe unique number generated is stored in the TransQIdenfier table for tracking record purpose only
//        /// </summary>
//        /// <returns>string of uniques id</returns>
//        public string GetTrnxNo()
//        => _cartManager.TrnxGenerator().Id.ToString();
//    }
//}