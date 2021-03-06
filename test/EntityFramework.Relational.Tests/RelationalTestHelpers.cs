﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Tests;
using Microsoft.Framework.DependencyInjection;

namespace Microsoft.Data.Entity.Relational.Tests
{
    public class RelationalTestHelpers : TestHelpers
    {
        protected RelationalTestHelpers()
        {
        }

        public new static RelationalTestHelpers Instance { get; } = new RelationalTestHelpers();

        protected override EntityFrameworkServicesBuilder AddProviderServices(EntityFrameworkServicesBuilder builder) 
            => builder.AddInMemoryStore().AddRelational();

        protected override DbContextOptions UseProviderOptions(DbContextOptions options) => options;
    }
}
