extends Area2D

signal hit
# Declare member variables here. Examples:
# var a = 2
# var b = "text"

export var speed = 400

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	var velocity = Vector2.ZERO
	if (Input.is_action_pressed("move_right")):
		velocity.x += 1
	if (Input.is_action_pressed("move_left")):
		velocity.x -= 1
		
		
	position += velocity * speed * delta


func start(pos):
	position = pos
	show()
	$collisionSHape2D.disabled = false

func body_entered(_body):
	print("Hi")
	emit_signal("hit")
	_body.hide()
	_body.CollisionSHape2D.set_deferred("disabled", true)


func _on_PlayerIGuess_body_entered(body):
	print("Hi")
	emit_signal("hit")
	body.hide()
	
