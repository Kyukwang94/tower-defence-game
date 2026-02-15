using Godot;
using System;

[GlobalClass]
public partial class DeploymentPhysicsValidator : DeploymentValidator
{
	public override bool CheckValidation()
	{
		GD.PushError("VALIDATION FAILED");
		return false;
	}
}
