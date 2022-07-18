using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManagement : MonoBehaviour
{
    public ResourceBox manaBox;
    public ResourceBox goldBox;
    public ResourceBox gemBox;
    public RollTower rollTower;
    public WaveSpawner waveSpawner;
    private float countdown = 0;
    private float timeBetweenWaves = 25;
    
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenWaves = waveSpawner.timeBetweenWaves*5;
        countdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
		{
			StartCoroutine(OnNextWave());
			countdown = timeBetweenWaves;
		}
		countdown -= Time.deltaTime;
    }

    public bool spendResources(int gold, int gems, int mana) {
        if(gold > goldBox.value || gems > gemBox.value || mana > manaBox.value) {
            return false;
        }
        gemBox.value -= gems;
        goldBox.value -= gold;
        manaBox.value -= mana;
        return true;
    }

    private IEnumerator OnNextWave()
    {
        rollTower.rollResources();
        yield return new WaitForSeconds(0.5f);
    }    
}
