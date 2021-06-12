// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnownGiftCardsActionsPolicy.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Sitecore.Commerce.Core;

namespace Ajsuth.Foundation.GiftCards.Engine.Policies
{
    /// <summary>Defines the KnownGiftCardsActions policy.</summary>
    /// <seealso cref="Policy" />
    public class KnownGiftCardsActionsPolicy : Policy
    {
        public KnownGiftCardsActionsPolicy()
        {
            PaginateGiftCards = nameof(PaginateGiftCards);
            CreateGiftCard = nameof(CreateGiftCard);
            CreditGiftCard = nameof(CreditGiftCard);
            DebitGiftCard = nameof(DebitGiftCard);
        }

        public string PaginateGiftCards { get; set; }
        public string CreateGiftCard { get; set; }
        public string CreditGiftCard { get; set; }
        public string DebitGiftCard { get; set; }
    }
}
