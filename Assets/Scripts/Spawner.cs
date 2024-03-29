using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab, player;
    public int maxEnemies = 10;
    public float spawnRate = .25F;
    public float spawnDistance = 10;
    public List<GameObject> goals = new List<GameObject>();
    public bool toggleFour = false;
    public ScoreManager scoreManager;
    public float killScoreInc= .5F;

    List<GameObject> removeList = new List<GameObject>();
    List<GameObject> spawnedEnemies = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnBeat(int beat)
    {
        float tempSpawnRate = spawnRate;
        tempSpawnRate -= Random.value;
        while (spawnedEnemies.Count < maxEnemies && tempSpawnRate > 0) //spawn randomly, but average out to spawnRate enemies per beat
        {
            tempSpawnRate -= Random.value;
            GameObject newEnemy;
            if (!toggleFour)
            {
                float rotation = Random.value * Mathf.PI * 2;
                Vector3 positionFromPlayer = spawnDistance * new Vector3(Mathf.Sin(rotation), Mathf.Cos(rotation), 7);
                newEnemy = (GameObject)Instantiate(enemyPrefab, player.transform.position + positionFromPlayer, this.gameObject.transform.rotation);
            }
            else
            {
                Vector3 startPos;
                int x = Random.Range(0, 4);
                if (x == 0)
                    startPos = new Vector3(-13.4F, 2.5F, 7);
                else if (x == 1)
                    startPos = new Vector3(13.4F, 2.5F, 7);
                else if (x == 2)
                    startPos = new Vector3(-13.4F, -1.5F, 7);
                else
                    startPos = new Vector3(13.4F, -1.5F, 7);
                newEnemy = (GameObject)Instantiate(enemyPrefab, startPos, this.gameObject.transform.rotation);
                newEnemy.SendMessage("Bullet");
            }
            EnemyAI newAI = newEnemy.GetComponent<EnemyAI>();
            int minIndex = -1;
            float dist = float.MaxValue;
            for(int i = 0; i < goals.Count; i++)
            {
                float temp = Vector3.Distance(goals[i].transform.position, newEnemy.transform.position);
                if(temp < dist)
                {
                    dist = temp;
                    minIndex = i;
                }
            }
            if(minIndex == -1)
            {
                newAI.Setup(player, null, this.gameObject);
            }
            else
            {
                newAI.Setup(player, goals[minIndex], this.gameObject);
            }
            spawnedEnemies.Add(newEnemy);
        }
        for (int i = 0; i < spawnedEnemies.Count; i++) {
            if (spawnedEnemies[i] != null) {
                spawnedEnemies[i].SendMessage("OnBeat", beat);
            }
            else
            {
                ScoreManager.score += killScoreInc;
                spawnedEnemies.RemoveAt(i);
                i--;
            }
        }
        for (int i = 0; i < removeList.Count;)
        {
            ScoreManager.score += killScoreInc;
            GameObject rem = removeList[i];
            spawnedEnemies.Remove(rem);
            removeList.Remove(rem);
            Destroy(rem);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
