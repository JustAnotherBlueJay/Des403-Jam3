using Godot;
using System;

public partial class DogHearts : Control
{
    private GpuParticles2D particles;
    public override void _Ready()
    {
        particles = GetChild<GpuParticles2D>(0);
        MouseEntered += OnMouseEnter;
        MouseExited += OnMouseExit;
    }

    private void OnMouseEnter() {
        particles.Emitting = true;
    }

    private void OnMouseExit()
    {
        particles.Emitting = false;
    }
}
