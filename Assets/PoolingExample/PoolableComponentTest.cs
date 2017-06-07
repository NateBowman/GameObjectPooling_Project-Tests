using System;
using Pooling;
using UnityEngine;

public class PoolableComponentTest : GenericPoolableComponent {
    [NonSerialized]
    public static int ObjectCount = 0;

    public static int ObjectRecycleCount = 0;
    public static int ObjectUseCount = 0;


    private IPoolable pooled;
    private Rigidbody rigid;
    private float timer = 0;
    private bool stationary = false;

    public override void Reset() {
        timer = 0;
        stationary = false;
        ObjectRecycleCount++;
        ObjectUseCount--;
        base.Reset();
    }

    public override void Restart() {
        ObjectUseCount++;
        base.Restart();
    }

    public void Start() {
        pooled = gameObject.GetIPoolableComponent();
        rigid = gameObject.GetComponent<Rigidbody>();
        ObjectCount++;
    }

    public override void Update() {
        if (rigid.velocity == Vector3.zero) {
            stationary = true;
        }
        if (stationary) {
            timer += Time.deltaTime;
        }
        if (timer > 2f) {
            gameObject.ReturnPooled();
        }
        base.Update();
    }
}