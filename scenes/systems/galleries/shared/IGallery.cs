using Godot;
using System;

public interface IGallery
{
	void Show(IDisplayable displayable);
	void ClearAll();
}

