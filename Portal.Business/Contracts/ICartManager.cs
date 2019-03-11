using System;
using System.Collections.Generic;
using System.Text;
using Portal.Business.Contracts.Base;
using Portal.Domain.Models;
using Portal.Domain.ViewModels;

namespace Portal.Business.Contracts
{
    public interface ICartManager : ICreate<Transactional>, IEdit<Transactional>, IDelete<Transactional>, IFetch<Transactional>
    {
        CartView GetCart(Func<Transactional, bool> predicate = null);

        void CartUpdateWithEmail(string email, string session);

        TransQIdenfier TrnxGenerator();
    }
}