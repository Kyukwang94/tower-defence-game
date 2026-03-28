using Godot;
using System;

public interface IConstruction
{
	BuildingNode Execute(Board board);
}
