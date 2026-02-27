using Godot;
using System;
using Godot.Collections;

//
public partial class DeployComponent : Node
{
	[Export] public Array<Resource> Strategies {get; set;}

	private System.Collections.Generic.Dictionary<Type, IDeploymentStrategy> _strategies;

	public override void _Ready()
	{
		_strategies = [];
		
		if (Strategies == null) return;

		foreach (var strategyRes in Strategies)
		{
			if (strategyRes is IDeploymentStrategy strategy)
			{
				_strategies[strategy.TargetStrategyType] = strategy;
			}
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
				GD.Print("Deployed");
			}
			else
			{
				GD.Print("Deploy Validation Failed");
			}
		}
	}
}
