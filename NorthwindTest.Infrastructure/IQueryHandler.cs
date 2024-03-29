﻿namespace NorthwindTest.Infrastructure
{
    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<in TQuery, out TResult> : IQueryHandler where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}