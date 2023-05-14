using UnityEngine;

public class PlayerManager1 : MonoBehaviour
{
    public static PlayerManager1 instance;
    public PlayerScript playerData;

    private void Awake()
    {
        Debug.Log("NU YRA YRA");
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
