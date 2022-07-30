using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountScore : MonoBehaviour
{
    public Text ScoreBoard;
    int killCount;
    List<Enemy> taggedEnemies;
    Enemy[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        taggedEnemies = new List<Enemy>();
        killCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = Resources.FindObjectsOfTypeAll(typeof(Enemy)) as Enemy[];
        foreach (var enemy in enemies)
        {
            if(!taggedEnemies.Contains(enemy)) {
                enemy.OnDestroyAction = OnDestroyListener;
                taggedEnemies.Add(enemy);
            }
        }
        ScoreBoard.text = "Score: " + killCount;
    }

    private void OnDestroyListener()
    {
        killCount++;
    }
}
