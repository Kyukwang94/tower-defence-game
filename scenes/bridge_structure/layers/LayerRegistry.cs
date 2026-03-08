using Game.Enums;
using Godot;
using System.Collections.Generic;

public partial class LayerRegistry : Node
{
    // 에디터에서 연결하는 레이어들
    [Export] public TileMapLayer GroundLayer;

    public ILayerProvider CreateProvider()
    {
        var dict = new Dictionary<ItemType, TileMapLayer>
        {
            { ItemType.Ground, GroundLayer },
        };

        return new WorldLayer(dict); 
    }
}