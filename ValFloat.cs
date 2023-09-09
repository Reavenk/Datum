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
    public class ValFloat : Val
    {
        /// <summary>
        /// The raw float value.
        /// </summary>
        public float f;

        public override Type ty { get => Type.Float; }

        public ValFloat(float f)
        { 
            this.f = f;
        }

        public override bool GetBool()
        { 
            return this.f != 0.0f;
        }

        public override int GetInt()
        { 
            return (int)this.f;
        }

        public override uint GetUInt()
        {
            return (uint)this.f;
        }

        public override long GetInt64()
        {
            return (long)this.f;
        }

        public override ulong GetUInt64()
        {
            return (ulong)this.f;
        }

        public override float GetFloat()
        { 
            return this.f;
        }

        public override double GetFloat64()
        {
            return this.f;
        }

        public override bool SetBool(bool v)
        { 
            this.f = v ? 1.0f : 0.0f;
            return true;
        }

        public override bool SetInt(int v)
        { 
            this.f = v;
            return true;
        }

        public override bool SetUInt(uint v)
        {
            this.f = v;
            return true;
        }

        public override bool SetInt64(long v)
        {
            this.f = (float)v;
            return true;
        }

        public override bool SetUInt64(ulong v)
        {
            this.f = (float)v;
            return true;
        }

        public override bool SetFloat(float v)
        { 
            this.f = v;
            return true;
        }

        public override bool SetFloat64(double v)
        {
            this.f = (float)v;
            return true;
        }

        public override string GetString()
        { 
            return f.ToString();
        }

        public override bool SetString(string v)
        { 
            float fp;
            if(float.TryParse(v, out fp) == false)
                return false;

            this.f = fp;
            return true;
        }

        public override Val Clone()
        {
            return new ValFloat(this.f);
        }

        public override bool SetValue(Val v)
        {
            this.f = v.GetFloat();
            return true;
        }

        public override Val Add(Val v)
        {
            return new ValFloat(this.f + v.GetFloat());
        }

        public override Val Mul(Val v)
        {
            return new ValFloat(this.f * v.GetFloat());
        }

        public override Val Min(Val v)
        {
            float o = v.GetFloat();
            return new ValFloat(this.f < o ? this.f : o);
        }

        public override Val Max(Val v)
        {
            float o = v.GetFloat();
            return new ValFloat(this.f > o ? this.f : o);
        }

        public override bool SetIndex(int idx, Val v) => false;
        public override bool SetIndex(string idx, Val v) => false;
        public override bool SetIndex(Val idx, Val v) => false;

        public override bool Equivalent(Val v)
        {
            return this.f == v.GetFloat();
        }
    }
}