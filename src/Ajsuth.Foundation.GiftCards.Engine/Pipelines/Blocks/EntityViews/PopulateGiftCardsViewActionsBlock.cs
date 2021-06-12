// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopulateGiftCardsViewActionsBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Ajsuth.Foundation.GiftCards.Engine.Policies;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Pipelines;
using System;

namespace Ajsuth.Foundation.GiftCards.Engine.Pipelines.Blocks
{
    /// <summary>Defines the synchronous executing PopulateGiftCardsViewActions pipeline block</summary>
    /// <seealso cref="SyncPipelineBlock{TInput, TOutput, TContext}" />
    [PipelineDisplayName(GiftCardsConstants.Pipelines.Blocks.PopulateGiftCardsViewActions)]
    public class PopulateGiftCardsViewActionsBlock : SyncPipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        /// <summary>Initializes a new instance of the <see cref="PopulateGiftCardsViewActionsBlock" /> class.</summary>
        public PopulateGiftCardsViewActionsBlock()
        {
        }

        /// <summary>Executes the pipeline block's code logic.</summary>
        /// <param name="entityView">The entity view.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="EntityView"/>.</returns>
        public override EntityView Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            var viewsPolicy = context.GetPolicy<KnownGiftCardsViewsPolicy>();

            if (string.IsNullOrEmpty(entityView?.Name) ||
                !entityView.Name.Equals(viewsPolicy.GiftCards, StringComparison.OrdinalIgnoreCase))
            {
                return entityView;
            }

            var knownActionsPolicy = context.GetPolicy<KnownGiftCardsActionsPolicy>();
            var actionPolicy = entityView.GetPolicy<ActionsPolicy>();

            actionPolicy.Actions.Add(
                new EntityActionView
                {
                    Name = knownActionsPolicy.CreateGiftCard,
                    DisplayName = "Create Gift Card",
                    Description = "Creates a Gift Card",
                    IsEnabled = true,
                    EntityView = viewsPolicy.CreateGiftCard,
                    Icon = "add"
                });

            actionPolicy.Actions.Add(
                new EntityActionView
                {
                    Name = knownActionsPolicy.DebitGiftCard,
                    DisplayName = "Debit Gift Card",
                    Description = "Debits the Gift Card",
                    IsEnabled = entityView.ChildViews.Count > 0,
                    EntityView = viewsPolicy.DebitGiftCard,
                    Icon = "money"
                });

            actionPolicy.Actions.Add(
                new EntityActionView
                {
                    Name = knownActionsPolicy.CreditGiftCard,
                    DisplayName = "Credit Gift Card",
                    Description = "Credits the Gift Card",
                    IsEnabled = entityView.ChildViews.Count > 0,
                    EntityView = viewsPolicy.CreditGiftCard,
                    Icon = "money_refund"
                });

            return entityView;
        }
    }
}