using Godot;
using System;

public interface IDisplayable
{
    void Select(PlayerHand hand);
	void RecallDisplayMedia(IDisplayMedia form);
}	
