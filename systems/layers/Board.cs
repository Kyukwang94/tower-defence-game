using System.Collections.Generic;
using System.Linq;
using Game.Enums;
using Godot;
public partial class Board : Node, IBoard
{
	// 도화지

	[Export] private TileMapLayer _groundLayer;
	[Export] private TileMapLayer _buildingLayer;
	[Export] private TileMapLayer _prevLayer;
	[Export] private TileMapLayer _interactionLayer;
	[Export] private TileMapLayer _occupancyLayer;

	private Dictionary<ItemType, TileMapLayer> _worldMap = [];
	private LayerBag _layerBag;

	public override void _Ready()
	{
		Setup();
	}

	public void Setup()
	{
		_layerBag = new LayerBag(_groundLayer, _occupancyLayer, _buildingLayer, _prevLayer);
		_worldMap = new Dictionary<ItemType, TileMapLayer>
		{
	  		{ ItemType.Ground  , _groundLayer },
	  		{ ItemType.Building, _buildingLayer},
		};

		SyncEditorBuildings();

		_occupancyLayer.Hide();

	}

	public void ActOn(IGridArea area, IGridCellAction action)
	{
		if (area.CanApply(this, action))
		{
			area.ApplyTo(this, action);
		}
		else
		{
			GD.Print("[Board] 무결성 파괴 감지. 설치 불가");
		}
	}

	public void PreviewOn(IGridArea area, IGridCellAction action)
	{
		_prevLayer.Clear();

		area.ApplyTo(this, action);
	}

	public Vector2I WorldToCell(Vector2 worldPosition)
	{
		Vector2 boardPos = _interactionLayer.ToLocal(worldPosition);
		return _interactionLayer.LocalToMap(boardPos);
	}

	public void PreviewOff()
	{
		_prevLayer.Clear();
	}


	public bool IsGroundMatch(Vector2I cell, Vector2I requiredAtlas)
	{
		return _layerBag.ground.GetCellAtlasCoords(cell) == requiredAtlas;
	}
	public bool CanOverlap(Vector2I cell, int targetSourceId, Vector2I targetCoords)
	{
		int existingSourceId = _layerBag.ground.GetCellSourceId(cell);
		Vector2I existingCoords = _layerBag.ground.GetCellAtlasCoords(cell);

		if (existingSourceId == targetSourceId && existingCoords == targetCoords)
		{
			GD.Print($"{cell}동일한 타일이 설치되어있습니다.");
			return false;
		}
		else
		{
			GD.Print($"{cell} Overlap 통과");
			return true;
		}
	}
	public bool HasFoundation(Vector2I cell)
	{
		if (_layerBag.ground.GetCellSourceId(cell) != -1)
		{
			return true;
		}
		return false;
	}
	public void MarkCellOccupancy(Vector2I cell, OccupancyType myType)
	{
		new OccupancyLedger(_occupancyLayer).MarkCell(cell, myType);
	}
	public void MarkShapeOccupancy(Vector2I pivot, IEnumerable<Vector2I> shape, OccupancyType type)
	{
		new OccupancyLedger(_occupancyLayer).MarkShape(pivot, shape, type);
	}
	public bool IsOccupancyConflict(Vector2I cell, OccupancyType conflictsWith)
	{
		int currentVal = _occupancyLayer.GetCellSourceId(cell);

		if (currentVal == -1) return false;


		return (currentVal & (int)conflictsWith) != 0;
	}
	public void SetCellAtPrev(Vector2I cell, int sourceId, Vector2I coords)
	{
		_layerBag.preview.SetCell(cell, sourceId, coords);
	}

	private void SyncEditorBuildings()
	{
		_layerBag.occupancy.Clear();

		var initializabled = GetTree().GetNodesInGroup("Initializables")
		  .OfType<IInitializable>();

		foreach (var target in initializabled)
		{
			target.InitializeForEditor(this);
		}
	}
	public void SetTile(Vector2I cell, int sourceId, Vector2I atlasCoords)
	{
		_layerBag.ground.SetCell(cell, sourceId, atlasCoords);
	}

	public BuildingNode EditorBuildingPlacement(BuildingNode node, BuildingResource resource)
	{
		Vector2I cell = _layerBag.building.LocalToMap(node.Position);

		node.Finalize(new Address(cell), resource, node.Position);

		MarkShapeOccupancy(cell, resource.Shape, resource.MyType);

		return node;
	}
	
	// 런타임에 새로운 노드를 생성함
	public BuildingNode BuildNewBuilding(BuildingResource resource, Address address)
	{
		var node = new BuildingNode(address, resource);
		_layerBag.building.AddChild(node);

		node.GlobalPosition = _layerBag.building.MapToLocal(address.Cell);
	
		Vector2 centerPos = _layerBag.building.MapToLocal(address.Cell);
		Vector2 halfTile = new(16, 16); 
		Vector2 finalPos = centerPos - halfTile;

		node.Finalize(address, resource, finalPos);

		MarkShapeOccupancy(address.Cell, resource.Shape, resource.MyType);

		return node;
	}



}
