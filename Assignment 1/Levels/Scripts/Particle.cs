using Godot;
using System;

public partial class Particle : GpuParticles2D
{
	private void _on_finished()
	{
		QueueFree();
	}
}
