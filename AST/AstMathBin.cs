using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public abstract class AstMathBin : Ast
    {
        public Val left;
        public Val right;

        public AstMathBin(Val left, Val right)
        { 
            this.left = left;
            this.right = right;
        }
    }
}
