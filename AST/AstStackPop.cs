using System;

namespace PxPre.Datum
{
    public class AstStackPop : Ast
    {
        public Val runFirst;

        public AstStackPop(Val runFirst) 
        { 
            this.runFirst = runFirst;
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            if(runFirst != null)
                runFirst.Execute(ctx, out var _);

            evalTy = EvalTy.Transform;
            return ctx.Pop();
        }
    }
}