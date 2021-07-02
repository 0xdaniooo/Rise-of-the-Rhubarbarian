using UnityEngine;

/*
Manages what levels the player has access to
Written by Daniel Kasprzyk
*/

public class LevelTracker : MonoBehaviour
{
    public static LevelTracker Instance;
    public LevelInfo[] levels;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        levels[0].unlocked = true;
    }

    public bool LevelAccessCheck(int lvl)
    {
        foreach (LevelInfo i in levels)
        {
            if (i.level == lvl && i.unlocked)
            {
                return true;
            }
        }

        return false;
    }

    public void UnlockLevel(int lvl)
    {
        foreach (LevelInfo i in levels)
        {
            if (i.level == lvl)
            {
                i.unlocked = true;
            }
        }
    }

    [System.Serializable]
    public class LevelInfo
    {
        public int level;
        public bool unlocked = false;
    }
}

