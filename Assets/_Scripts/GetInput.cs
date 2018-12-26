using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//platform independent input class

public static class GetInput {

    public static bool Forward() {

        if (Input.GetKey(KeyCode.D))
            return true;

        if (Input.GetKey(KeyCode.RightArrow))
            return true;

        return false;

    }
    
    public static bool Back() {

        if (Input.GetKey(KeyCode.A))
            return true;

        if (Input.GetKey(KeyCode.LeftArrow))
            return true;

        return false;

    }
    
    public static bool Up() {

        if (Input.GetKeyDown(KeyCode.W))
            return true;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            return true;
        
        if (Input.GetKeyDown(KeyCode.Space))
            return true;

        return false;

    }
    
    public static bool Down() {

        if (Input.GetKeyDown(KeyCode.S))
            return true;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            return true;

        return false;

    }
    
    public static bool Light() {

        if (Input.GetKey(KeyCode.I))
            return true;

        return false;

    }
    
    public static bool Heavy() {

        if (Input.GetKey(KeyCode.O))
            return true;

        return false;

    }
    
    
    
}
