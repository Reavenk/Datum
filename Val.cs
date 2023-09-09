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
    public abstract class Val
    { 
        /// <summary>
        /// Intrinsic datatypes
        /// </summary>
        public enum Type
        { 
            /// <summary>
            /// The datatype for a null variable.
            /// </summary>
            None,

            /// <summary>
            /// The datatype is a bool. GetBool() and SetBool() should be used 
            /// to access its values.
            /// </summary>
            Bool,

            /// <summary>
            /// The datatype is an enum. GetInt() or GetString() should be used to
            /// get the value. SetInt() or SetSTring() should be used to set the value.
            /// </summary>
            Enum,

            /// <summary>
            /// The datatype is an int. GetInt() and SetInt() should be used
            /// to access its values.
            /// </summary>
            Int,

            /// <summary>
            /// The datatype is an unsigned int. GetUInt() and SetUInt() should be used
            /// to access its values.
            /// </summary>
            UInt,

            /// <summary>
            /// The datatype is a float. GetFloat() and SetFloat() should be used
            /// to access its values.
            /// </summary>
            Float,

            /// <summary>
            /// The datatype is a 64 bit int. GetInt64() and SetInt64() should be used
            /// to access its values.
            /// </summary>
            Int64,

            /// <summary>
            /// The datatype is a 64 bit usngiend int. GetUInt64() and SetUInt64() should be used
            /// to access its values.
            /// </summary>
            UInt64,

            /// <summary>
            /// The datatype is a double precision float. GetFloat64 and SetFloat64() should be used
            /// to access it values.
            /// </summary>
            Float64,

            /// <summary>
            /// The datatype is a string. GetString() and SetString() should be used
            /// to access its values.
            /// </summary>
            String,

            Array,

            StringMap,

            ObjectMap,

            Executable,

            Context,

            Custom,

            Scope,

            Relay
        }

        /// <summary>
        /// When a Val is evaluated, where did the result come from?
        /// </summary>
        public enum EvalTy
        { 
            /// <summary>
            /// The Val sent itself back
            /// </summary>
            Relay,

            /// <summary>
            /// The Val came from a return statement
            /// </summary>
            Return,

            /// <summary>
            /// The Val came from a yield statement
            /// </summary>
            Yield,

            /// <summary>
            /// The Val performed a misc transformation (all others that don't fit
            /// into any other EvalTy value).
            /// </summary>
            Transform,

            /// <summary>
            /// The Val came from a continue statement
            /// </summary>
            Continue,

            /// <summary>
            /// The Val came from a break statement
            /// </summary>
            Break
        }

        public IPrototype prototype = null;

        public abstract Type ty {get; }

        /// <summary>
        /// The type the value should be treated as.
        /// 
        /// The variable can also be seen as shorthand for:
        /// "this datatype is a wrapper for the datatype of -"
        /// </summary>
        public virtual Type wrapType { get => this.ty; }

        /// <summary>
        /// Get the bool value. It's either a bool value from
        /// a bool Val, or the object's value converted to a bool.
        /// </summary>
        /// <returns>The bool value of the object.</returns>
        public abstract bool GetBool();

        /// <summary>
        /// Get the int value. It's either an int value from
        /// an int Val, or the object's value converted to an int.
        /// </summary>
        /// <returns>The int value of the object.</returns>
        public abstract int GetInt();

        /// <summary>
        /// Get the unsigned int value. It's either an unsigned int value from
        /// an int Val, or the object's value converted to an unsigned int.
        /// </summary>
        /// <returns>The int value of the object.</returns>
        public abstract uint GetUInt();

        /// <summary>
        /// Get long int value. It's either a long value from
        /// a Int64 Val, or the object's value converted to an long.
        /// </summary>
        /// <returns>The long value of the object.</returns>
        public abstract long GetInt64();

        /// <summary>
        /// Get unsigned long value. It's either an unsigned long value from
        /// a UInt64 Val, or the object's value converted to an unsigned long.
        /// </summary>
        /// <returns>The long value of the object.</returns>
        public abstract ulong GetUInt64();

        /// <summary>
        /// Get the float value. It's either a float value from
        /// a float Val, or the object's value converted to a float.
        /// </summary>
        /// <returns>The float value of the object.</returns>
        public abstract float GetFloat();

        /// <summary>
        /// Get the double value. It's either a double value from
        /// a Float64 Val, or the object's value converted to a double.
        /// </summary>
        /// <returns>The float value of the object.</returns>
        public abstract double GetFloat64();

        /// <summary>
        /// Get the string value. It's either a string value from
        /// a string Val, or the object's value converted to a string.
        /// </summary>
        /// <returns>The string value of the object.</returns>
        public abstract string GetString();

        /// <summary>
        /// Set the bool value of the object - or the equivalent of the
        /// specified bool value converted to its native datatype.
        /// </summary>
        /// <param name="v">The bool value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetBool(bool v);

        /// <summary>
        /// Set the int value of the object - or the equivalent of the
        /// specified int value converted to its native datatype.
        /// </summary>
        /// <param name="v">The int value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetInt(int v);

        /// <summary>
        /// Set the unsigned int value of the object - or the equivalent of the
        /// specified int value converted to its native datatype.
        /// </summary>
        /// <param name="v">The unsigned int value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetUInt(uint v);

        /// <summary>
        /// Set the long value of the object - or the equivalent of the
        /// specified long value converted to its native datatype.
        /// </summary>
        /// <param name="v">The long value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetInt64(long v);

        /// <summary>
        /// Set the unsigned long value of the object - or the equivalent of the
        /// specified unsigned long value converted to its native datatype.
        /// </summary>
        /// <param name="v">The unsigned long value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetUInt64(ulong v);

        /// <summary>
        /// Set the float value of the object - or the equivalent of the
        /// specified float value converted to its native datatype.
        /// </summary>
        /// <param name="v">The float value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetFloat(float v);

        /// <summary>
        /// Set the double value of the object - or the equivalent of the
        /// specified double value converted to its native datatype.
        /// </summary>
        /// <param name="v">The double value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetFloat64(double v);

        /// <summary>
        /// Set the string value of the object - or the equivalent of the
        /// specified string value converted to its native datatype.
        /// </summary>
        /// <param name="v">The string value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetString(string v);

        /// <summary>
        /// Create a copy of the object.
        /// </summary>
        /// <returns>A deep copy of the object.</returns>
        public abstract Val Clone();

        /// <summary>
        /// Set the value of an object from a Val.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract bool SetValue(Val v);

        public abstract bool SetIndex(int idx, Val v);

        public abstract bool SetIndex(string idx, Val v);

        public abstract bool SetIndex(Val idx, Val v);

        public virtual ValArray GetIndices(){ return new ValArray(); }

        /// <summary>
        /// Get the value of two Vals added.
        /// </summary>
        /// <param name="v">The other value to add to the invoking object.</param>
        /// <returns>The value that is the sum of the invoking object and parameter.
        /// The resulting datatype depends on the Add() implementation of the invoking object.</returns>
        public abstract Val Add(Val v);

        /// <summary>
        /// Multiply the value of two Vals.
        /// </summary>
        /// <param name="v">The other value to multiply by the invoking object.</param>
        /// <returns>The value that is the product of the invoking object and parameter.
        /// The resulting datatype depends on the Mul() implementation of the invoking object.</returns>
        public abstract Val Mul(Val v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns> The value that is the minimum between the invoking object and parameter.
        /// The resulting datatype depends on the Min() implementation of the invoking object.</returns>
        public abstract Val Min(Val v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns>The value that is the maximum between the invoking object and parameter.
        /// The resulting datatype depends on the Max() implementation and the invoking object.</returns>
        public abstract Val Max(Val v);

        /// <summary>
        /// The number of children in the object. Some datatypes cannot have children, and will
        /// return 0 by default.
        /// </summary>
        /// <returns>The number of children the object has.</returns>
        public virtual int ChildrenCount(){return 0; }

        /// <summary>
        /// If true, the value is a container type that explicitly contains children Val objects.
        /// </summary>
        /// <returns>If true, the datatype is a container that can contain child Val object. Else, the 
        /// datatype does not container children values. 
        /// 
        /// Note that this is not the same as not having accessible children. Some datatypes can imply 
        /// children, even though they explicitly have none, such as strings containing invdividual character.
        /// </returns>
        public virtual bool IsContainer(){return false; }

        /// <summary>
        /// Get the child Val at a specified integer index.
        /// </summary>
        /// <param name="i">The index to retrieve.</param>
        /// <returns>The Val found at the specified index, or a null or None object if the child
        /// could not be found. It is unspecified if the return will be a None object or null,
        /// and depends on the implementation of the invoking object.</returns>
        public virtual Val GetIndex(int i){ return null; }

        /// <summary>
        /// Get the child Val mapped to a specific Val key.
        /// </summary>
        /// <param name="i">The key to retrieve the mapped value for.</param>
        /// <returns>The Val found at the specified key, or a null or None object if the child
        /// could not be found. It is unspecified if the return will be a None object or null,
        /// and depends on the implementation of the invoking object.</returns>
        public virtual Val GetIndex(Val i){ return null; }

        public virtual Val GetIndex(string idx)
        {
            if(prototype != null)
                return prototype.GetPrototypeMember(this, idx);
            
            return null;
        }

        public virtual Val Execute(Ctx ctx, out EvalTy evalTy) { evalTy = EvalTy.Relay; return this; }

        public virtual bool Equals(Val v)
        { 
            if(this == v)
                return true;

            if(this.ty != v.ty)
                return false;

            return this.Equivalent(v);
        }

        public abstract bool Equivalent(Val v);

        public virtual bool AppendInstruction(Val v) => false;

        /// <summary>
        /// Utility function to make a ValInt using an overloaded function name Make().
        /// </summary>
        /// <param name="i">The ValInt value.</param>
        /// <returns>A ValInt with the parameter value.</returns>
        public static Val Make(int i)
        { 
            return new ValInt(i);
        }

        /// <summary>
        /// Utility function to make a ValUInt using an overloaded function name Make().
        /// </summary>
        /// <param name="i">The ValUInt value.</param>
        /// <returns>A ValUInt with the parameter value.</returns>
        public static Val Make(uint i)
        { 
            return new ValUInt(i);
        }

        /// <summary>
        /// Utility function to make a ValFloat using an overloaded function name Make().
        /// </summary>
        /// <param name="f">The ValFloat value.</param>
        /// <returns>A ValFloat with the parameter value.</returns>
        public static Val Make(float f)
        { 
            return new ValFloat(f);
        }

        /// <summary>
        /// Utility function to make a ValInt64 using an overloaded function name Make().
        /// </summary>
        /// <param name="l">The ValInt64 value.</param>
        /// <returns>A ValInt64 with the parameter value.</returns>
        public static Val Make(long l)
        {
            return new ValInt64(l);
        }

        /// <summary>
        /// Utility function to make a ValUInt64 using an overloaded function name Make().
        /// </summary>
        /// <param name="l">The ValUInt64 value.</param>
        /// <returns>A ValUInt64 with the parameter value.</returns>
        public static Val Make(ulong l)
        {
            return new ValUInt64(l);
        }

        /// <summary>
        /// Utility function to make a ValFloat64 using an overloaded function name Make().
        /// </summary>
        /// <param name="d">The ValFloat64 value.</param>
        /// <returns>A ValFloat64 with the parameter value.</returns>
        public static Val Make(double d)
        { 
            return new ValFloat64(d);
        }

        /// <summary>
        /// Utility function to make a ValBool using an overloaded function name Make().
        /// </summary>
        /// <param name="b">The ValBool value.</param>
        /// <returns>A ValBool with the parameter value.</returns>
        public static Val Make(bool b)
        { 
            return new ValBool(b);
        }

        /// <summary>
        /// Utility function to make a ValString using an overloaded function name Make().
        /// </summary>
        /// <param name="s">The ValString value.</param>
        /// <returns>A ValString with the parameter value.</returns>
        public static Val Make(string s)
        {
            return new ValString(s);
        }
    }
}