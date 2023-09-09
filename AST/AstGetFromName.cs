using System;

namespace PxPre.Datum
{
    public class AstGetFromName : Ast
    {
        public string varName;

        public AstGetFromName(string varName)
        {
            this.varName = varName;
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            evalTy = EvalTy.Transform;
            return ctx.GetInContextChain(this.varName);
        }
    }
}