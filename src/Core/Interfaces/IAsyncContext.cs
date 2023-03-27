﻿namespace Core.Interfaces;

public interface IAsyncContext<out TUnitOfWork> 
    : IContext<TUnitOfWork>
{
    CancellationToken CancellationToken { get; }
}