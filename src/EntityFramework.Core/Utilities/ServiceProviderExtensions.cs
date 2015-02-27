// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Utilities;

// ReSharper disable once CheckNamespace

namespace Microsoft.Framework.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static TService TryGetService<TService>([NotNull] this IServiceProvider serviceProvider)
            where TService : class
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            try
            {
                return serviceProvider.GetService<TService>();
            }
            catch (TargetInvocationException ex)
            {
                // TODO: See DependencyInjection Issue #127
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        public static object TryGetService([NotNull] this IServiceProvider serviceProvider, Type serviceType)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));
            Check.NotNull(serviceType, nameof(serviceType));

            try
            {
                return serviceProvider.GetService(serviceType);
            }
            catch (TargetInvocationException ex)
            {
                // TODO: See DependencyInjection Issue #127
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        public static TService GetRequiredServiceChecked<TService>([NotNull] this IServiceProvider serviceProvider)
            where TService : class
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            try
            {
                return serviceProvider.GetRequiredService<TService>();
            }
            catch (TargetInvocationException ex)
            {
                // TODO: See DependencyInjection Issue #127
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        public static object GetRequiredServiceChecked([NotNull] this IServiceProvider serviceProvider, Type serviceType)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));
            Check.NotNull(serviceType, nameof(serviceType));

            try
            {
                return serviceProvider.GetRequiredService(serviceType);
            }
            catch (TargetInvocationException ex)
            {
                // TODO: See DependencyInjection Issue #127
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }
    }
}
