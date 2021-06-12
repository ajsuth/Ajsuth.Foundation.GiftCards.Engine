// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCategoriesViewBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Commerce.Plugin.GiftCards;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace Ajsuth.Foundation.GiftCards.Engine.Pipelines.Blocks
{
    /// <summary>Defines the asynchronous executing GetGiftCardsView pipeline block</summary>
    /// <seealso cref="GetListViewBlock" />
    [PipelineDisplayName(GiftCardsConstants.Pipelines.Blocks.GetGiftCardsView)]
    public class GetGiftCardsViewBlock : GetListViewBlock
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="GetGiftCardsViewBlock" /> class.
        /// </summary>
        /// <param name="commander">The commander.</param>
        public GetGiftCardsViewBlock(CommerceCommander commander) : base(commander)
        {
        }

        /// <summary>
        /// Executes the block
        /// </summary>
        /// <param name="arg">The entity view</param>
        /// <param name="context">The context</param>
        /// <returns>A <see cref="EntityView"/></returns>
        public override async Task<EntityView> RunAsync(EntityView arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{Name}: The argument cannot be null.");

            var policy = context.GetPolicy<Policies.KnownGiftCardsViewsPolicy>();
            var request = context.CommerceContext.GetObjects<EntityViewArgument>().FirstOrDefault();
            if (string.IsNullOrEmpty(request?.ViewName) ||
                !request.ViewName.Equals(policy.GiftCardsDashboard, StringComparison.OrdinalIgnoreCase))
            {
                return arg;
            }

            var giftCardsView = new EntityView
            {
                EntityId = string.Empty,
                Name = policy.GiftCards
            };
            arg.ChildViews.Add(giftCardsView);

            var listName = $"{CommerceEntity.ListName<GiftCard>()}";
            await SetListMetadata(giftCardsView, listName, context.GetPolicy<Policies.KnownGiftCardsActionsPolicy>().PaginateGiftCards, context).ConfigureAwait(false);

            var giftCards = await GetEntities<GiftCard>(arg, listName, context).ConfigureAwait(false);

            foreach (var giftCard in giftCards?.OfType<GiftCard>())
            {
                var giftCardView =
                    new EntityView
                    {
                        EntityId = giftCard.Id,
                        ItemId = giftCard.Id,
                        Name = policy.Summary
                    };

                giftCardView.Properties.AddRange(
                    new[]
                    {
                        new ViewProperty
                        {
                            Name = "Name",
                            RawValue = giftCard.Name,
                            IsReadOnly = true
                        },
                        new ViewProperty
                        {
                            Name = "GiftCardCode",
                            RawValue = giftCard.GiftCardCode,
                            IsReadOnly = true
                        },
                        new ViewProperty
                        {
                            Name = "ActivationDate",
                            RawValue = giftCard.ActivationDate,
                            IsReadOnly = true,
                            UiType = "FullDateTime"
                        },
                        new ViewProperty
                        {
                            Name = "OriginalAmount",
                            RawValue = giftCard.OriginalAmount,
                            IsReadOnly = true
                        },
                        new ViewProperty
                        {
                            Name = "Balance",
                            RawValue = giftCard.Balance,
                            IsReadOnly = true
                        }
                    });

                giftCardsView.ChildViews.Add(giftCardView);
            }

            return arg;
        }
    }
}
