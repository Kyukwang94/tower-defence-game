using Godot;
using System.Collections.Generic;
using System;


//GridSelection은 객체며 객체는 과정이며 이 과정은 자기의 다음과정을 알고있어야함
public sealed class GridSelection : IGridSelection
{
	private readonly IGridArea _area;
	
	//?? 여기도 concrete type이 아닌 Interface를 사용해야하지 않을까??..
	public GridSelection(IGridArea area)
	{
		_area = area;
	}

	//사실 Selection이지금 하는건 없음 선택된 얘들을 한번더 필터링 하는 역할을 해야하는데 .. 음 .. 
	//
	public void ApplyTo(IGridCellAction action)
	{
		_area.ApplyTo(action);
	}
}
