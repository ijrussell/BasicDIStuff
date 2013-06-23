using Ninject;

namespace NorthwindTest.Infrastructure
{
    public class CommandService
    {
        private readonly IKernel _container;

        public CommandService(IKernel container)
        {
            _container = container;
        }

        public void ExecuteCommand(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            var handler = _container.Get(handlerType);
            try
            {
                ((dynamic)handler).Handle((dynamic)command);
            }
            finally
            {
                _container.Release(handler);
            }
        }

    }
}
