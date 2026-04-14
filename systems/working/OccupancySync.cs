using Godot;
using System.Linq;
public sealed class OccupancySync
{
	private readonly BoardEnvironment _boardEnv;
	private readonly ILayerProvider _layerProvider;

	public OccupancySync(BoardEnvironment boardEnv, ILayerProvider layerProvider)
	{
		_boardEnv = boardEnv;
		_layerProvider = layerProvider;
	}

	public void Sync()
	{
		_boardEnv.ClearOccupancy();

		var prePlacedBuildings = _layerProvider.Building.GetChildren().OfType<BuildingNode>();

		foreach (var building in prePlacedBuildings)
		{
			// 좌표 계산 로직 캡슐화
			Vector2I cell = GridUtils.WorldToCell(building.GlobalPosition);

			// 이미 만들어둔 전문가(Installer)를 재사용하거나 Action을 다시 던집니다.
			_boardEnv.InstallBuilding(building, cell);
		}
	}
}