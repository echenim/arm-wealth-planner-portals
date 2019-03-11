using System;
using System.Collections.Generic;
using System.Text;
using Portal.Business.Contracts.Base;
using Portal.Domain.Models;

namespace Portal.Business.Contracts
{
    public interface IVourcherManager : ICreate<Vouchering>, IFetch<Vouchering>, IEdit<Vouchering>
    {
    }
}