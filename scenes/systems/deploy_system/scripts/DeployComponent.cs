using Godot;
using System;
using System.Collections.Generic;



public partial class DeployComponent : Node
{
	[Export] public GroundDeploymentStrategy GroundStrategy {get; set;}

	private Dictionary<Type, IDeploymentStrategy> _strategies;

	public override void _Ready()
	{
		_strategies = [];

		if(GroundStrategy != null)
		{
			_strategies.Add(typeof(GroundResource), GroundStrategy);
		}
		
	}

	public void TryDeploy(Resource item , Vector2 mouseGlobalPosition)
	{
		Type itemType = item.GetType();

		if(_strategies == null)
		{
			GD.PushError("Strategies dictionary is null !");
			return;
		}

		if (_strategies.ContainsKey(itemType))
		{
			var strategy = _strategies[itemType];

			if(strategy.CheckValidation(item , mouseGlobalPosition))
			{
				strategy.Deploy(item, mouseGlobalPosition);
			}
			else
			{
				GD.Print("Deploy Validation Failed");
			}
		}
	}
}

