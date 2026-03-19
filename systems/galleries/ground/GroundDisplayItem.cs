using Godot;

public sealed record GroundDisplayItem(GroundBluePrint BluePrint) : IDisplayable
{
    public Texture2D Icon => BluePrint.Resource.Icon;
    public string Label => BluePrint.Resource.Name;

    public void DisplayOn(IGallery gallery)
    {
        gallery.Show(this);
    }

	public void Select(PlayerHand hand)
	{
		hand.Grasp(BluePrint.ToHandItem());
	}
}