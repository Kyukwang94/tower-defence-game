using Godot;
using System;

public partial class Building : Node2D
{
	public void InitPosition(Vector2 position)
	{
		this.Position = position;
		GD.Print($"[Building] 내 위치를 {position}으로 확정했습니다.");
	}
}
