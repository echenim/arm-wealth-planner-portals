using System;
using System.Collections.Generic;
using System.Text;
using Portal.Domain.ViewModels;

namespace Portal.Business.Contracts
{
    public interface IGeneratorsManager
    {
        string UserSessionManagerForTrackingActivities();

        CartDetailView ViewCart(string email);
    }
}