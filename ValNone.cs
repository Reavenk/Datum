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
    public class ValNone : Val
    {
        public static ValNone Inst = new ValNone();

        public override Type ty { get; }

        public override bool GetBool()
        { 
            return false;
        }

        public override int GetInt()
        { 
            return 0;
        }

        public override uint GetUInt()
        {
            return 0;
        }

        public override long GetInt64()
        {
            return 0;
        }

        public override ulong GetUInt64()
        {
            return 0;
        }

        public override float GetFloat()
        { 
            return 0.0f;
        }

        public override double GetFloat64()
        {
            return 0.0;
        }

        public override string GetString()
        { 
            return string.Empty;
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

        public override bool SetString(string v)
        { 
            return false;
        }

        public override Val Clone()
        { 
            return this;
        }

        public override bool SetValue(Val v)
        { 
            return false;
        }

        public override Val Add(Val v)
        {
            return this;
        }

        public override Val Mul(Val v)
        { 
            return this;
        }

        public override Val Min(Val v)
        { 
            return this;
        }

        public override Val Max(Val v)
        { 
            return this;
        }

        public override bool SetIndex(int idx, Val v) => false;
        public override bool SetIndex(string idx, Val v) => false;
        public override bool SetIndex(Val idx, Val v) => false;

        public override bool Equals(Val v)
        {
            return v.ty == Type.None;
        }

        public override bool Equivalent(Val v)
        {
            return v.ty == Type.None;
        }
    }
}
