using Game.Enums;

public static class DeploymentUtils
{
	public static DeployableFlags ConvertTypeToFlag(TileType type)
	{
		return type switch
		{
			TileType.GrassGround => DeployableFlags.GrassGround,
            TileType.MudGround =>   DeployableFlags.MudGround,
            TileType.StoneGround => DeployableFlags.StoneGround,
            TileType.Water =>       DeployableFlags.LavaGround, 
            TileType.Lava => 		DeployableFlags.LavaGround,
			_ => 0
		};
	}
}
