using UnityEngine;

using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System;

public static class SystemExtensions
{
    public static Dictionary<int, T> ConvertKey<T>(this Dictionary<string, T> dic)
    {
        return dic.ToDictionary(item => int.Parse(item.Key), item => item.Value);
    }
 
}