﻿using Monarch.Engine.ECS.Game;

namespace Monarch.Engine.ECS.Systems
{
    public interface IGameSystem
    {
        void SetSystemProvider(ISystemProvider systemProvider);
        void Load();
        void Start();
        void Update(double deltaTime);
    }
}
