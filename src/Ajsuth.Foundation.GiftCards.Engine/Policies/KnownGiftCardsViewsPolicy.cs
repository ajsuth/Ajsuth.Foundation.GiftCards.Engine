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
        }

        public string GiftCardsDashboard { get; set; }
    }
}
