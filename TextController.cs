using UnityEngine;
//use this line whenever running a script for a unity user interface component:
using UnityEngine.UI;

using System.Collections;

public class textController : MonoBehaviour {
	
	//publicly exposing: makes a variable called text, of type text, available to all Methods inside.
	public Text text;
	
	//storing the state in an enum, a set of named constants called the enumerator list
	//This enum needs to be accessed by all states, so it should be declared at the top.
	private enum States {cell, mirror, lock_0, sheets_0, cell_mirror, sheets_1, lock_1, freedom, mirror_1, corridor_0, stairs_0, floor, closet_door, stairs_1, corridor_1, in_closet, corridor_2, stairs_2, courtyard}
	
	//States variable declared to store the current states.
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
		//make sure to Connect exposed scripts within the Inspector by dragging the element from the hierarchy
		//into the appropriate field in the Inspector.
	}
	
	// Update is called once per frame
	void Update () {
		//used to test what state the game is currently in.
		print (myState);
		
		//used to initialize the current state
		//If state tracking variable is equal to Cell entry in Enum, run State_Cell function. Otherwise, run ETC
		if (myState == States.cell) {
			state_cell();
		} else if (myState == States.lock_0) 	{
			//methods must be called with their () intact
			state_lock_0();
		} else if (myState == States.mirror) 	{
			state_mirror();
		} else if (myState == States.sheets_0) 	{
			state_sheets_0();
		} else if (myState == States.cell_mirror) {
			state_cell_mirror();
		} else if (myState == States.lock_1) 	{
			state_lock_1();
		}
	}
	
	//each state will be a VOID since it Returns nothing.
	void state_cell () {
		text.text = "You snap awake in the darkness - the darkness of sleep retreating, through eyes are still closed. " +
			"Opening them offers little difference. An audience of pale gray stone slabs greets you in the gloom. "+
				"You see a LOCKED DOOR, some DIRTY SHEETS, and a MIRROR along the wall. \n\n"+
				"Press A to examine the LOCKED DOOR.\n "+
				"Press B to examine the MIRROR.\n "+
				"Press C to examine the DIRTY SHEETS.\n";
		
		//keypresses to change the game state
		if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.lock_0;
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.sheets_0;
		}
		//left in as a back door	
		if (Input.GetKeyDown(KeyCode.X)) {
			myState = States.cell;
		}
		
	}
	
	void state_lock_0 () {
		text.text = "You can make out a hulking iron door in the gloom. It's locked and coated in corrosion.\n "+
			"This way is impassable.\n\n "+
				"Press B to examine the MIRROR.\n "+
				"Press C to examine the DIRTY SHEETS.\n"+
				"Press X to return to the Cell.\n ";
		//keypresses to change the game state
		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			myState = States.cell;
		}
	}
	
	void state_mirror () {
		text.text = "There's a small mirror hanging loosely on the wall. With a quick jiggle, you find a key behind it.\n "+
			"This can be used on the LOCKED DOOR.\n\n "+
				"Press A to examine the LOCKED DOOR.\n "+
				"Press C to examine the DIRTY SHEETS.\n"+
				"Press X to return to the CELL.\n "+
				"Press T to take the KEY, and return to the CELL";
		//keypresses to change the game state
		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.lock_0;
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			myState = States.cell;
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		}
		
	}
	
	void state_sheets_0 () {
		text.text = "You realize you've been laying in a pile of stained and crusted sheets.\n "+
			"That can't be good, but they are too worn to be of any use.\n\n "+
				//	"Press A to examine the MIRROR.\n "+
				"Press A to examine the LOCKED DOOR.\n"+
				"Press B to examine the MIRROR.\n "+
				"Press X return to the CELL";
		//keypresses to change the game state
		if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.lock_0;
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			myState = States.cell;
		}
		
	}
	
	void state_cell_mirror () {
		text.text = "The key found behind the mirror should work on the LOCKED DOOR. \n\n "+
			"Press A to examine the LOCKED DOOR.\n "+
				"Press B to examine the MIRROR\n "+
				"Press C to examine the DIRTY SHEETS\n";
		
		if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.lock_1;
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.mirror_1;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.sheets_1;
		}
	}
	
	void state_lock_1 () {
		text.text = "The KEY found behind the MIRROR has works like a charm. The lock clicks open \n "+
			"You ponder the LOCK for a moment. That moment passes.\n\n"+
				"Press X to return to the UNLOCKED CELL.\n "+
				"Press B to examine the MIRROR\n "+
				"Press C to examine the DIRTY SHEETS\n"+
				"Press E to escape to the CORRIDOR";
		
		if (Input.GetKeyDown(KeyCode.X)) {
			myState = States.cell_mirror;
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.mirror_1;
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.sheets_1;
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			myState = States.corridor_0;
		}
		
	}
	void state_sheets_1 () {
		text.text = "You look back at those terribly musty sheets. 'So long, good riddance.'\n\n"+
			"Press X to return to the UNLOCKED CELL.\n "+
				"Press B to examine the MIRROR\n "+
				"Press E to escape to the CORRIDOR.";
		if (Input.GetKeyDown(KeyCode.X)) {
			myState = States.cell_mirror;
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.mirror_1;
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			myState = States.corridor_0;
		}
	}
}