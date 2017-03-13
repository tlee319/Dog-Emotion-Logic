using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EmotionLogic : MonoBehaviour {

	public Text resultText; 
	public static List<string> listOfPossibleEmotions = new List<string>();
	public static Dictionary<string, int> emotionFreq = new Dictionary<string, int> ();

	private int prevNum;

	public static class EmotionLogicEngine {
		public static string currentEmotion = "";

		public static Dictionary<string, string> emotionDictionary = new Dictionary<string, string>();

		public static void addAttribute(Attribute att) {
			// Actually, now I think about it, it doesn't even matter too much to have this if statement...
			listOfPossibleEmotions.Add(emotionDictionary[att.attributeCode()]);
			string resultingEmotion = emotionDictionary [att.attributeCode ()];
			char[] splitter = { '|' };
			if (resultingEmotion.Contains ("|")) {
				// There are two different emotions attributed to this
				string[] splittedString = resultingEmotion.Split (splitter);
				emotionFreq [splittedString[0]] = emotionFreq [splittedString[0]] + 1;
				emotionFreq [splittedString[1]] = emotionFreq [splittedString[1]] + 1;
			} else {
				emotionFreq [resultingEmotion] = emotionFreq [resultingEmotion] + 1;
			}
			updateEmotion();
		}

		public static void updateEmotion() {
			// Evaluate or revaluate the emotion

		}

		public static string getCurrentEmotion() {
			return currentEmotion;
		}

		public static void setEmotionDictionary() {
			emotionFreq.Add ("Confidence", 0);
			emotionFreq.Add ("Companionship", 0);
			emotionFreq.Add ("Cautious", 0);
			emotionFreq.Add ("Curiosity", 0);
			emotionFreq.Add ("Stress Signals", 0);
			emotionFreq.Add ("Anxiety & Avoidance", 0);
			emotionFreq.Add ("Smile", 0);
			emotionFreq.Add ("Fear", 0);
			emotionFreq.Add ("Relaxed & Neutral", 0);

			emotionDictionary.Add("0", "Confidence");
			emotionDictionary.Add("1", "Confidence");
			emotionDictionary.Add("2", "Confidence");
			emotionDictionary.Add("3", "Companionship");
			emotionDictionary.Add("4", "Cautious");
			emotionDictionary.Add("5", "Stress Signals");
			emotionDictionary.Add("6", "Stress Signals");
			emotionDictionary.Add("7", "Stress Signals");
			emotionDictionary.Add("8", "Stress Signals");
			emotionDictionary.Add("9", "Stress Signals");
			emotionDictionary.Add("10", "Anxiety & Avoidance");
			emotionDictionary.Add("11", "Anxiety & Avoidance");
			emotionDictionary.Add("12", "Anxiety & Avoidance");
			emotionDictionary.Add("13", "Anxiety & Avoidance");
			emotionDictionary.Add("14", "Smile");
			emotionDictionary.Add("15", "Smile");

			emotionDictionary.Add("Body0", "Confidence");
			emotionDictionary.Add("Body1", "Companionship");
			emotionDictionary.Add("Body2", "Cautious");
			emotionDictionary.Add("Body3", "Fear");
			emotionDictionary.Add("Body4", "Stress Signals");
			// Whenever | is included in the string, make sure to break it up
			emotionDictionary.Add("GeneralMuscle0", "Relaxed & Neutral|Companionship");
			emotionDictionary.Add("GeneralMuscle1", "Confidence");
			emotionDictionary.Add("GeneralMuscle2", "Fear|Stress Signals");

			emotionDictionary.Add("Lips0", "Relaxed & Neutral");
			emotionDictionary.Add("Lips1", "Fear|Stress Signals");
			emotionDictionary.Add("Lips2", "Smile");

			emotionDictionary.Add("Eyes0", "Relaxed & Neutral");
			emotionDictionary.Add("Eyes1", "Cautious");
			emotionDictionary.Add("Eyes2", "Fear");
			emotionDictionary.Add("Eyes3", "Stress Signals");

			emotionDictionary.Add("Head0", "Curiosity");
			emotionDictionary.Add("Head1", "Fear|Stress Signals");
			emotionDictionary.Add("Head2", "Anxiety & Avoidance");

			emotionDictionary.Add("Ears0", "Relaxed & Neutral");
			emotionDictionary.Add("Ears1", "Confidence");
			emotionDictionary.Add("Ears2", "Curiosity");
			emotionDictionary.Add("Ears3", "Fear");
			emotionDictionary.Add("Ears4", "Stress Signals");
			emotionDictionary.Add("Ears5", "Anxiety & Avoidance");
			emotionDictionary.Add("Ears6", "Smile");

			emotionDictionary.Add("Tail0", "Cautious");
			emotionDictionary.Add("Tail1", "Fear");

			emotionDictionary.Add("Legs0", "Cautious");

			emotionDictionary.Add("Back0", "Cautious");

			emotionDictionary.Add("Tongue0", "Cautious");
			emotionDictionary.Add("Tongue1", "Fear");
			emotionDictionary.Add("Tongue2", "Stress Signals");
			emotionDictionary.Add("Tongue3", "Stress Signals");

			emotionDictionary.Add("Paw0", "Fear");
			emotionDictionary.Add("Paw1", "Smile");
		}
	}

	// Use this for initialization
	void Start () {
		EmotionLogicEngine.setEmotionDictionary ();
	}
	
	// Update is called once per frame
	void Update () {
		if (listOfPossibleEmotions.Count > prevNum) {
			resultText.GetComponent<Text> ().text = "";

			// Later look more into SortedDictionary<K,V> to avoid these lines of shi*** code

			int highestNum = 0;
			string highestEmotion = "";

			int secondHighestNum = 0;
			string secondHighestEmotion = "";

			foreach (KeyValuePair<string, int> e in emotionFreq) {
				if (e.Value > highestNum) {
					highestNum = e.Value;
					highestEmotion = e.Key;
				}

				if (e.Value < highestNum && e.Value > secondHighestNum) {
					secondHighestNum = e.Value;
					secondHighestEmotion = e.Key;
				}
			}
			resultText.GetComponent<Text> ().text = highestEmotion + " or " + secondHighestEmotion;

			prevNum = listOfPossibleEmotions.Count;
		}
	}
}
