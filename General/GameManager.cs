using System.Collections.Generic;
using UnityEngine;

/*
Manages the entirety of the game
(Game state, player, enemies)
Wtitten by Daniel Kasprzyk
*/

public class GameManager : MonoBehaviour
{
    public PlayerStats playerStats;
    [Header("Enemy prefab")]
    public GameObject orangeEnemy, bananaEnemy, carrotEnemy, brocolliEnemy;
    private int orangeCount, bananaCount, carrotCount, brocolliCount;
    public GameObject deathUi;
    public List<EnemyInfo> enemies;
    private CheckPointManager checkpoints;

    private void Start()
    {
        checkpoints = GameObject.FindGameObjectWithTag("CheckpointManager").GetComponent<CheckPointManager>();

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in temp)
        {
            EnemyStats enemyStats = obj.GetComponent<EnemyStats>();

            EnemyInfo info = new EnemyInfo();
            {
                info.enemyName = enemyStats.enemyName;
                info.enemyPosition = obj.transform.position;
            }

            enemies.Add(info);
        }

        foreach (EnemyInfo ei in enemies)
        {
            if (ei.enemyName == "OrangeEnemy")
            {
                orangeCount ++;
            }

            else if (ei.enemyName == "BananaEnemy")
            {
                bananaCount ++;
            }

            else if (ei.enemyName == "CarrotEnemy")
            {
                carrotCount ++;
            }

            else if (ei.enemyName == "BrocolliEnemy")
            {
                brocolliCount ++;
            }
        }
    }

    public void PlayerDeath()
    {
        deathUi.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayerRespawn()
    {
        playerStats.RefillHealth();
        deathUi.SetActive(false);
        EnemyRespawn();
        checkpoints.RepositionPlayer();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnemyRespawn()
    {
        List<EnemyInfo> tempEnemyInfo = new List<EnemyInfo>();
        GameObject[] tempEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in tempEnemies)
        {
            EnemyStats enemyStats = obj.GetComponent<EnemyStats>();

            EnemyInfo info = new EnemyInfo();
            {
                info.enemyName = enemyStats.enemyName;
                info.enemyPosition = obj.transform.position;
                info.enemyStats = enemyStats;
            }

            tempEnemyInfo.Add(info);
        }

        int oranges = 0, bananas = 0, carrots = 0, brocollis = 0;

        foreach (EnemyInfo ei in tempEnemyInfo)
        {
            if (ei.enemyName == "OrangeEnemy")
            {
                oranges ++;
            }

            else if (ei.enemyName == "BananaEnemy")
            {
                bananas ++;
            }

            else if (ei.enemyName == "CarrotEnemy")
            {
                carrots ++;
            }

            else if (ei.enemyName == "BrocolliEnemy")
            {
                brocollis ++;
            }
        }

        int orangesMissing = orangeCount - oranges;
        int bananasMissing = bananaCount - bananas;
        int carrotsMissing = carrotCount - carrots;
        int broccolisMissing = brocolliCount - brocollis;

        EnemyPlace(orangesMissing, "OrangeEnemy", orangeEnemy, tempEnemyInfo);
        EnemyPlace(bananasMissing, "BananaEnemy", bananaEnemy, tempEnemyInfo);
        EnemyPlace(carrotsMissing, "CarrotEnemy", carrotEnemy, tempEnemyInfo);
        EnemyPlace(broccolisMissing, "BrocolliEnemy", brocolliEnemy, tempEnemyInfo);

    }

    private void EnemyPlace(int missing, string name, GameObject prefab, List<EnemyInfo> tempEInfo)
    {
        if (missing > 0)
        {
            if (tempEInfo.Capacity != 0)
            {
                foreach (EnemyInfo enemyInfo in enemies)
                {
                    if (enemyInfo.enemyName == name)
                    {
                        foreach (EnemyInfo tempInfo in tempEInfo)
                        {
                            if (tempInfo != enemyInfo && missing > 0)
                            {
                                Instantiate(prefab, enemyInfo.enemyPosition, Quaternion.identity);
                                missing --;
                                break;
                            }
                            
                        }
                    }
                }
            }

            else 
            {
                foreach (EnemyInfo i in enemies)
                {
                    if (i.enemyName == name)
                    {
                        Instantiate(prefab, i.enemyPosition, Quaternion.identity);
                    }
                }
            }
        }

        else
        {
            foreach (EnemyInfo j in tempEInfo)
            {
                j.enemyStats.RefillHealth();
            }
        }
    }

}

[System.Serializable]
public class EnemyInfo
{
    public string enemyName;
    public Vector3 enemyPosition;
    public EnemyStats enemyStats;
}


