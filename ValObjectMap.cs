using System;
using System.Collections.Generic;

namespace PxPre.Datum
{
    public class ValObjectMap : Val
    {
        /// <summary>
        /// The raw bool value.
        /// </summary>
        List<(Val key, Val val)> vals = new List<(Val, Val)>();

        public override Type ty { get => Type.ObjectMap; }

        public ValObjectMap()
        { }

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

        private ValObjectMap CloneTy()
        {
            ValObjectMap ret = new ValObjectMap();
            foreach (var pair in this.vals)
                ret.vals.Add((pair.key, pair.val));

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
            for(int i = 0; i < this.vals.Count; ++i)
            { 
                if(this.vals[i].key.GetInt() == idx)
                { 
                    this.vals[i] = (Make(idx), v);
                    return true;
                }
            }
            this.vals.Add((Make(idx), v));
            return true;
        }

        public override bool SetIndex(string idx, Val v)
        {
            for(int i = 0; i < this.vals.Count; ++i)
            {
                if (this.vals[i].key.GetString() == idx)
                {
                    this.vals[i] = (Make(idx), v);
                    return true;
                }
            }
            this.vals.Add((Make(idx), v));
            return true;
        }

        public override bool SetIndex(Val idx, Val v)
        {
            for (int i = 0; i < this.vals.Count; ++i)
            {
                if (this.vals[i].key.Equivalent(idx))
                {
                    this.vals[i] = (idx, v);
                    return true;
                }
            }
            this.vals.Add((idx, v));
            return true;
        }

        public override Val Add(Val vb)
        {
            if (vb.ty == Type.Array)
            {
                ValObjectMap vom = this.CloneTy();
                int childCt = vb.ChildrenCount();
                for (int i = 0; i < childCt; ++i)
                    vom.SetIndex(i, vb.GetIndex(i));
                
                return vom;
            }
            else if(vb.ty == Type.ObjectMap)
            {
                ValObjectMap vom = this.CloneTy();
                int childCt = vb.ChildrenCount();
                for (int i = 0; i < childCt; ++i)
                {
                    Val fetch = vb.GetIndex(i);
                    vom.SetIndex(fetch.GetIndex(0), fetch.GetIndex(1));
                }

                return vom;
            }
            else if(vb.ty == Type.StringMap)
            {
                ValObjectMap vom = this.CloneTy();
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
            return this.vals.Count;
        }

        public override bool IsContainer()
        {
            return true;
        }

        public override Val GetIndex(int idx)
        {
            int childrenCt = this.vals.Count;
            for(int i = 0; i < childrenCt; ++i)
            { 
                if(this.vals[i].key.GetInt() == idx)
                    return this.vals[i].val;
            }
            return null;
        }

        public override Val GetIndex(string idx)
        {
            int childrenCt = this.vals.Count;
            for (int i = 0; i < childrenCt; ++i)
            {
                if(this.vals[i].key.GetString() == idx)
                    return this.vals[i].val;
            }
            return null;
        }

        public override Val GetIndex(Val idx)
        {
            int childrenCt = this.vals.Count;
            for (int i = 0; i < childrenCt; ++i)
            {
                if (this.vals[i].key.Equivalent(idx))
                    return this.vals[i].val;
            }
            return null;
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
            foreach( var pair in this.vals)
                va.Push(pair.key);
            
            return va;
        }
    }
}