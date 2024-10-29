using System.Linq.Expressions;
using Billing.Application.Interfaces;
using Hangfire;

namespace Billing.Infrastructure.Polling;

public class HangfireJobScheduler: IJobScheduler
{
    public void ScheduleRecurringJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression)
    {
       RecurringJob.AddOrUpdate(jobId, methodCall, cronExpression);
    }

    public void ScheduleDelatedJob<T>(string jobId, Expression<Action<T>> methodCall, TimeSpan delay)
    {
        BackgroundJob.Schedule(jobId, methodCall, delay);
    }
}