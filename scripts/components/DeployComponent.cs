using Godot;
using System;
using System.Collections.Generic;



public partial class DeployComponent : Node
{
	public TileMapLayer GroundLayer {get; private set;}

	private Dictionary<Type, IDeploymentStrategy> _strategies;

	public override void _Ready()
	{
		FindTargetLayer();

		_strategies = new Dictionary<Type, IDeploymentStrategy>
		{
			{typeof(TileResource), new TileDeploymentStrategy()},
			//UNIT
			//BUILDING
		};
	}

	

	public void TryDeploy(Resource item , Vector2 mouseGlobalPosition)
	{
		Type itemType = item.GetType();

		Vector2  localPos = GroundLayer.ToLocal(mouseGlobalPosition);
		Vector2I gridPos  = GroundLayer.LocalToMap(localPos);

		if (_strategies.ContainsKey(itemType))
		{
			var strategy = _strategies[itemType];

			if(strategy.IsValidPosition(this, item, gridPos))
			{
				strategy.Deploy(this, item, gridPos);
			}
			else
			{
				GD.Print("Deploy Failed");
			}
		}
	}

	private void FindTargetLayer()
	{
		var foundNode = GetTree().GetFirstNodeInGroup("MapLayers");


		if (foundNode is IMapProvider mapProvider)
		{
			GroundLayer = mapProvider.GroundLayer;
			GD.Print("Map Provider 연결 성공");
		}
		else
		{
			GD.PrintErr("MapLayers 그룹에 있는 노드가 IMapProvider를 구현하지 않았습니다");
		}
	}
}

