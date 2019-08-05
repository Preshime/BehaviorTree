using System;
using System.Collections.Generic;

public class NodeModel // 树上的所有数据来源
{
    public NodeModel(TreeNode rNode)
    {
        BaseNode = rNode;
    }

    private TreeNode BaseNode;

    private Dictionary<string, int> Integer = new Dictionary<string, int>();
    private Dictionary<string, float> Float = new Dictionary<string, float>();
    private Dictionary<string, bool> Boolean = new Dictionary<string, bool>();
    private Dictionary<string, string> String = new Dictionary<string, string>();
    private Dictionary<string, object> Obj = new Dictionary<string, object>();

    private Dictionary<string, bool> TagIsPlay = new Dictionary<string, bool>();

    public void SetValue<T>(string key, T value)
    {
        if (TagIsPlay.ContainsKey(key))
            TagIsPlay[key] = false;
        else
            TagIsPlay.Add(key, false);

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

        BaseNode.Play();
    }

    public bool TryGetValue<T>(string key, out T obj)
    {
        bool bIsPlayed;
        if (!TagIsPlay.TryGetValue(key, out bIsPlayed) || bIsPlayed)
        {
            obj = default(T);
            return false;
        }
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

    public void SetTagIsPlayed(string tag)
    {
        if (TagIsPlay.ContainsKey(tag))
            TagIsPlay[tag] = true;
        else
            TagIsPlay.Add(tag, true);
    }
}
