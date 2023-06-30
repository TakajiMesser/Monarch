using Monarch.Engine.Maths;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpiceEngine.Core.Serialization
{
    public abstract class GameData : IGameData
    {
        public abstract bool IsValid { get; }

        public virtual void LoadData(IDataReader reader) { }

        public virtual void SaveData(IDataWriter writer)
        {
            if (!IsValid) throw new InvalidDataException("Data must be valid before saving");
        }

        public static bool IsNullOrInvalid(GameData value) => value == null || !value.IsValid;

        public static bool IsNullOrInvalid(IEnumerable<GameData> values) => values == null || values.Any(v => IsNullOrInvalid(v));

        public static bool IsNullOrInvalid(IEnumerable<string> values) => values == null || values.Any(v => string.IsNullOrEmpty(v));

        public static bool IsNullOrInvalid(IEnumerable<Vector3f> values) => values == null || values.Any(v => !v.IsReal);

        public static bool IsNullOrInvalid(IEnumerable<Matrix4> values) => values == null || values.Any(v => !v.IsReal);
    }
}