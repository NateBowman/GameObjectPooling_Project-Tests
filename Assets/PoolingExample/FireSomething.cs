using UnityEngine;
using System.Collections;
using Pooling;
using UnityStandardAssets.CrossPlatformInput;

public class FireSomething : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetAxis("Fire1") > 0)
        {
            isfiring = true;
        }
        else
        {
            isfiring = false;
            hasFired = false;
        }

        //Machine
        if (CrossPlatformInputManager.GetAxis("Fire2") > 0) {
            isfiring = true;
            hasFired = false;
        }
    }

    private bool isfiring = false;
    private bool hasFired = false;

    public void FixedUpdate()
    {
        if (isfiring && !hasFired)
        {
            FireProjectile();
            hasFired = true;
        }
    }

    public GameObject PrefabProjectile;
    private void FireProjectile()
    {
        var go = PrefabProjectile.GetFromPool();
        var pooled = go.GetIPoolableComponent();
        if (pooled != null) pooled.Restart();
        var cam = gameObject.transform.GetComponentInChildren<Camera>().transform;
        go.GetComponent<Rigidbody>().velocity = Vector3.zero;
        go.GetComponent<Rigidbody>().AddForce((cam.forward* 100f), ForceMode.Impulse);
        go.transform.position = (transform.position + cam.forward * 2f);
    }
}
