using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank instance;

    [SerializeField] int startingBalance = 0;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        instance = this;
        currentBalance = startingBalance;
    }

    public void Deposit(int mount)
    {
        currentBalance += Mathf.Abs(mount);
    }
    public void Withdraw(int mount)
    {
        currentBalance -= Mathf.Abs(mount);
        if (currentBalance < 0)
        {

        }
    }
}
