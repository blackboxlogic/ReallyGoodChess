Really Good Chess

Part 1
~ Implemented the "Jester" piece

~ Valid Jester Moves:
	
	+ First part of move 
		- Diagonally 2 spaces in any direction
		- Can only move if:
			=> path is clear
			=> destination space is occupied by opposite color piece
				(can capture that piece)
						-OR-
			=> If destination space is unoccupied, performs second part of move from destination space
		
	+ Second part of move
		- One space in either forward, back, left, right
		- Can only move if:
			=> new destination space is occupied by opposite color piece
				(can capture that piece)
						-OR-
			=> If new destination space is unoccupied
	
Part II

~ Implementing Unit testing of Pawn to catch the bug with promoting
