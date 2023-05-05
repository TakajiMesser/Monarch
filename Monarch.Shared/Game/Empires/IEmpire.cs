using System.Collections.Generic;

namespace Monarch.Shared.Game.Empires
{
    public interface IEmpire
    {
        IReadOnlyList<IProvince> Provinces { get; }

        void ExtractResources();
    }
}
