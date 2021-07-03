
using UnityEngine;

public class EnterDialogDoor : MonoBehaviour
{
    public GameObject enterDialogDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enterDialogDoor.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enterDialogDoor.SetActive(false);
        }

    }

}
