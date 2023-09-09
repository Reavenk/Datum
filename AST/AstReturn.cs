using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.Datum
{
    public class AstReturn : Ast
    {
        public Val returnValue;

        public AstReturn(Val returnValue)
        { 
            this.returnValue = returnValue;
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            evalTy = EvalTy.Return;

            if(returnValue == null)
                return ValNone.Inst;

            return this.returnValue.Execute(ctx, out var _);
        }
    }
}