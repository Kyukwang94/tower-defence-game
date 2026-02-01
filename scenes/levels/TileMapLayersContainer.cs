using Godot;
using System;

public partial class TileMapLayersContainer : Node , IMapProvider
{
	[ExportGroup("Map Layers")]
	[Export] public TileMapLayer GroundLayer {get; private set;}


	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
