using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    static readonly int MIN = 0;
    readonly int value;

    public Health(in int value)
    {
        if (value <= MIN)
        {
            return;
        }

        this.value = value;
    }

    public Health IncreaseHealth(int value)
    {
        return new Health(this.value + value);
    }

    public Health DecreaseHealth(int value)
    {
        return new Health(this.value - value);
    }

    public int GetHealth()
    {
        return this.value;
    }
}
