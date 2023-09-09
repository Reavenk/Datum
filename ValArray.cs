using System;
using System.Collections.Generic;

namespace PxPre.Datum
{
    public class ValArray : Val
    {
        /// <summary>
        /// The raw array.
        /// </summary>
        public List<Val> vals = new List<Val>();

        public override Type ty { get => Type.Array; }

        public ValArray()
        {}

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
            ValArray ret = new ValArray();
            foreach(Val v in this.vals)
                ret.vals.Add(v.Clone());

            return ret;
        }

        public override bool SetValue(Val v)
        {
            return false;
        }

        public override bool SetIndex(int idx, Val v)
        {
            if(idx < 0 || idx >= this.vals.Count)
                return false;

            this.vals[idx] = v;
            return true;
        }

        public override bool SetIndex(string idx, Val v)
        { 
            return false;
        }

        public override bool SetIndex(Val idx, Val v)
        { 
            int nIdx = idx.GetInt();
            return SetIndex(nIdx, v);
        }

        public override Val Add(Val vb)
        {
            if(vb.ty != Type.Array)
                return ValNone.Inst;

            ValArray ret = new ValArray();
            foreach(Val v in this.vals)
                ret.vals.Add(v);

            int childrenCt = vb.ChildrenCount();
            for (int i = 0; i < childrenCt; ++i)
                ret.vals.Add(vb.GetIndex(i));

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
            if(i < 0 || i >= this.vals.Count)
                return null;

            return this.vals[i];
        }

        public override Val GetIndex(Val i) 
        {
            int nIdx = i.GetInt();
            return GetIndex(nIdx);
        }

        public override bool Equivalent(Val v)
        { 
            if(!v.IsContainer())
                return false;

            if(this.ChildrenCount() != v.ChildrenCount())
                return false;

            for(int i = 0; i < this.vals.Count; ++i)
            { 
                if(!this.vals[i].Equivalent(v.GetIndex(i)))
                    return false;
            }

            return true;
        }

        public override ValArray GetIndices()
        {
            ValArray va = new ValArray();
            for(int i = 0; i < this.vals.Count; ++i)
                va.Push(Make(i));

            return va;
        }

        public override bool Equals(Val v)
        {
            return this == v;
        }

        public void Push(Val v)
        { 
            this.vals.Add(v);
        }

        public Val Pop()
        { 
            Val ret = this.vals[0];
            this.vals.RemoveAt(0);
            return ret;
        }

        public Val Peek()
        { 
            return this.vals[0];
        }
    }
}