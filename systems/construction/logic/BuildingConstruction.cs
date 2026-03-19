using Godot;
using System;

public sealed class BuildingConstruction : IConstruction
{
	private readonly Address _address;
	private readonly BuildingResource _resource;
	private readonly LayerBag _layerBag;

	private readonly Building _existingBuilding;

	public BuildingConstruction(
		Address address,
		BuildingResource resource,
		LayerBag layerBag)
	{
		_address = address;
		_resource = resource;
		_layerBag = layerBag;

	}
	public BuildingConstruction(Node2D existingNode, LayerBag layerBag)
	{
		_existingBuilding = existingNode as Building ?? throw new ArgumentException($"{nameof(existingNode)}는 Building 타입이어야 합니다.");
		_layerBag = layerBag ?? throw new ArgumentNullException(nameof(layerBag));

		_resource = _existingBuilding.EditorResource ?? throw new InvalidOperationException("에디터 리소스가 비어있습니다.");

		Vector2I point = _layerBag.building.LocalToMap(_existingBuilding.Position);
		_address = new Address(point);
	}

	public Building Emit()
	{
		var instance = _existingBuilding ?? new Building(_address, _resource, _layerBag);

		if (_existingBuilding != null)
		{
			_existingBuilding.SetUp(
			_address,
			_resource,
			_layerBag
		);
		}

		return instance;
	}


}
