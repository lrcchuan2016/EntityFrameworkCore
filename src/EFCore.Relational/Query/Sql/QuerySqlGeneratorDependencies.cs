// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Query.Sql
{
    /// <summary>
    ///     <para>
    ///         Service dependencies parameter class for <see cref="QuerySqlGeneratorFactoryBase" />
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    ///     <para>
    ///         Do not construct instances of this class directly from either provider or application code as the
    ///         constructor signature may change as new dependencies are added. Instead, use this type in
    ///         your constructor so that an instance will be created and injected automatically by the
    ///         dependency injection container. To create an instance with some dependent services replaced,
    ///         first resolve the object from the dependency injection container, then replace selected
    ///         services using the 'With...' methods. Do not call the constructor at any point in this process.
    ///     </para>
    /// </summary>
    public sealed class QuerySqlGeneratorDependencies
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a <see cref="QuerySqlGeneratorFactoryBase" />.
        ///     </para>
        ///     <para>
        ///         Do not call this constructor directly from either provider or application code as it may change
        ///         as new dependencies are added. Instead, use this type in your constructor so that an instance
        ///         will be created and injected automatically by the dependency injection container. To create
        ///         an instance with some dependent services replaced, first resolve the object from the dependency
        ///         injection container, then replace selected services using the 'With...' methods. Do not call
        ///         the constructor at any point in this process.
        ///     </para>
        /// </summary>
        /// <param name="commandBuilderFactory"> The command builder factory. </param>
        /// <param name="sqlGenerationHelper"> The SQL generation helper. </param>
        /// <param name="parameterNameGeneratorFactory"> The parameter name generator factory. </param>
        /// <param name="relationalTypeMapper"> The relational type mapper. </param>
        /// <param name="coreTypeMapper"> The type mapper. </param>
        public QuerySqlGeneratorDependencies(
            [NotNull] IRelationalCommandBuilderFactory commandBuilderFactory,
            [NotNull] ISqlGenerationHelper sqlGenerationHelper,
            [NotNull] IParameterNameGeneratorFactory parameterNameGeneratorFactory,
            [NotNull] IRelationalTypeMapper relationalTypeMapper,
            [NotNull] IRelationalCoreTypeMapper coreTypeMapper)
        {
            Check.NotNull(commandBuilderFactory, nameof(commandBuilderFactory));
            Check.NotNull(sqlGenerationHelper, nameof(sqlGenerationHelper));
            Check.NotNull(parameterNameGeneratorFactory, nameof(parameterNameGeneratorFactory));
            Check.NotNull(relationalTypeMapper, nameof(relationalTypeMapper));
            Check.NotNull(coreTypeMapper, nameof(coreTypeMapper));

            CommandBuilderFactory = commandBuilderFactory;
            SqlGenerationHelper = sqlGenerationHelper;
            ParameterNameGeneratorFactory = parameterNameGeneratorFactory;
#pragma warning disable 618
            RelationalTypeMapper = relationalTypeMapper;
#pragma warning restore 618
            CoreTypeMapper = coreTypeMapper;
        }

        /// <summary>
        ///     Gets the command builder factory.
        /// </summary>
        public IRelationalCommandBuilderFactory CommandBuilderFactory { get; }

        /// <summary>
        ///     Gets the SQL generation helper.
        /// </summary>
        public ISqlGenerationHelper SqlGenerationHelper { get; }

        /// <summary>
        ///     Gets the parameter name generator factory.
        /// </summary>
        public IParameterNameGeneratorFactory ParameterNameGeneratorFactory { get; }

        /// <summary>
        ///     The relational type mapper.
        /// </summary>
        [Obsolete("Use CoreTypeMapper.")]
        public IRelationalTypeMapper RelationalTypeMapper { get; }

        /// <summary>
        ///     The type mapper.
        /// </summary>
        public IRelationalCoreTypeMapper CoreTypeMapper { get; }

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="commandBuilderFactory"> A replacement for the current dependency of this type. </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public QuerySqlGeneratorDependencies With([NotNull] IRelationalCommandBuilderFactory commandBuilderFactory)
            => new QuerySqlGeneratorDependencies(
                commandBuilderFactory,
                SqlGenerationHelper,
                ParameterNameGeneratorFactory,
#pragma warning disable 618
                RelationalTypeMapper,
#pragma warning restore 618
                CoreTypeMapper);

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="sqlGenerationHelper"> A replacement for the current dependency of this type. </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public QuerySqlGeneratorDependencies With([NotNull] ISqlGenerationHelper sqlGenerationHelper)
            => new QuerySqlGeneratorDependencies(
                CommandBuilderFactory,
                sqlGenerationHelper,
                ParameterNameGeneratorFactory,
#pragma warning disable 618
                RelationalTypeMapper,
#pragma warning restore 618
                CoreTypeMapper);

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="parameterNameGeneratorFactory"> A replacement for the current dependency of this type. </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public QuerySqlGeneratorDependencies With([NotNull] IParameterNameGeneratorFactory parameterNameGeneratorFactory)
            => new QuerySqlGeneratorDependencies(
                CommandBuilderFactory,
                SqlGenerationHelper,
                parameterNameGeneratorFactory,
#pragma warning disable 618
                RelationalTypeMapper,
#pragma warning restore 618
                CoreTypeMapper);

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="relationalTypeMapper"> A replacement for the current dependency of this type. </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public QuerySqlGeneratorDependencies With([NotNull] IRelationalTypeMapper relationalTypeMapper)
            => new QuerySqlGeneratorDependencies(
                CommandBuilderFactory,
                SqlGenerationHelper,
                ParameterNameGeneratorFactory,
                relationalTypeMapper,
                CoreTypeMapper);

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="coreTypeMapper"> A replacement for the current dependency of this type. </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public QuerySqlGeneratorDependencies With([NotNull] IRelationalCoreTypeMapper coreTypeMapper)
            => new QuerySqlGeneratorDependencies(
                CommandBuilderFactory,
                SqlGenerationHelper,
                ParameterNameGeneratorFactory,
#pragma warning disable 618
                RelationalTypeMapper,
#pragma warning restore 618
                coreTypeMapper);
    }
}
