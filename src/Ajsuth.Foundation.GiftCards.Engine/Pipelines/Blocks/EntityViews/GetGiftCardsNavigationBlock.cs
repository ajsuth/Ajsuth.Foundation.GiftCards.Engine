// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetGiftCardsNavigationBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Ajsuth.Foundation.GiftCards.Engine.Policies;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace Ajsuth.Foundation.GiftCards.Engine.Pipelines.Blocks
{
    /// <summary>Defines the synchronous executing GetGiftCardsNavigation pipeline block</summary>
    /// <seealso cref="SyncPipelineBlock{TInput, TOutput, TContext}" />
    [PipelineDisplayName(GiftCardsConstants.Pipelines.Blocks.GetGiftCardsNavigation)]
    public class GetGiftCardsNavigationBlock : SyncPipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        /// <summary>Initializes a new instance of the <see cref="GetGiftCardsNavigationBlock" /> class.</summary>
        /// <param name="commander">The commerce commander.</param>
        public GetGiftCardsNavigationBlock()
        {
        }

        /// <summary>Executes the pipeline block's code logic.</summary>
        /// <param name="entityView">The entity view.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="PipelineArgument"/>.</returns>
        public override EntityView Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            Condition.Requires(entityView).IsNotNull($"{Name}: The argument cannot be null.");

            var dashboardName = context.GetPolicy<KnownGiftCardsViewsPolicy>().GiftCardsDashboard;
            var storesDashboardView = new EntityView()
            {
                Name = dashboardName,
                ItemId = dashboardName,
                Icon = "gift",
                DisplayRank = 6
            };
            entityView.ChildViews.Add(storesDashboardView);

            return entityView;
        }
    }
}