using Godot;


public partial class DragGuiComponent : Control
{
	[Export] public Control TargetToMove;

	private bool _isDragging = false;
	private Vector2 _dragStartOffset;

	public override void _Ready()
	{
		if (TargetToMove == null)
		{
			GD.PrintErr(" Target is Not Found");
		}

		MouseFilter = MouseFilterEnum.Stop;
	}

	public override void _GuiInput(InputEvent @event)
	{
		if(TargetToMove == null)
			return;


		if(@event is InputEventMouseButton mouseBtn)
		{
			if(mouseBtn.ButtonIndex == MouseButton.Left)
			{
				if (mouseBtn.Pressed)
				{
					_isDragging = true;

					_dragStartOffset = GetGlobalMousePosition() - TargetToMove.GlobalPosition;
				}
				else
				{
					_isDragging = false;
				}
			}
		}
		else if(@event is InputEventMouseMotion mouseMotion)
		{
			if (_isDragging)
			{
				TargetToMove.GlobalPosition = GetGlobalMousePosition() - _dragStartOffset;
			}
		}
	}

	
}
