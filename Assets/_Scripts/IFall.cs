using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFall {
    void Fall(Vector3 acc);
}

public abstract class FallType : IFall{
    public void Fall(Vector3 acc) {
        
    }
}

public class FallNormal : FallType{
    
}
