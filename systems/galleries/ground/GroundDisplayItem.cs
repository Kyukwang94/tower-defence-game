using Godot;

public sealed record GroundExhibit(Ground Core) : IDisplayable 
{	
    public void RecallDisplayMedia(IDisplayMedia media)
    {
		Core.SetFormForDisplay(media);
    }

	public void Select(PlayerHand hand)
	{
		hand.Grasp(new GroundTool(Core));
	}
}