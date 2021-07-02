using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

/*
Allows the player to choose which level they want to play
Written by Daniel Kasprzyk
*/

public class LevelSelectScreen : MonoBehaviour
{
    public string levelOne, levelTwo, levelThree, levelFour;
    public GameObject inaccessibleMessage;
    private LevelTracker levelTracker;

    private void Start()
    {
        levelTracker = GameObject.FindGameObjectWithTag("LevelTracker").GetComponent<LevelTracker>();
    
        Time.timeScale = 1f;
    }

    public void LevelOne()
    {
        if (levelTracker.LevelAccessCheck(1))
        {
            SceneManager.LoadScene(levelOne);
        }

        else StartCoroutine(Inaccessible());
    }

    public void LevelTwo()
    {
        if (levelTracker.LevelAccessCheck(2))
        {
            SceneManager.LoadScene(levelTwo);
        }

        else StartCoroutine(Inaccessible());
    }

    public void LevelThree()
    {
        if (levelTracker.LevelAccessCheck(3))
        {
            SceneManager.LoadScene(levelThree);
        }

        else StartCoroutine(Inaccessible());
    }

    public void LevelFour()
    {
        if (levelTracker.LevelAccessCheck(4))
        {
            SceneManager.LoadScene(levelFour);
        }

        else StartCoroutine(Inaccessible());
    }

    private IEnumerator Inaccessible()
    {
        print("1");
        inaccessibleMessage.SetActive(true);
        yield return new WaitForSeconds(2f);
        inaccessibleMessage.SetActive(false);
    }
}
