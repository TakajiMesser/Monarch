using Monarch.Shared.Goods;
using System;

namespace Monarch.Shared.Building
{
    /// <summary>
    /// A recipe is a one-time purchase.
    /// </summary>
    public class Recipe : ICrafter<Structure>
    {
        public ResourceSet Cost { get; }
        public Structure Production { get; }
    }
}
