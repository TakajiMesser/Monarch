using Monarch.Engine.ECS.Components;
using System.Collections;

namespace Monarch.Engine.ECS.Archetypes
{
    public class Archetype
    {
        private readonly Type[] _types;
        private readonly Array[] _components;
        private readonly int _capacity;

        public Archetype(Type[] componentTypes, BitArray bits, int capacity)
        {
            _capacity = capacity;
            _types = componentTypes;
            _components = new Array[componentTypes.Length];

            for (var i = 0; i < componentTypes.Length; i++)
            {
                _components[i] = Array.CreateInstance(componentTypes[i], _capacity);
            }
            Bits = bits;
        }

        public BitArray Bits { get; }

        public TComponent[] GetComponents<TComponent>() where TComponent : IComponent
        {
            var index = Array.IndexOf(_types, typeof(TComponent));
            if (index < 0) throw new ArgumentException("Could not find component of type " + typeof(TComponent));

            return (TComponent[])_components[index];
        }
    }
}
