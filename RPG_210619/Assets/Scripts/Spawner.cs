using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnEnemy;
    GameObject enemyInstance = null;

    bool spawning = false;
    public float spawnDelay = 5f;

    private void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnDelay);

        enemyInstance = Instantiate(spawnEnemy, transform.position, new Quaternion(Random.rotation.x, 0, Random.rotation.z, Quaternion.identity.w));
        enemyInstance.GetComponent<Enemy>().spawner = this;
    }
}
