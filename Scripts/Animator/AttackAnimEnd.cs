using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimEnd : MonoBehaviour
{
    [SerializeField]
    private bool AtkAnimEnd;
    
    public bool GetAtkAnimEnd
    {
        get => AtkAnimEnd;
        set => AtkAnimEnd = value;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        AtkAnimEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void anitionEnd()
    {
        AtkAnimEnd = true;
    }
}
