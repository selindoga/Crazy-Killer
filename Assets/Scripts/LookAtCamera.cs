using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.LookAt(Player.transform.GetChild(1));
    }
}
