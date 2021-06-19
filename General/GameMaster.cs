using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 lastCheckPointPos;

    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetPosition();
    }

    private void SetPosition()
    {
        if (lastCheckPointPos != null)
        {
            player.transform.position = lastCheckPointPos;
            print("Position set");
        }
    }
}
