using Ninject;

namespace NorthwindTest.Infrastructure
{
    public class QueryService
    {
        private readonly IKernel _container;

        public QueryService(IKernel container)
        {
            _container = container;
        }

        public TResult ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = _container.Get(handlerType);
            try
            {
                return (TResult)((dynamic)handler).Execute((dynamic)query);
            }
            finally
            {
                _container.Release(handler);
            }
        }
    }
}
