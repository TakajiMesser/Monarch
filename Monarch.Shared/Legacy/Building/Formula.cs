using Monarch.Shared.Legacy.Goods;
using System;

namespace Monarch.Shared.Legacy.Building
{
    /// <summary>
    /// A formula is an ongoing production.
    /// </summary>
    public class Formula : ICrafter<Resource>
    {
        public ResourceSet Cost { get; }
        public Resource Production { get; }
    }
}
