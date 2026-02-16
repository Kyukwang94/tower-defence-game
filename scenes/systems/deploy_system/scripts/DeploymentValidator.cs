using Godot;
using System;

[GlobalClass]
public abstract partial class DeploymentValidator : Resource 
{
	public abstract bool CheckValidation(Resource item , Vector2I pos);
}
