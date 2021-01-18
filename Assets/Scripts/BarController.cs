using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField] private Bar staminaBar;
    [SerializeField] private Bar healthBar;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bed;
    private ItemContainer inventory;
    void Start()
    {
        staminaBar.SetSize(100);
        healthBar.SetSize(100);
        inventory = GameManager.instance.inventoryContainer;
    }

    void Update()
    {
        if (staminaBar.getBarState() < 0) //gdy wytrzymałość spadnie poniżej 0
        {
            staminaBar.SetSize(0);
            healthBar.Subtract(10); //utrata żywotności
            GameManager.instance.money -= 10;
            GameManager.instance.moneyTextField.text = GameManager.instance.money.ToString();
        }
        if (healthBar.getBarState() <= 0)
        {
            healthBar.SetSize(1);
            if (staminaBar.getBarState() == 0) GameManager.instance.eventController.ShowEvent("Umarłeś z przemęczenia...", "Następnym razem pamiętaj o odpowiednim odpoczynku.", 5);

            GameManager.instance.money -= 50;
            GameManager.instance.moneyTextField.text = GameManager.instance.money.ToString();
            ToBed(); //chwilę czeka i przenosi do łóżka

            /*System.Random rnd = new System.Random();
            int id;
            bool jestItem = true;
            bool doDrop = true;
            int iter = 0;
            do { //szuka itema
                iter++;
                id = rnd.Next(17);
                if((inventory.slots[id].item != null) && (inventory.slots[id].item.price > 0)) jestItem = true; //jeśli ma cenę, czyli nie jest narzędziem
                if (iter > 17)
                {
                    jestItem = false;//żeby za długo nie szukał
                    doDrop = false;
                }
            } while (!jestItem);
            if (doDrop) { //jeśli znalazł item
                //Vector3 dropPosition = new Vector3(player.transform.position.x + 2, player.transform.position.y + 2, 0);
                //GameManager.instance.dragAndDropController.Drop(inventory.slots[id], dropPosition);//upuszcza item
                //GameManager.instance.toolbarPanel.SetActive(false);
                //GameManager.instance.toolbarPanel.SetActive(true);
                //GameManager.instance.inventoryPanel.SetActive(true);
                //GameManager.instance.inventoryPanel.SetActive(false);
            }   */

        }
    }
    
    private void ToBed()
    {
        StartCoroutine(WaitAndTeleport());
    }
    IEnumerator WaitAndTeleport()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector2(bed.transform.position.x + 2, bed.transform.position.y); //przenosi do łóżka
    }

    public void Regenerate() //odnawia życie i wytrzymałość
    {
        staminaBar.SetSize(100);
        healthBar.SetSize(100);
    }
}
