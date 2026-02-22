using Godot;
using System;
using System.Collections.Generic;
using Game.Enums;

[GlobalClass]
public partial class GameDataManager : Resource
{
	[Export] public GroundDatabase GroundDataBase {get; set;}
	
	private readonly Dictionary<ItemType,Resource[]> _allGameDataResources = [];


	public Resource[] GetItemDataList(ItemType itemType)
	{
		if(_allGameDataResources.Count == 0)
		{
			InitializeDitionary();
			GD.Print("성공적으로 GameDataBase Update됨");
		}

		if(_allGameDataResources.TryGetValue(itemType,out var result))
		{
			return result;
		}

		GD.PushError($"매치하는 아이템타입이 없습니다: {itemType}");
		return System.Array.Empty<Resource>();
	}

	public void InitializeDitionary()
	{
		_allGameDataResources[ItemType.Ground] = GroundDataBase.GetItems();
	}
}
