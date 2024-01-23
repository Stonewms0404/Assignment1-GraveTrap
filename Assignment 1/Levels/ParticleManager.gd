extends Node

class_name ParticleManager

var ThornHit = preload("res://Obstacles/hit_thorn.tscn")

func _OnThornPlayParticle(ThornPosition : Vector2):
	var ThornParticleInstance = ThornHit.instantiate()
	add_child(ThornParticleInstance)
	ThornParticleInstance.position = ThornPosition
	ThornParticleInstance.emitting = true
