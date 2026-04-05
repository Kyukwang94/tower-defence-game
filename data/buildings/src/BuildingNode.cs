using System;
using System.Collections.Generic;
using Game.Enums;
using Godot;

public sealed record Address(Vector2I Cell);

public partial class BuildingNode : Node2D, IDemolishable
{
	[Export] private Resource _demolitionPolicy;

	public Address CurrentAddress {get; private set;}

	private BuildingResource _resource;

	private bool _isActivated = false;



	[Export(PropertyHint.File, "*.tres")]
	private string _resourcePath;
	public BuildingResource Resource => _resource ??= GD.Load<BuildingResource>(_resourcePath);
	
	public void Setup(Address address, BuildingResource resource, Vector2 finalPos)
	{
		if (_isActivated) return;

		CurrentAddress = address ?? throw new ArgumentNullException(nameof(address));
		_resource = resource ?? Resource;

		this.GlobalPosition = finalPos;
		
		_isActivated = true;
	}

	public void Demolish(Action<Address, IEnumerable<Vector2I>> DemolishAction)
	{
		if(_demolitionPolicy is IDemolitionPolicy policy && policy.CanDemolish())
		{
			DemolishAction?.Invoke(CurrentAddress, Resource.Shape);
			QueueFree();
			GD.Print($"[Board] {CurrentAddress.Cell} 위치의 건물이 성공적으로 철거되었습니다.");
		}
	}
}