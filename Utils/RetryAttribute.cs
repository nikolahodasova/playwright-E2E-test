using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

public class RetryOnFailureAttribute : NUnitAttribute, IWrapTestMethod
{
    private readonly int _retryCount;

    public RetryOnFailureAttribute(int retryCount = 2)
    {
        _retryCount = retryCount;
    }

    public TestCommand Wrap(TestCommand command)
    {
        return new RetryCommand(command, _retryCount);
    }
}

public class RetryCommand : DelegatingTestCommand
{
    private readonly int _retryCount;

    public RetryCommand(TestCommand innerCommand, int retryCount)
        : base(innerCommand)
    {
        _retryCount = retryCount;
    }

    public override TestResult Execute(TestExecutionContext context)
    {
        int count = _retryCount;

        while (count-- > 0)
        {
            context.CurrentResult = innerCommand.Execute(context);

            if (context.CurrentResult.ResultState.Status == TestStatus.Passed)
            {
                break;
            }
        }

        return context.CurrentResult;
    }
}