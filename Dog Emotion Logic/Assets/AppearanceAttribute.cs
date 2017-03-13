using UnityEngine;
using System.Collections;

public class AppearanceAttribute : Attribute {
	private string bodyPart;
	private int appearanceNum;

	private string[] bodyApp = {"Forward body position", "Body Orientation leaning towards/into", "Body orientation of forward and backwards",
		"Rounded, lowered posture", "Braced or rounded posture/ leaning away"};

	private string[] generalMuscleApp = {"Lack of tension", "Relaxed Muscles", "Face/Body Tention"};

	private string[] lipsApp = {"Lips loose", "Tightened Lip Commissures", "Lips Pulled"};

	private string[] eyesApp = {"Eyes blinking and soft"," Orientation of eyes and nose", "Dilated Pupils, Whale Eyes",
		"Dilated pupils, looking away, squinting or whale eyes"};

	private string[] headApp = {"Head tilt", "Lowered Head", "Hiding(face)"};

	private string[] earsApp = {"Ears hanging relaxed", "Ears alert", "Erect ears, without tention",
		"Ears Flattened", "Ears Down/ Back", "Ears back", "Ears Variable"};

	private string[] tailApp = {"Lowered Tail", "Tail tucked"};

	private string[] legsApp = {"Brace front leg"};

	private string[] backApp = {"Rounded Back"};

	private string[] tongueApp = {"Tongue flick\n", "Lip Licking/ Tongue Flick",
		"Lip Licking, 'Spatual' tongue", "Hyper-Salivation"};

	private string[] pawApp = {"Sweaty paw prints/ lifted paw", "Paw lift"};

	public AppearanceAttribute(string bodyPart, int appearanceNum) {
		this.bodyPart = bodyPart;
		this.appearanceNum = appearanceNum;
	}

	public string attributeType() {
		return "Appearance";
	}

	public string physicalPart() {
		return bodyPart;
	}

	public string attributeCode() {
		return bodyPart + appearanceNum;
	}

	public string attributeDescription() {
		switch (bodyPart) {
		// Check for null during code review lol
		case "Body":
			return bodyApp[appearanceNum];
		case "GeneralMuscle":
			return generalMuscleApp[appearanceNum];
		case "Lips":
			return lipsApp[appearanceNum];
		case "Eyes":
			return eyesApp[appearanceNum];
		case "Head":
			return headApp[appearanceNum];
		case "Ears":
			return earsApp[appearanceNum];
		case "Tail":
			return tailApp[appearanceNum];
		case "Legs":
			return legsApp[appearanceNum];
		case "Back":
			return backApp[appearanceNum];
		case "Tongue":
			return tongueApp[appearanceNum];
		case "Paw":
			return pawApp[appearanceNum];
		}

		return "None, Error";
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
