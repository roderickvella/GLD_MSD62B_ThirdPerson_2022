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
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    ShowHideInventorySystem();
        //}
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

    public void OnButtonPressed(string key)
    {
        if(gameState == GameState.AreaA)
        {
            switch (key)
            {
                case "TAB":
                    Canvas.GetComponentInChildren<InventoryManager>().ShowToggleInventory();
                    break;
                case "J":
                    Canvas.GetComponentInChildren<InventoryManager>().ChangeSelection(true);
                    break;
                case "K":
                    Canvas.GetComponentInChildren<InventoryManager>().ChangeSelection(false);
                    break;
                case "RETURN":
                    Canvas.GetComponentInChildren<InventoryManager>().ConfirmSelection();
                    break;
                default:
                    break;
            }
        }
        else if(gameState == GameState.AreaB)
        {
            switch (key)
            {
                case "TAB":
                    print("Hide the coin in Area B");
                    GameObject coin = GameObject.Find("Plane2/Coin");
                    if(coin != null) coin.SetActive(false);
                    break;
            }
        }
    }

    public void OnMouseButtonPressed(int mouse)
    {
        if(gameState == GameState.AreaA)
        {
            switch (mouse)
            {
                case 0:
                    GameObject.Find("Player").GetComponent<PlayerManager>().ThrowGrenade();
                    break;
            }
        }
    }


    //Area A is the blue zone; Area B is the green zone
    public enum GameState
    {
        AreaA,
        AreaB
    }
}
