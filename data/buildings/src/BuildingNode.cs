using System;

using Godot;

public partial class BuildingNode : Node2D, IDemolishable
{
	[Export] private Resource _demolitionPolicy;


	private BuildingResource _resource;
	public Address Address {get; private set;}

	private bool _isActivated = false;


	[Export(PropertyHint.File, "*.tres")]
	private string _resourcePath;
	public BuildingResource Resource => _resource ??= GD.Load<BuildingResource>(_resourcePath);


	public void Setup(Address address, BuildingResource resource, Vector2 finalPos)
	{
		if (_isActivated) return;

		Address = address ?? throw new ArgumentNullException(nameof(address));
		_resource = resource ?? Resource;

		this.GlobalPosition = finalPos;
		
		_isActivated = true;
	}

	public void Demolish(Action<Address> DemolishAction)
	{
		if(_demolitionPolicy is IDemolitionPolicy policy && policy.CanDemolish())
		{
			DemolishAction?.Invoke(Address);
			policy.Execute(this);

			GD.Print($"[Board] {Address.StartCell} 위치의 건물이 성공적으로 철거되었습니다.");
		}
	}
	public bool CanDemolish()
	{
		return _demolitionPolicy is IDemolitionPolicy policy && policy.CanDemolish();
	}
}