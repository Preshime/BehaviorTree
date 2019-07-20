using System;
using System.Collections.Generic;

public class NodeModel // 树上的所有数据来源
{
    private Dictionary<string, int> Integer = new Dictionary<string, int>();
    private Dictionary<string, float> Float = new Dictionary<string, float>();
    private Dictionary<string, bool> Boolean = new Dictionary<string, bool>();
    private Dictionary<string, string> String = new Dictionary<string, string>();
    private Dictionary<string, object> Obj = new Dictionary<string, object>();

    public void SetValue<T>(string key, T value)
    {
        if (typeof(T) == typeof(int))
        {
            int i = (int)(object)value;
            if (Integer.ContainsKey(key))
                Integer[key] = i;
            else
                Integer.Add(key, i);
        }
        else if (typeof(T) == typeof(float))
        {
            float f = (float)(object)value;
            if (Float.ContainsKey(key))
                Float[key] = f;
            else
                Float.Add(key, f);
        }
        else if (typeof(T) == typeof(bool))
        {
            bool b = (bool)(object)value;
            if (Boolean.ContainsKey(key))
                Boolean[key] = b;
            else
                Boolean.Add(key, b);
        }
        else if (typeof(T) == typeof(string))
        {
            string s = (string)(object)value;
            if (String.ContainsKey(key))
                String[key] = s;
            else
                String.Add(key, s);
        }
        else
        {
            object o = (int)(object)value;
            if (Obj.ContainsKey(key))
                Obj[key] = o;
            else
                Obj.Add(key, o);
        }
    }

    public bool TryGetValue<T>(string key, out T obj)
    {
        if (typeof(T) == typeof(int))
        {
            int i = 0;
            bool isSuccess = Integer.TryGetValue(key, out i);
            obj = (T)(object)i;
            return isSuccess;
        }
        else if (typeof(T) == typeof(float))
        {
            float f = 0f;
            bool isSuccess = Float.TryGetValue(key, out f);
            obj = (T)(object)f;
            return isSuccess;
        }
        else if (typeof(T) == typeof(bool))
        {
            bool b = false;
            bool isSuccess = Boolean.TryGetValue(key, out b);
            obj = (T)(object)b;
            return isSuccess;
        }
        else if (typeof(T) == typeof(string))
        {
            string s = "";
            bool isSuccess = String.TryGetValue(key, out s);
            obj = (T)(object)s;
            return isSuccess;
        }
        else
        {
            object o;
            bool isSuccess = Obj.TryGetValue(key, out o);
            obj = (T)o;
            return isSuccess;
        }
    }


}
