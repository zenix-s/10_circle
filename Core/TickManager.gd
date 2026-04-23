extends Node

signal tick()

var _accumulator: float = 0.0
var tick_rate: float = 1.0

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	_accumulator += delta
	while _accumulator >= tick_rate:
		_accumulator -= tick_rate
		tick.emit()
