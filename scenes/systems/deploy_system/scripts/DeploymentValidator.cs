using Godot;
using System;

[GlobalClass]
public abstract partial class DeploymentValidator : Resource 
{
	public abstract bool CheckValidation();
}
