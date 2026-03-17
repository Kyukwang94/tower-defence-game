using Godot;

public sealed record GroundPlayerHand(GroundBluePrint BluePrint) : IHandItem
{
    public ICursorDesign CursorDesign() => new PlayerHandDesign(BluePrint.Resource.Icon);
    
    public void Selected(PlayerHand hand)
    {
        GD.Print($"[Ground] 선택됨: {BluePrint.Resource.Name}");
        hand.Grasp(this);
    }

    // 설치 로직으로 연결
    public IPlaceable ToGrid() => new GroundPlacement(BluePrint);

	public IPlaceable ToPlaceable()
	{
		throw new System.NotImplementedException();
	}

}
