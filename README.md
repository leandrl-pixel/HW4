# HW4
## Devlog
- In this project the control side of the MVC patter is handled from the BirdController class.
This script controls movement, input, game state. Examples are that in Update() 
the player flap input is detected by the Input.GetDown(KeyCode.Space) and the up movement is applied by changing 
the birds velocity through the Rigidbody2D. The BirdController also detects collions in the OnCollisionEnter2D() 
 and score triggers in the OnTriggerEnter2D(). The player does not have a direct update to the UI or play sounds
 rather raises events like OnFlap, OnDied, and OnPassedPipe to tell what happeed in the game. 

- The view side of the pattern is handled by the UI and the audio scirpts like the ScoreTextView and the audioTrack. 
These scripts only job is to display the info or feedback to the player an example of this is the ScoreTextView and it check for changes in the score 

The TMP_text  component to give the new value on screen and similarly the audiotrack plays the sound effects that go to the gameplayevents 
like flapping, scoring, or dying, but this does not control the game itself
- Events are used to keep the systems decoupled. The BirdController raises events instead of calling other systems 
- The Scoremanger class that is implemented as a singleton uses public static scoremanger instance and makes these events work thru the
OnEnable() for example listening to the zBirdControll.OnPassedPipe. When the score changes the scoremanger connects with the ScoreChanged event
- Both the UI being the ScoreTextView and audio systme being AudioTrack connect to ScoreChange meaning theyll activate then and there without the player knowing they exist
- This design make sure that the player logic for control is seperated from presentation being the view 
- The link happens through events, scoremanger singleton that keeps code orginized. 


## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites