//using AdvancedInspector;
using Pooling;
using UnityEngine;

public class PoolingTestSpawner : MonoBehaviour {
    /// <summary>
    /// Number to spawn
    /// </summary>
    public int Val = 1;

    /// <summary>
    /// Reference to spawning prefab
    /// </summary>
    public GameObject[] Prefab;


    /// <summary>
    /// Editor test mass spawn button
    /// </summary>
    //[Inspect] //Advanced Inspector
    private void TestSpawn()
    {
        foreach (var t in Prefab) {
            for (var i = 0; i < 200; i++) {
                var go = PrefabFactoryPool.GetFromPool(t);
                go.transform.position = new Vector3(Random.Range(-30, 30), gameObject.transform.position.y, Random.Range(-30, 30));
                go.transform.Rotate(new Vector3(Random.Range(-30, 30), gameObject.transform.position.y, Random.Range(-30, 30)));
                go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.value, 0, Random.value));
                go.GetComponent<IPoolable>().Restart();
            }
        }
    }

    private void Start() {}

    private void Update()
    {
        //Spawn "Val" prefabs in random positions within Vector3(400,400,400) of this GameObject
        for (var i = 0; i < Val; i++) {
            foreach (var gob in Prefab) {
                var go = PrefabFactoryPool.GetFromPool(gob);
                go.transform.position = new Vector3(Random.Range(-30, 30), gameObject.transform.position.y, Random.Range(-30, 30));
                go.transform.Rotate(new Vector3(Random.Range(-180, 180), gameObject.transform.position.y, Random.Range(-180, 180)));
                go.GetComponent<IPoolable>().Restart();
                go.GetComponent<Rigidbody>().AddForce(go.transform.forward * Random.value*30,ForceMode.Impulse);
            }
        }
    }
}