﻿using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories
{
    public interface IGetRepository
    {
        IEntity Get(int objectId);
    }
}
