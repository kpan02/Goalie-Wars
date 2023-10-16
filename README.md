# Project1

Everyone has cloned this project and created their development branch.  
We have created a Slack channel.

### Project Members

| Name  | Major | Project Role |
| ------------- | ------------- | ------------- |
| Juliet Curtin  | CMA  | Design, Testing, Documentation  |
| Luka Buskivadze  | CS  | Github, Networking, Coding  |
| Anda Liang  | CS  | Networking, Coding  |
| Kevin Pan  | CS  | Networking, Coding  |

### Resources
Full Body Tracking: https://www.youtube.com/watch?v=XsuZzkuRJls  

### Documentation
https://drive.google.com/file/d/1KTGg_xEC7w5CtDTTV4u8Lfzdq7C3pBDO/view?usp=sharing


**Design:**

1.Add a “Design” component to your readme, and briefly describe your design choices.  You do NOT need to justify your choice, just show you have thought about them.  You do not need to implement these, just start making choices.

Color Palette: Vibrant and contrasting colors to highlight players, the ball, and goals, while maintaining a nostalgic feel.
Environment: Stadium modeled after iconic MLS arena from the past.
Goalie Design: Classic goalie uniforms
Animations: Realistic goalie movements, dives, and reactions, utilizing motion capture technology for authenticity.
Player Perspective: First-person perspective
Scoring System: Traditional scoring, tab that keeps track of goals
Crowd Noise: Dynamic crowd reactions that respond to the player’s performance, enhancing the immersive experience.
Sound Effects: Realistic sounds for actions like ball kicks, goal posts hits, and player movements.
Spatial Awareness: Ensuring players have a sense of their virtual environment to navigate the goalpost effectively and make saves.


2.Begin with your “start screen”.  What is the very first thing your user sees?  Why?  What does that tell the user about your experience?  What is next?  What is the Mood?  How will you achieve that mood?

Elements and Mood:
Visual: The user is positioned as a goalie on a soccer field, facing an opposing goal that serves as the interactive start menu, set against a backdrop of energetically cheering fans.

Why This Start Screen:
Immediacy: Placing the user directly in the goalie position immediately immerses them in the core experience of the game, aligning with the game’s focus on goalkeeping duels.
Anticipation: Viewing the opposing goal and seeing the crowd sets the stage and builds anticipation, subtly communicating that they will soon be part of an exciting match-up.
Simplicity: The straightforward environment avoids overwhelming the user with too many initial options or information, making it welcoming for users of all experience levels.

What is Next in Future Design?
In the subsequent phases of design, audio elements, and interactive features will be integrated to enhance user engagement right from the home screen. The incorporation of spatial audio will immerse users in an auditory environment, where cheers from the fans, subtle field noises, and dynamic commentary come from all directions. Furthermore, the ability to physically interact with the soccer ball on the home screen will be introduced; users can pick it up and shoot it toward the goal, where the buttons are placed. Shooting the ball at a button will activate the corresponding option. Additionally, to augment the 3D visual experience, we will add more depth to the background.

What is the Mood?
The overarching mood will be excitement, anticipation, and energetic readiness. The user, when entering the virtual space, should immediately be in a wave of exhilaration and be mentally and physically ready to dive into action.

How Will You Achieve That Mood?
Achieving the desired mood will be achieved through a combination of visual cues, soundscapes, and interactive elements. The fans in the stands will not just be visual entities but will cheer, chant, and react dynamically to the user’s actions. Sound effects will be realistically designed, providing an authentic experience. Moreover, the visual and interactive elements will be crafted to be responsive and engaging; for instance, successfully hitting a button with the ball might trigger a round of applause or a celebratory cheer from the crowd.


3.How have you designed your interactions?  Are you still using the default red raycast? Why?  Is distance grab a good match? What should your hands/controllers look like?  Does that change throughout the experience? What might locomotion look like?

We have an interactable ball. Planning to do SFX interactable and inter-object interactables, i.e. cheering sounds when the ball makes contact with the net or the opposing goalie stops the ball. We are not using the default red raycast, because it feels as though that might interfere with the natural feel of the game. Not sure what is meant by “is the distance grab a good match?” For hands and controllers we are going to attempt to download character models from the asset store, but if we are unable we can create cubes for hands and a head. The user body will stay the same throughout the entire experience as they will be the player the entire time. We plan on using continuous locomotion for movement and adding field boundaries to restrict where players can go on the field. 
