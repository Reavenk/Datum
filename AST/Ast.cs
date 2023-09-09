using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public class Ast : Val
    {
        public override Type ty => Type.Scope;

        public override bool GetBool() { throw new NotImplementedException(); }
        public override int GetInt() { throw new NotImplementedException(); }
        public override uint GetUInt() { throw new NotImplementedException(); }
        public override long GetInt64() { throw new NotImplementedException(); }
        public override ulong GetUInt64() { throw new NotImplementedException(); }
        public override float GetFloat() { throw new NotImplementedException(); }
        public override double GetFloat64() { throw new NotImplementedException(); }
        public override string GetString() { throw new NotImplementedException(); }
        public override bool SetBool(bool v) { throw new NotImplementedException(); }
        public override bool SetInt(int v) { throw new NotImplementedException(); }
        public override bool SetUInt(uint v) { throw new NotImplementedException(); }
        public override bool SetInt64(long v) { throw new NotImplementedException(); }
        public override bool SetUInt64(ulong v) { throw new NotImplementedException(); }
        public override bool SetFloat(float v) { throw new NotImplementedException(); }
        public override bool SetFloat64(double v) { throw new NotImplementedException(); }
        public override bool SetString(string v) { throw new NotImplementedException(); }

        public override Val Clone() { throw new NotImplementedException(); }

        public override bool SetValue(Val v) { throw new NotImplementedException(); }
        public override bool SetIndex(int idx, Val v) { throw new NotImplementedException(); }
        public override bool SetIndex(string idx, Val v) { throw new NotImplementedException(); }
        public override bool SetIndex(Val idx, Val v) { throw new NotImplementedException(); }
        public override Val Add(Val v) { throw new NotImplementedException(); }
        public override Val Mul(Val v) { throw new NotImplementedException(); }
        public override Val Min(Val v) { throw new NotImplementedException(); }
        public override Val Max(Val v) { throw new NotImplementedException(); }

        public override bool Equivalent(Val v) { throw new NotImplementedException(); }
    }
}