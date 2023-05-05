using Monarch.Shared.Goods;
using System;

namespace Monarch.Shared.Building
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
