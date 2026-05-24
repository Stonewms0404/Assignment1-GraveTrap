using Godot;

public partial class Global : Node
{
    public static Global Instance { get; private set; }

    public int LevelNum = 0;

    public override void _Ready()
    {
        Instance = this;
    }
}
