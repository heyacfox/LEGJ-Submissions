extends Node

export(PackedScene) var eggScene

var score = 0
var timeleft = 60
# Declare member variables here. Examples:
# var a = 2
# var b = "text"

#var screen_size # Size of the game window.

func _ready():
	#screen_size = get_viewport_rect().size
	#hide()
	pass



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_EggSpawnTimer_timeout():
	if (timeleft > 0):
		spawnEgg()
	
	


func _on_PlayerIGuess_body_entered(body):
	
	score = score + 1
	print("Score is:" + str(score))
	if (timeleft > 0):
		spawnEgg()
		
	$HUD.update_score(score)
	
	
func spawnEgg():
	var offset = rand_range(0, 1000)
	var spawnLocation = Vector2(offset, 0)
	var nodeInstance = eggScene.instance()
	add_child(nodeInstance)
	nodeInstance.position = spawnLocation
	var direction = nodeInstance.rotation
	direction += rand_range(-PI / 2, PI / 2)


func _on_Seconds_timeout():
	if (timeleft > 0):
		timeleft = timeleft - 1
		$HUD/TimeLabel.text = str(timeleft)
	if (timeleft <= 0):
		print("The End")
		
