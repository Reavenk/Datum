using System;
using System.Collections.Generic;

namespace PxPre.Datum
{
    public class ValStringMap : Val
    {
        Dictionary<string, Val> vals = new Dictionary<string, Val>();

        public override Type ty { get=> Type.Array; }

        public override bool GetBool()
        {
            return this.vals.Count > 0;
        }

        public override int GetInt()
        {
            return this.vals.Count > 0 ? 1 : 0;
        }

        public override uint GetUInt()
        {
            return (uint)(this.vals.Count > 0 ? 1 : 0);
        }

        public override long GetInt64()
        {
            return this.vals.Count > 0 ? 1 : 0;
        }

        public override ulong GetUInt64()
        {
            return (uint)(this.vals.Count > 0 ? 1 : 0);
        }

        public override float GetFloat()
        {
            return this.vals.Count > 0 ? 1.0f : 0.0f;
        }

        public override double GetFloat64()
        {
            return this.vals.Count > 0 ? 1.0 : 0.0;
        }

        public override bool SetBool(bool v)
        {
            return false;
        }

        public override bool SetInt(int v)
        {
            return false;
        }

        public override bool SetUInt(uint v)
        {
            return false;
        }

        public override bool SetInt64(long v)
        {
            return false;
        }

        public override bool SetUInt64(ulong v)
        {
            return false;
        }

        public override bool SetFloat(float v)
        {
            return false;
        }

        public override bool SetFloat64(double v)
        {
            return false;
        }

        public override string GetString()
        {
            return string.Empty;
        }

        public override bool SetString(string v)
        {
            return false;
        }

        public override Val Clone()
        {
            ValStringMap ret = new ValStringMap();
            foreach (KeyValuePair<string, Val> kvp in this.vals)
                ret.vals.Add(kvp.Key, kvp.Value);

            return ret;
        }

        public override bool SetValue(Val v)
        {
            return false;
        }

        public override bool SetIndex(int idx, Val v)
        {             
            return false;
        }

        public override bool SetIndex(string idx, Val v)
        { 
            this.vals[idx] = v;
            return true;
        }

        public override bool SetIndex(Val idx, Val v)
        { 
            string strIdx = idx.GetString();
            return this.SetIndex(strIdx, v);
        }

        public override Val Add(Val vb)
        {
            if (vb.ty != Type.StringMap)
                return ValNone.Inst;

            ValStringMap ret = new ValStringMap();
            foreach (var kvp in this.vals)
                ret.vals[kvp.Key] = kvp.Value;

            int childrenCt = vb.ChildrenCount();
            for (int i = 0; i < childrenCt; ++i)
            {
                Val vkvp = vb.GetIndex(i);
                ret.SetIndex(vkvp.GetIndex(0), vkvp.GetIndex(1));
            }

            return ret;

        }

        public override Val Mul(Val vb)
        {
            return ValNone.Inst;
        }

        public override Val Min(Val vb)
        {
            return ValNone.Inst;
        }

        public override Val Max(Val vb)
        {
            return ValNone.Inst;
        }

        public override int ChildrenCount()
        {
            return this.vals.Count;
        }

        public override bool IsContainer()
        {
            return true;
        }

        public override Val GetIndex(int i) 
        {
            return ValNone.Inst;
        }
        
        public override Val GetIndex(Val i) 
        {
            return GetIndex(i.ToString());
        }

        public override Val GetIndex(string idx) 
        {
            if(this.vals.TryGetValue(idx, out var val))
                return val;

            return ValNone.Inst;
        }

        public override bool Equivalent(Val v)
        {
            if(v.ty != v.ty)
                return false;

            if(this.vals.Count != v.ChildrenCount())
                return false;

            foreach(var kvp in this.vals)
            { 
                Val fetch = v.GetIndex(kvp.Key);
                if(fetch == null)
                    return false;

                if(!kvp.Value.Equivalent(fetch))
                    return false;
            }
            return true;
        }

        public override ValArray GetIndices()
        {
            ValArray va = new ValArray();
            foreach (var kvp in this.vals)
                va.Push(Make(kvp.Key));

            return va;
        }

        public override bool Equals(Val v)
        {
            return this == v;
        }
    }
}