using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public class ValIdxObject : Val
    {
        const int MaxSupportedArray = 99999;
        // Integer indexes 0-MaxSupportedArray are stored here
        public List<Val> array = new List<Val>();
        // All other items, including higher numbers, are stored here
        public Dictionary<string,Val> map = new Dictionary<string, Val>();

        public override Type ty { get => Type.ObjectMap; }

        public ValIdxObject()
        { }

        public override bool GetBool()
        {
            return this.array.Count != 0 || this.map.Count != 0;
        }

        public override int GetInt()
        {
            return GetBool() ? 1 : 0;
        }

        public override uint GetUInt()
        {
            return (uint)(GetBool() ? 1 : 0);
        }

        public override long GetInt64()
        {
            return GetBool() ? 1 : 0;
        }

        public override ulong GetUInt64()
        {
            return (ulong)(GetBool() ? 1 : 0);
        }

        public override float GetFloat()
        {
            return GetBool() ? 1.0f : 0.0f;
        }

        public override double GetFloat64()
        {
            return GetBool() ? 1.0 : 0.0;
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

        private ValIdxObject CloneTy()
        {
            ValIdxObject ret = new ValIdxObject();
            foreach (var val in this.array)
                ret.array.Add(val.Clone());

            foreach(var kvp in this.map)
                ret.map[kvp.Key] = kvp.Value.Clone();

            return ret;
        }

        public override Val Clone()
        {
            return CloneTy();
        }

        public override bool SetValue(Val v)
        {
            return false;
        }

        public override bool SetIndex(int idx, Val v)
        {
            if(idx >= 0 && idx <= MaxSupportedArray)
            { 
                if(idx > this.array.Count)
                { 
                    this.array.Capacity = idx;
                    for(int i = this.array.Count; i < idx; ++i)
                        this.array.Add(ValNone.Inst);
                }
                this.array[idx] = v;
                return true;
            }

            this.map[idx.ToString()] = v;
            return true;
        }

        public override bool SetIndex(string idx, Val v)
        {
            this.map[idx] = v;
            return true;
        }

        public override bool SetIndex(Val idx, Val v)
        {   
            switch(idx.ty)
            { 
                case Type.String:
                    return SetIndex(idx.GetString(), v);
                case Type.Int:
                case Type.Int64:
                case Type.UInt64:
                case Type.Float:
                case Type.Float64:
                    return SetIndex(idx.GetInt(), v);
            }
            return false;
        }

        public override Val Add(Val vb)
        {
            if (vb.ty == Type.Array)
            {
                ValIdxObject vom = this.CloneTy();
                int childCt = vb.ChildrenCount();
                for (int i = 0; i < childCt; ++i)
                    vom.SetIndex(i, vb.GetIndex(i));

                return vom;
            }
            else if (vb.ty == Type.ObjectMap)
            {
                ValIdxObject vom = this.CloneTy();
                int childCt = vb.ChildrenCount();
                for (int i = 0; i < childCt; ++i)
                {
                    Val fetch = vb.GetIndex(i);
                    vom.SetIndex(fetch.GetIndex(0), fetch.GetIndex(1));
                }

                return vom;
            }
            else if (vb.ty == Type.StringMap)
            {
                ValIdxObject vom = this.CloneTy();
                return vom;
            }
            return ValNone.Inst;
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
            return this.array.Count;
        }

        public override bool IsContainer()
        {
            return true;
        }

        public override Val GetIndex(int idx)
        {
            if(idx > 0 && idx < MaxSupportedArray)
            {
                if(idx < this.array.Count)
                    return this.array[idx];

                return ValNone.Inst;
            }

            if(this.map.TryGetValue(idx.ToString(), out Val ret))
            { 
                return ret;
            }

            return ValNone.Inst;
        }

        public override Val GetIndex(string idx)
        {
            if (this.map.TryGetValue(idx.ToString(), out Val ret))
            {
                return ret;
            }

            return ValNone.Inst;
        }

        public override Val GetIndex(Val idx)
        {
            switch (idx.ty)
            {
                case Type.String:
                    if(this.map.TryGetValue(idx.GetString(), out var ret))
                        return ret;
                    else
                        return ValNone.Inst;
                case Type.Int:
                case Type.Int64:
                case Type.UInt64:
                case Type.Float:
                case Type.Float64:
                    int intIdx = idx.GetInt();
                    if(intIdx >= 0 && intIdx <= MaxSupportedArray)
                    { 
                        if(intIdx <= this.array.Count)
                            return this.array[intIdx];
                        else
                            return ValNone.Inst;
                    }
                    if (this.map.TryGetValue(intIdx.ToString(), out var retConv))
                        return retConv;
                    else
                        return ValNone.Inst;
            }
            return ValNone.Inst;
        }

        public override bool Equivalent(Val v)
        {
            //if (!v.IsContainer())
            //    return false;
            //
            //if (this.ChildrenCount() != v.ChildrenCount())
            //    return false;

            throw new NotImplementedException();

            //return true;
        }

        public override bool Equals(Val v)
        {
            return this == v;
        }

        public override ValArray GetIndices()
        {
            ValArray va = new ValArray();
            for(int i = 0; i < this.array.Count; ++i)
                va.Add(Val.Make(i));

            foreach(string k in this.map.Keys)
                va.Add(Val.Make(k));

            return va;
        }
    }
}