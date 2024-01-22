extends Node2D

@export var LevelNum : int
# Called when the node enters the scene tree for the first time.
func _ready():
	Global.SetLevelNumber(LevelNum);
