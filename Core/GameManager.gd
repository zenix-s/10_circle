extends Node


var inventory: Dictionary[EnumManager.inventory, int] = {
	EnumManager.inventory.MANA: 0
}


var stats: Dictionary[EnumManager.stats, int] = {
	EnumManager.stats.MANA_REGEN: 1,
}

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	TickManager.tick.connect(_on_tick)

# Called every frame. 'delta' is the elapsed time since the previous frame.
# func _process(delta: float) -> void:
# 	pass

func _on_tick() -> void:
	inventory[EnumManager.inventory.MANA] += stats[EnumManager.stats.MANA_REGEN]
