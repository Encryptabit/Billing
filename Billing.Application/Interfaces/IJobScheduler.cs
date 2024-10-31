﻿using System.Linq.Expressions;

namespace Billing.Application.Interfaces;

public interface IJobScheduler
{
    void ScheduleRecurringJob<T>(string jobId, Expression<Action<T>> methodCall, string cronExpression);
    void ScheduleDelatedJob<T>(string jobId, Expression<Action<T>> methodCall, TimeSpan delay);  
}