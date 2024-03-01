using Godot;
using System;

public partial class Attack : Node
{
	[Export]
    HealthComponent Health { get; set; } = null;

    public override void _Ready()
    {
        Health.Damage(20);
    }
}
