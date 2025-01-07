using UnityEngine;

public class ItemMenuScript : MonoBehaviour // TODO: tüm panelleri ortak atadan türet
{
    [SerializeField] private GameObject itemMenu;
    [SerializeField] private Inventory inventory;

    void Start()
    {
        inventory = PlayerConstantsHolder._playerConstantsHolder.playerInventory;
        itemMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyBindings.KeyCodes[KeyBindings.KeyCode_Inventory]))
        {
            OpenCloseMenu();
        }
        if (Input.GetKeyDown(KeyBindings.KeyCodes[KeyBindings.KeyCode_MainMenu]))
        {
            OpenCloseMenu(true);
        }
    }

    void OpenCloseMenu(bool? fastClose = false)
    {
        if (fastClose.Value)
        {
            HideCursor.LockCursorMode(true);
            itemMenu.SetActive(false);
        }
        else
        {
            var panel = PanelManager._panelManager.AnyOpen();
            if (panel != null && panel != itemMenu)
            {
                return;
            }
            inventory.GenerateInventory();
            HideCursor.LockCursorMode(itemMenu.activeSelf);
            itemMenu.SetActive(!itemMenu.activeSelf);
        }

    }
}
