using Monarch.Shared.Legacy.Goods;
using System;

namespace Monarch.Shared.Legacy.Building
{
    public interface ICrafter
    {
        ResourceSet Cost { get; }
    }

    public interface ICrafter<T> : ICrafter where T : ICraftable
    {
        T Production { get; }
    }
}
