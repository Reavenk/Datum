﻿// MIT License
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
    public class ValUInt : Val
    {
        /// <summary>
        /// The raw unsigned int value.
        /// </summary>
        public uint i;

        public override Type ty { get => Type.Int; }

        public ValUInt(uint i)
        {
            this.i = i;
        }

        public override bool GetBool()
        {
            return this.i != 0;
        }

        public override int GetInt()
        {
            return (int)this.i;
        }

        public override uint GetUInt()
        {
            return (uint)this.i;
        }

        public override long GetInt64()
        {
            return this.i;
        }

        public override ulong GetUInt64()
        {
            return (ulong)this.i;
        }

        public override float GetFloat()
        {
            return (float)this.i;
        }

        public override double GetFloat64()
        {
            return (double)this.i;
        }

        public override bool SetBool(bool v)
        {
            this.i = (uint)(v ? 1 : 0);
            return true;
        }

        public override bool SetInt(int v)
        {
            this.i = (uint)v;
            return true;
        }

        public override bool SetUInt(uint v)
        {
            this.i = v;
            return true;
        }

        public override bool SetInt64(long v)
        {
            this.i = (uint)v;
            return true;
        }

        public override bool SetUInt64(ulong v)
        {
            this.i = (uint)v;
            return true;
        }

        public override bool SetFloat(float v)
        {
            this.i = (uint)v;
            return true;
        }

        public override bool SetFloat64(double v)
        {
            this.i = (uint)v;
            return true;
        }

        public override string GetString()
        {
            return this.i.ToString();
        }

        public override bool SetString(string v)
        {
            uint ip;
            if (uint.TryParse(v, out ip) == false)
                return false;

            this.i = ip;
            return true;
        }

        public override Val Clone()
        {
            return new ValUInt(this.i);
        }

        public override bool SetValue(Val v)
        {
            this.i = v.GetUInt();
            return true;
        }

        public override Val Add(Val v)
        {
            return new ValUInt(this.i + v.GetUInt());
        }

        public override Val Mul(Val v)
        {
            return new ValUInt(this.i * v.GetUInt());
        }

        public override Val Min(Val v)
        {
            uint o = v.GetUInt();

            return new ValUInt(this.i < o ? this.i : o);
        }

        public override Val Max(Val v)
        {
            uint o = v.GetUInt();

            return new ValUInt(this.i > o ? this.i : o);
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
            return this.i == v.GetInt();
        }
    }
}