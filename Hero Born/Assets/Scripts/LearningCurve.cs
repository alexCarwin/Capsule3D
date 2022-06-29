using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LearningCurve : MonoBehaviour
{
    public Transform camTransform;
    public GameObject directionLight;
    private Transform lightTransform;

    void Start()
    {
        // directionLight = GameObject.Find("Directional Light");
        lightTransform = directionLight.GetComponent<Transform>();
        Debug.Log(lightTransform.localPosition);
        camTransform = this.GetComponent<Transform>();
        Debug.Log(camTransform.localPosition);
        Character hero = new Character();
        Debug.LogFormat("Hero: {0} - {1} EXP", hero.name, hero.exp);
        Character heroine = new Character("Agatha");
        Debug.LogFormat("Hero: {0} - {1} EXP", heroine.name, heroine.exp);





        // int[] topPlayerScores = new int[3] { 5, 6, 7 };
        // int[] topPlayerScoresNew = { 5, 6, 8 };
        // int score = topPlayerScores[1];

        // List<string> questPartyMembers = new List<string>() { "Grim", "Merlin", "Sterling" };
        // questPartyMembers.Add("Craven");
        // questPartyMembers.Insert(1, "Tanis");
        // questPartyMembers.RemoveAt(0);

        // for (int i = 0; i < questPartyMembers.Count; i++)
        // {
        //     Debug.LogFormat("Index: {0} - {1}", i, questPartyMembers[i]);
        //     if (questPartyMembers[i] == "Merlin")
        //     {
        //         Debug.Log("Hello Merlin");
        //     }
        // }

        // foreach (string partyMember in questPartyMembers)
        // {
        //     Debug.LogFormat("{0} - Here!", partyMember);
        // }

        // Dictionary<string, int> itemInventory = new Dictionary<string, int>
        // {
        //     {"Potion", 5},
        //     {"Antidote", 7},
        //     {"Aspirin", 1}
        // };

        // foreach (KeyValuePair<string, int> kvp in itemInventory)
        // {
        //     if (charactersGold >= kvp.Value)
        //     {
        //         Debug.Log($"You can buy ${kvp.Key}");
        //     }
        //     Debug.LogFormat("Item {0} - {1}g", kvp.Key, kvp.Value);
        // }


        // //  Debug.LogFormat("Items: {0}", itemInventory.Count);
        // int numberOfPorions = itemInventory["Potion"];
        // itemInventory.Add("Knife", 3);
        // itemInventory["Bandage"] = 5;
        // if (itemInventory.ContainsKey("Aspirin"))
        // {
        //     itemInventory["Aspirin"] = 3;
        // }


        // while (playerLives > 0)
        // {
        //     Debug.Log("Player still alive");
        //     playerLives--;
        // }


    }





    void Update()
    {

    }
}
