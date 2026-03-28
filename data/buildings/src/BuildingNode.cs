using Game.Enums;
using Godot;
using System;

public sealed record Address(Vector2I Cell);

public partial class BuildingNode : Node2D, IInitializable
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

	public BuildingNode(Address address, BuildingResource resource)
	{
		_address = address ?? throw new ArgumentNullException(nameof(address));
		_resource = resource ?? throw new ArgumentNullException(nameof(resource));
	}
	#endregion

	#region For Editor
	public void InitializeForEditor(Board board)
	{
		var construction = new BuildingConstruction(this);
		
		construction.Execute(board);
	}

	public void Finalize(Address address, BuildingResource resource, Vector2 finalPos)
	{
		if(_isActivated) return;

		_address = address ?? throw new ArgumentNullException(nameof(address));
		_resource = resource ?? throw new ArgumentNullException(nameof(resource));

		this.GlobalPosition = finalPos;
		//null일경우 미리 Editor에 존재하므로 생략.
		if(_resource.visual != null)
		{
			var visual = _resource.visual.Instantiate();
			AddChild(visual);
		}

		_isActivated = true;
	}
	#endregion
}