using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStatic : MonoBehaviour
{
    static MusicStatic S;

    //永不消毁脚本，每次进入初始场景时进行判断，若存在重复则销毁
    void Awake()
    {
        if (S == null)
            S = this;
        else if (S != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
