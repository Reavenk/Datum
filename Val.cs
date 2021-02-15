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
            /// The datatype is a float. GetFloat() and SetFloat() should be used
            /// to access its values.
            /// </summary>
            Float,

            /// <summary>
            /// The datatype is a string. GetString() and SetString() should be used
            /// to access its values.
            /// </summary>
            String
        }


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
        /// Get the float value. It's either a float value from
        /// a float Val, or the object's value converted to a float.
        /// </summary>
        /// <returns>The float value of the object.</returns>
        public abstract float GetFloat();

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
        /// Set the float value of the object - or the equivalent of the
        /// specified float value converted to its native datatype.
        /// </summary>
        /// <param name="v">The float value to set the object to.</param>
        /// <returns>True if the value, or an equivalent value was successfully set. Else, false</returns>
        public abstract bool SetFloat(float v);

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
    }
}