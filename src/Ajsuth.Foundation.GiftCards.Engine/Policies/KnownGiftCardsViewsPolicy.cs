// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnownGiftCardsViewsPolicy.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Sitecore.Commerce.Core;

namespace Ajsuth.Foundation.GiftCards.Engine.Policies
{
    /// <summary>Defines the KnownGiftCardsViews policy.</summary>
    /// <seealso cref="Policy" />
    public class KnownGiftCardsViewsPolicy : Policy
    {
        public KnownGiftCardsViewsPolicy()
        {
            GiftCardsDashboard = nameof(GiftCardsDashboard);
            GiftCards = nameof(GiftCards);
            Summary = nameof(Summary);
            CreateGiftCard = nameof(CreateGiftCard);
            CreateGiftCard = nameof(CreateGiftCard);
            DebitGiftCard = nameof(DebitGiftCard);
        }

        public string GiftCardsDashboard { get; set; }
        public string GiftCards { get; set; }
        public string Summary { get; set; }
        public string CreateGiftCard { get; set; }
        public string CreditGiftCard { get; set; }
        public string DebitGiftCard { get; set; }
    }
}
