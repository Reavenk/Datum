using System;

namespace PxPre.Datum
{
    public class AstStackPush : Ast
    {
        public Val toPush;

        public AstStackPush(Val toPush)
        { 
            this.toPush = toPush;
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            evalTy = EvalTy.Transform;
            Val evaledToPush = toPush.Execute(ctx, out var _);
            ctx.Push( evaledToPush );
            return evaledToPush;
        }
    }
}