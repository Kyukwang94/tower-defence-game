using Godot;
using System;

public interface IDisplayable
{
	string Label { get; }
    Texture2D Icon { get; }
    void DisplayOn(IGallery gallery);
    
    // "너가 선택되었으니, 이 손(hand)에 너의 의지대로 들어가라"
    void Select(PlayerHand hand);
}
