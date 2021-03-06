﻿namespace Portal.Business.Contracts.Base
{
    public interface IDelete<T> where T : class
    {
        T Delete(T model);
    }
}