using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting;
using UnityEngine.Profiling;

public class TestGC : MonoBehaviour{
    public Text test2;
    public Text test3;
    void Start(){
        Profiler.enabled = true;
        //GarbageCollector.GCMode = GarbageCollector.Mode.Disabled;
        //print(GarbageCollector.GCMode);
    }
    void Update(){
        test2.text = "heap reserved : "+Profiler.GetMonoHeapSizeLong().ToString();
        test3.text = "heap alloc : "+Profiler.GetMonoUsedSizeLong().ToString();
    }
}
