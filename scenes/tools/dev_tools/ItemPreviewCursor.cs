using Godot;
using System;

public partial class ItemPreviewCursor : Node2D
{
	public static ItemPreviewCursor Instance {get; private set;}
	
	[Export] public Sprite2D CursorSprite;
	

	private bool _isActive = true;

	public override void _EnterTree()
	{
		Instance ??= this;
	}
	public override void _Ready()
	{
		ZIndex = 100;
	}

	public override void _Process(double delta)
	{
		if (!_isActive) return;

		Vector2 mousePos = GetGlobalMousePosition();
		
		GlobalPosition = mousePos;
	}

	public void SetPreview(Resource itemData)
    {
        Texture2D previewIcon = null;

        // IResourceItem 인터페이스인지 확인하고 아이콘 추출
        if (itemData is IResourceItem resourceItem)
        {
            previewIcon = resourceItem.ItemIcon;
        }

        // 아이콘 유무에 따라 설정 혹은 리셋
        if (previewIcon != null)
        {
            SetPreviewSprite(previewIcon);
        }
        else
        {
            Reset();
        }
    }
	public void SetPreviewSprite(Texture2D texture)
	{
		Start();
		CursorSprite.Texture = texture;

		CursorSprite.Modulate = new Color(1, 1, 1, 0.9f);
		CursorSprite.Scale = new Vector2(0.5f, 0.5f);
		CursorSprite.Position = new Vector2(16, 16);
	}
	private void Start()
	{
		_isActive = true;
		Visible = true;
	}
	public void Reset()
	{
		CursorSprite.Texture = null;	
        CursorSprite.Position = Vector2.Zero;
        CursorSprite.Scale = Vector2.One;    

        _isActive = false;
        Visible = false;
	}
	


	
}
