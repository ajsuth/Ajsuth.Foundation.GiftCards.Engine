// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Commerce.Plugin.BusinessUsers;
using Sitecore.Framework.Configuration;
using Sitecore.Framework.Pipelines.Definitions.Extensions;
using Sitecore.Framework.Rules;
using System.Reflection;

namespace Ajsuth.Foundation.GiftCards.Engine
{
    /// <summary>The configure sitecore class.</summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>The configure services.</summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.RegisterAllPipelineBlocks(assembly);
            services.RegisterAllCommands(assembly);

            services.Sitecore().Rules(config => config.Registry(registry => registry.RegisterAssembly(assembly)));

            services.Sitecore().Pipelines(builder => builder

                //.ConfigurePipeline<IConfigureServiceApiPipeline>(pipeline => pipeline
                //    .Add<ConfigureServiceApiBlock>()
                //)

                .ConfigurePipeline<IBizFxNavigationPipeline>(pipeline => pipeline
                    .Add<Pipelines.Blocks.GetGiftCardsNavigationBlock>().After<GetNavigationViewBlock>()
                )

                .ConfigurePipeline<IGetEntityViewPipeline>(pipeline => pipeline
                    .Add<Pipelines.Blocks.GetGiftCardsViewBlock>().After<PopulateEntityVersionBlock>()
                    .Add<Pipelines.Blocks.GetGiftCardDetailsViewBlock>().After<PopulateEntityVersionBlock>()
                )

                .ConfigurePipeline<IPopulateEntityViewActionsPipeline>(pipeline => pipeline
                    .Add<Pipelines.Blocks.PopulateGiftCardsViewActionsBlock>().After<InitializeEntityViewActionsBlock>()
                )

            );
        }
    }
}
