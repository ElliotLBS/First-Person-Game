using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoop : MonoBehaviour
{

    public static void Main(string[] args)
    {
        int n = 5, sum = 0;

        for (int i = 1; i <= n; i++)
        {
            // sum = sum + i;
            sum += i;
        }

       print("Sum of first {0} natural numbers = {1}"+" "+ n + "," + sum);
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
