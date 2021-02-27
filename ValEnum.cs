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

using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    /// <summary>
    /// Information of possible values for a enum subtype.
    /// </summary>
    public class Selections
    {
        /// <summary>
        /// The mapping from int values to string values.
        /// 
        /// The values should be synced with class member stoi, which is the inverse mapping.
        /// </summary>
        public Dictionary<int, string> itos = new Dictionary<int, string>();

        /// <summary>
        /// The mapping from string values to int values.
        /// 
        /// The values should be synced with class member itos, which is the inverse mapping.
        /// </summary>
        public Dictionary<string, int> stoi = new Dictionary<string, int>();

        /// <summary>
        /// Cached enum conversions for FromEnum<>(). That function takes C# enums and automates 
        /// turning them into Datum Selections. The first time a new enum subtype is encountered,
        /// it is cached in CachedFromEnum in case that enum subtype is retrived again later.
        /// </summary>
        static Dictionary<System.Type, Selections> CachedFromEnums = 
            new Dictionary<System.Type, Selections>();

        /// <summary>
        /// Constructor. Given a list of string, set their int values to the index
        /// they appeared in the list.
        /// </summary>
        /// <param name="sels">The string values for the possible values of the enum.</param>
        public Selections(string [] sels)
        { 
            for(int i = 0; i < sels.Length; ++i)
            { 
                itos.Add(i, sels[i]);
                stoi.Add(sels[i], i);
            }
        }

        /// <summary>
        /// Constructor, given an int=>string mapping.
        /// </summary>
        /// <param name="itos">The int=>string mapping of possible enum values.</param>
        public Selections(Dictionary<int, string> itos)
        {
            this.itos = itos;
            foreach(KeyValuePair<int, string> kvp in itos)
            {
                if(this.stoi.ContainsKey(kvp.Value) == true)
                    continue;

                this.stoi.Add(kvp.Value, kvp.Key);
            }

        }

        /// <summary>
        /// Constructor, given a string=>int mapping.
        /// </summary>
        /// <param name="stoi">The string=>int mapping of possible enum values.</param>
        public Selections(Dictionary<string, int> stoi)
        {
            this.stoi = stoi;

            foreach (KeyValuePair<string, int> kvp in stoi)
            {
                if (this.itos.ContainsKey(kvp.Value) == true)
                    continue;

                this.itos.Add(kvp.Value, kvp.Key);
            }
        }

        /// <summary>
        /// Template factory. Given an enum subtype, turn it into
        /// a Selection.
        /// </summary>
        /// <typeparam name="k">The enum subtype.</typeparam>
        /// <returns>The Selections that represents the enum subtype.</returns>
        public static Selections FromEnum<k>() where k: System.Enum
        {
            Selections ret;
            if(CachedFromEnums.TryGetValue(typeof(k), out ret) == true)
                return ret;

            // https://stackoverflow.com/a/6454988
            Dictionary<string, int> stoi = new Dictionary<string, int>();
            System.Array array = System.Enum.GetValues(typeof(k));
            foreach(var v in array)
                stoi.Add(v.ToString(), (int)v);

            ret = new Selections(stoi);
            CachedFromEnums.Add(typeof(k), ret);

            return ret;
        }

        /// <summary>
        /// Get the string value of a specified enum value.
        /// </summary>
        /// <param name="idx">The int value to retrieve the mapped string value for.</param>
        /// <returns>The string value mapped to the int parameter value. If none is found, an
        /// empty string is returned.</returns>
        public string GetString(int idx)
        {
            if(this.itos.TryGetValue(idx, out string v) == true)
                return v;

            return idx.ToString();
        }

        /// <summary>
        /// Get the int value of a specified string enum value.
        /// </summary>
        /// <param name="str">The string value to retrieve the mapped int value for.</param>
        /// <returns>An optional returning the mapped int value, or null if the value was not found.</returns>
        public int ? GetInt(string str)
        {
            if(this.stoi.TryGetValue(str, out int i) == true)
                return i;

            return null;
        }

        /// <summary>
        /// Get an enumerable of all the string values of the enum.
        /// </summary>
        /// <returns>An enumerable of all the string values of the enum.</returns>
        public IEnumerable<string> GetNames()
        { 
            return this.stoi.Keys;
        }
    }

    public class ValEnum : Val
    {
        /// <summary>
        /// The raw enum value.
        /// </summary>
        public int i;

        /// <summary>
        /// The possible values for the enum.
        /// </summary>
        public readonly Selections selections;

        public override Type ty { get => Type.Enum; }

        public ValEnum(int i, Selections sels)
        { 
            this.selections = sels;
        }

        public static ValEnum FromEnum<k>(int i) where k : System.Enum
        { 
            Selections sels = Selections.FromEnum<k>();
            return new ValEnum(i, sels);
        }

        public override bool GetBool()
        { 
            return (this.i != 0) ? true : false;
        }

        public override int GetInt()
        { 
            return this.i;
        }

        public override uint GetUInt()
        {
            return (uint)this.i;
        }

        public override long GetInt64()
        {
            return (long)this.i;
        }

        public override ulong GetUInt64()
        {
            return (ulong)this.i;
        }

        public override float GetFloat()
        { 
            return this.i;
        }

        public override double GetFloat64()
        {
            return this.i;
        }

        public override bool SetBool(bool v)
        { 
            this.i = v ? 1 : 0;
            return true;
        }

        public override bool SetInt(int v)
        { 
            this.i = v;
            return true;
        }

        public override bool SetUInt(uint v)
        {
            this.i = (int)v;
            return true;
        }

        public override bool SetInt64(long v)
        {
            this.i = (int)v;
            return true;
        }

        public override bool SetUInt64(ulong v)
        {
            this.i = (int)v;
            return true;
        }

        public override bool SetFloat(float v)
        { 
            this.i = (int)v;
            return true;
        }

        public override bool SetFloat64(double v)
        {
            this.i = (int)v;
            return true;
        }


        public override string GetString()
        {
            return this.selections.GetString(this.i);
        }

        public override bool SetString(string v)
        { 
            int ? idx = this.selections.GetInt(v);
            if(idx.HasValue)
            { 
                this.i = idx.Value;
                return true;
            }

            int ip;
            if(int.TryParse(v, out ip) == false)
                return false;

            this.i = ip;
            return true;
        }

        public override Val Clone()
        {
            return new ValEnum(this.i, this.selections);
        }

        public override bool SetValue(Val v)
        {
            this.i = v.GetInt();
            return true;
        }

        public override Val Add(Val vb)
        {
            return new ValInt(this.i + vb.GetInt());
        }

        public override Val Mul(Val vb)
        {
            return new ValInt(this.i * vb.GetInt());
        }

        public override Val Min(Val vb)
        {
            return new ValInt(Mathf.Min(this.i, vb.GetInt()));
        }

        public override Val Max(Val vb)
        {
            return new ValInt(Mathf.Max(this.i, vb.GetInt()));
        }
    }
}