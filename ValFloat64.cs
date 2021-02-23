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

using System.Collections;
using System.Collections.Generic;

namespace PxPre.Datum
{
    public class ValFloat64 : Val
    {
        public double d;

        public override Type ty { get => Type.Float64; }

        public ValFloat64(double d)
        {
            this.d = d;
        }

        public override bool GetBool()
        {
            return this.d != 0;
        }

        public override int GetInt()
        {
            return (int)this.d;
        }

        public override long GetInt64()
        {
            return (long)this.d;
        }

        public override float GetFloat()
        {
            return (float)this.d;
        }

        public override double GetFloat64()
        {
            return this.d;
        }

        public override bool SetBool(bool v)
        {
            this.d = v ? 1.0 : 0.0;
            return true;
        }

        public override bool SetInt(int v)
        {
            this.d = v;
            return true;
        }

        public override bool SetInt64(long v)
        {
            this.d = v;
            return true;
        }

        public override bool SetFloat(float v)
        {
            this.d = v;
            return true;
        }

        public override bool SetFloat64(double v)
        {
            this.d = d;
            return true;
        }

        public override string GetString()
        {
            return this.d.ToString();
        }

        public override bool SetString(string v)
        {
            double dp;
            if (double.TryParse(v, out dp) == false)
                return false;

            this.d = dp;
            return true;
        }

        public override Val Clone()
        {
            return new ValFloat64(this.d);
        }

        public override bool SetValue(Val v)
        {
            this.d = v.GetInt64();
            return true;
        }

        public override Val Add(Val v)
        {
            return new ValFloat64(this.d + v.GetFloat64());
        }

        public override Val Mul(Val v)
        {
            return new ValFloat64(this.d * v.GetFloat64());
        }

        public override Val Min(Val v)
        {
            double o = v.GetFloat64();

            return new ValFloat64(this.d < o ? this.d : o);
        }

        public override Val Max(Val v)
        {
            long o = v.GetInt64();

            return new ValFloat64(this.d > o ? this.d : o);
        }
    }
}