// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetGiftCardDetailsViewBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Ajsuth.Foundation.GiftCards.Engine.Policies;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System;

namespace Ajsuth.Foundation.GiftCards.Engine.Pipelines.Blocks
{
    /// <summary>Defines the synchronous executing GetGiftCardDetailsView pipeline block</summary>
    /// <seealso cref="SyncPipelineBlock{TInput, TOutput, TContext}" />
    [PipelineDisplayName(GiftCardsConstants.Pipelines.Blocks.GetGiftCardDetailsView)]
    public class GetGiftCardDetailsViewBlock : SyncPipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        /// <summary>Initializes a new instance of the <see cref="GetGiftCardDetailsViewBlock" /> class.</summary>
        public GetGiftCardDetailsViewBlock()
        {
        }

        /// <summary>Executes the pipeline block's code logic.</summary>
        /// <param name="entityView">The entity view.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="EntityView"/>.</returns>
        public override EntityView Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            Condition.Requires(entityView).IsNotNull($"{Name}: The argument can not be null");

            var viewsPolicy = context.GetPolicy<KnownGiftCardsViewsPolicy>();

            var request = context.CommerceContext.GetObject<EntityViewArgument>();

            if (string.IsNullOrEmpty(request?.ViewName) ||
                !request.ViewName.Equals(viewsPolicy.CreateGiftCard, StringComparison.OrdinalIgnoreCase))
            {
                return entityView;
            }

            var actionsPolicy = context.GetPolicy<KnownGiftCardsActionsPolicy>();
            if (string.IsNullOrEmpty(request?.ForAction) ||
                !request.ForAction.Equals(actionsPolicy.CreateGiftCard, StringComparison.OrdinalIgnoreCase))
            {
                return entityView;
            }

            entityView.Properties.Add(
                new ViewProperty
                {
                    Name = "Name",
                    RawValue = string.Empty
                });

            entityView.Properties.Add(
                new ViewProperty
                {
                    Name = "Currency",
                    RawValue = string.Empty
                });

            entityView.Properties.Add(
                new ViewProperty
                {
                    Name = "OriginalAmount",
                    RawValue = string.Empty
                });

            return entityView;
        }
    }
}