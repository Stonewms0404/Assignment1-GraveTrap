extends Node

class_name ParticleManager

var ThornHit = preload("res://Obstacles/hit_thorn.tscn")
var PlayerLand = preload("res://Characters/Player/land_on_floor.tscn")

func _OnThornPlayParticle(ThornPosition : Vector2):
	var ThornParticleInstance = ThornHit.instantiate()
	add_child(ThornParticleInstance)
	ThornParticleInstance.position = ThornPosition
	ThornParticleInstance.emitting = true

func _OnPlayerPlayLandParticle(PlayerPosition : Vector2):
	var SpawnLocation = PlayerPosition
	SpawnLocation.y += 28
	var PlayerLandInstance = PlayerLand.instantiate()
	add_child(PlayerLandInstance)
	PlayerLandInstance.scale = Vector2(4,4)
	PlayerLandInstance.position = SpawnLocation
	PlayerLandInstance.emitting = true
