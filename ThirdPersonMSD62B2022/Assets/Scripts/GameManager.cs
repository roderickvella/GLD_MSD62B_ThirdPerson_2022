using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private GameObject Canvas;
    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        //create a singleton
        if (GameManager.Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        gameState = GameState.AreaA;
        Canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowHideInventorySystem();
        }
    }

    public void OnChangeGameState(GameState gameState)
    {
        print("Changing game state to:" + gameState.ToString());
        this.gameState = gameState;
    }

    private void ShowHideInventorySystem()
    {
        //we call a method inside InventoryManager to toggle the inventory window's animation
        Canvas.GetComponentInChildren<InventoryManager>().ShowToggleInventory();
    }


    //Area A is the blue zone; Area B is the green zone
    public enum GameState
    {
        AreaA,
        AreaB
    }
}
