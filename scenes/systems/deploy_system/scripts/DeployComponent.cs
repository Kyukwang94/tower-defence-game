using Godot;
using System;
using System.Collections.Generic;



public partial class DeployComponent : Node
{
	[Export] public GroundDeploymentStrategy GroundStrategy {get; set;}

	private Dictionary<Type, IDeploymentStrategy> _strategies;

	public override void _Ready()
	{
		_strategies = new Dictionary<Type, IDeploymentStrategy>();

		if(GroundStrategy != null)
		{
			_strategies.Add(typeof(GroundResource), GroundStrategy);
		}
		
	}


	public void TryDeploy(Resource item , Vector2 mouseGlobalPosition)
	{
		//MEMO : validator에게 item , cellPos를 넘겨줘야함.
		Type itemType = item.GetType();

		if (_strategies.ContainsKey(itemType))
		{
			var strategy = _strategies[itemType];

			if(strategy.CheckValidation())
			{
				strategy.Deploy(item, mouseGlobalPosition);
			}
			else
			{
				GD.Print("Deploy Failed");
			}
		}
	}
}

