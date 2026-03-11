using Godot;
using System;

public interface IButtonInfo
{
	Texture2D Icon  {get;}
	string	  Label {get;}  

	//REFACTORING :hand말고 Interface로해야함.
	void Selected(PlayerHand hand);
}
 