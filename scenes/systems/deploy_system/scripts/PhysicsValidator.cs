using Godot;
using System;

[GlobalClass]
public partial class PhysicsValidator : DeploymentValidator
{
	public override bool CheckValidation()
	{
		//item이 중복으로 설치되지 않아야함.

		return true;
	}

}
