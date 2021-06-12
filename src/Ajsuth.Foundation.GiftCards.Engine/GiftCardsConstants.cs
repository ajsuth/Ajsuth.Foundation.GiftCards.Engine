// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GiftCardsConstants.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ajsuth.Foundation.GiftCards.Engine
{
    /// <summary>The GiftCards constants.</summary>
    public class GiftCardsConstants
    {
        /// <summary>
        /// The names of the pipelines.
        /// </summary>
        public static class Pipelines
        {
            /// <summary>
            /// The names of the pipeline blocks.
            /// </summary>
            public static class Blocks
            {
                /// <summary>
                /// The get gift cards navigation block name.
                /// </summary>
                public const string GetGiftCardsNavigation = "GiftCards.Block.GetGiftCardsNavigation";

                /// <summary>
                /// The get gift cards view block name.
                /// </summary>
                public const string GetGiftCardsView = "GiftCards.Block.GetGiftCardsView";

                /// <summary>
                /// The populate gift cards view actions block name.
                /// </summary>
                public const string PopulateGiftCardsViewActions = "GiftCards.Block.PopulateGiftCardsViewActions";
                
            }
        }
    }
}