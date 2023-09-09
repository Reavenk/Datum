using System;

namespace PxPre.Datum
{
    public class AstGetIndex : Ast
    {
        public Val arrayFetch;
        public Val index;

        public AstGetIndex(Val arrayFetch, Val index)
        { 
            this.arrayFetch = arrayFetch;
            this.index = index;
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            Val vArray = this.arrayFetch.Execute(ctx, out var _);
            Val vIdx = this.index.Execute(ctx, out var _);

            evalTy = EvalTy.Transform;
            return vArray.GetIndex(vIdx);
        }
    }
}
