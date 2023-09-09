// MIT License
// 
// Copyright (c) 2021 Pixel Precision, LLC
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace PxPre.Datum
{
    public class ValUInt64 : Val
    {
        public ulong l;

        public override Type ty { get => Type.Int64; }

        public ValUInt64(ulong l)
        {
            this.l = l;
        }

        public override bool GetBool()
        {
            return this.l != 0;
        }

        public override int GetInt()
        {
            return (int)this.l;
        }

        public override uint GetUInt()
        {
            return (uint)this.l;
        }

        public override long GetInt64()
        {
            return (long)this.l;
        }

        public override ulong GetUInt64()
        {
            return this.l;
        }

        public override float GetFloat()
        {
            return this.l;
        }

        public override double GetFloat64()
        {
            return this.l;
        }

        public override bool SetBool(bool v)
        {
            this.l = (ulong)(v ? 1 : 0);
            return true;
        }

        public override bool SetInt(int v)
        {
            this.l = (ulong)v;
            return true;
        }

        public override bool SetUInt(uint v)
        {
            this.l = v;
            return true;
        }

        public override bool SetInt64(long v)
        {
            this.l = (ulong)v;
            return true;
        }

        public override bool SetUInt64(ulong v)
        {
            this.l = v;
            return true;
        }

        public override bool SetFloat(float v)
        {
            this.l = (ulong)v;
            return true;
        }

        public override bool SetFloat64(double v)
        {
            this.l = (ulong)v;
            return true;
        }

        public override string GetString()
        {
            return this.l.ToString();
        }

        public override bool SetString(string v)
        {
            ulong lp;
            if (ulong.TryParse(v, out lp) == false)
                return false;

            this.l = lp;
            return true;
        }

        public override Val Clone()
        {
            return new ValUInt64(this.l);
        }

        public override bool SetValue(Val v)
        {
            this.l = v.GetUInt64();
            return true;
        }

        public override Val Add(Val v)
        {
            return new ValUInt64(this.l + v.GetUInt64());
        }

        public override Val Mul(Val v)
        {
            return new ValUInt64(this.l * v.GetUInt64());
        }

        public override Val Min(Val v)
        {
            ulong o = v.GetUInt64();

            return new ValUInt64(this.l < o ? this.l : o);
        }

        public override Val Max(Val v)
        {
            ulong o = v.GetUInt64();

            return new ValUInt64(this.l > o ? this.l : o);
        }

        public override bool SetIndex(int idx, Val v)
        { 
            return false;
        }

        public override bool SetIndex(string idx, Val v)
        { 
            return false;
        }

        public override bool SetIndex(Val idx, Val v)
        { 
            return false;
        }

        public override bool Equivalent(Val v)
        {
            return this.l == v.GetUInt64();
        }
    }
}