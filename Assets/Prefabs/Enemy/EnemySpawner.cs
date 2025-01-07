using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyRoots;
    public GameObject[] myChilds = new GameObject[5];
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;

    private void Start()
    {
        for (int i = 0; i < myChilds.Length; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < myChilds.Length; i++)
        {
            if (myChilds[i] == null)
            {
                var randomEnemy = enemyRoots[Random.Range(0, enemyRoots.Length)];
                var newRandomEnemy = Instantiate(randomEnemy, transform);
                var enemyRoot = newRandomEnemy.GetComponent<EnemyRoot>();
                enemyRoot.enemySpawner = this;
                enemyRoot.enemyMovement.transformA.position = posA.position;
                enemyRoot.enemyMovement.transformB.position = posB.position;
                myChilds[i] = newRandomEnemy;
            }
        }
    }
}
