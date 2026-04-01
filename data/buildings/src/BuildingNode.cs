using System;
using System.Collections.Generic;
using Game.Enums;
using Godot;

public sealed record Address(Vector2I Cell);

public partial class BuildingNode : Node2D, IInitializable, IDemolishable
{

	private Address _address;

	private BuildingResource _resource;

	private bool _isActivated = false;

	[Export] private BuildingResource _editorResource;
	public BuildingResource EditorResource => _editorResource;


	#region NoUse
	public BuildingNode() : base() { }
	#endregion

	#region For Runtime


	public BuildingNode(BuildingResource resource)
	{
		_resource = resource ?? throw new ArgumentNullException(nameof(resource));
	}
	#endregion


	#region For Editor
	public void InitializeForEditor(Board board)
	{
		var construction = new BuildingConstruction(this);


		construction.Execute(board);
	}

	#endregion
	public void Finalize(Address address, BuildingResource resource, Vector2 finalPos)
	{
		if (_isActivated) return;

		_address = address ?? throw new ArgumentNullException(nameof(address));
		_resource = resource ?? throw new ArgumentNullException(nameof(resource));

		this.GlobalPosition = finalPos;

		//null일경우 Editor이므로 생략.
		if (_resource.visual != null)
		{
			var visual = _resource.visual.Instantiate();
			AddChild(visual);
		}

		_isActivated = true;
	}

	public void Demolish(Board board)
	{
		board.MarkShapeOccupancy(_address.Cell, _resource.Shape, OccupancyType.None);
		board.UnregisterOccupant(_address.Cell, _resource.Shape);

		foreach (var cell in _resource.Shape)
		{
			GD.Print($"[BuildingNode] {cell}에 건물이 철거 되었습니다.");
		}

		QueueFree();
	}

	public IEnumerable<Vector2I> Shape()
	{
		return _resource.Shape;
	}
}