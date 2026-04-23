extends Node

var mana: float = 0.0
var mana_regen: float = 0.1
var circle: int = 1
var circle_requirement: float = 100.0

var game_speed: int = 1

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	TickManager.tick.connect(_on_tick)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

func _on_tick() -> void:
	mana += 1
