using Godot;
using System;
using Game.Enums;
public partial class BrushBox : Node , IToolBox
{
	public ToolType TypeId => ToolType.Paint;
	
	public void Activate()  { GD.Print("PaintBox is Ready"); }

	public void Deactivate(){ ItemPreviewCursor.Instance.Reset();}
	
	public IGridCellAction MakeAction(IPlaceable item, ILayerProvider mapProvider)
	{
		return new Brush(mapProvider, item);
	}

}
