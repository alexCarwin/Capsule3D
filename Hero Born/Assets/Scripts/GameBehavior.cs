using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, IManager
{
    private string _state;
    public string State
    {

        get { return _state; }
        set { _state = value; }
    }
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public int maxItems = 4;
    public string labelText = "Collect all 4 items and win your freedom!";
    private int _itemsCollected = 0;
    public Stack<string> lookStack = new Stack<string>();
    public delegate void DebugDelegate(string NewText);
    public DebugDelegate debug = Print;

    void Start()
    {
        Initialize();
        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.item);
    }

    public void Initialize()
    {
        _state = "Manager initialized..";
        _state.FancyDebug();
        debug(_state);
        LogWithDelegate(debug);

        GameObject player = GameObject.Find("Player");

        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;

        lookStack.Push("Sword of Doom");
        lookStack.Push("HP+");
        lookStack.Push("Golden Key");
        lookStack.Push("Winged Boot");
        lookStack.Push("Mythril Bracers");
    }

    public void HandlePlayerJump()
    {
        debug("Player has jumped...");
    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task...");
    }

    void ChangeParam(string labelText)
    {
        this.labelText = labelText;

        Time.timeScale = 0f;
    }

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                ChangeParam("You've found all the items!");
                showWinScreen = true;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                ChangeParam("You want another life with that?");
                showLossScreen = true;
            }
            else
            {

                labelText = "Ouch... that's got hurt.";
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Item Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                try
                {
                    Utilities.RestartLevel(-2);
                    debug("Level restarted successfully...");
                }
                catch (System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    debug("Reverting to scene 0: " + e.ToString());
                }
                finally
                {
                    debug("Restart handled...");
                }

            }
        }
        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }

    }

    public void PrintLootReport()
    {
        var currentItem = lookStack.Pop();
        var nextItem = lookStack.Peek();

        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items waiting for you!", lookStack.Count);

    }
}
