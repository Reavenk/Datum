using System;

namespace PxPre.Datum
{
    public class AstGetMember : Ast
    {
        public Val varOwner;
        public string memberName;

        public AstGetMember(Val varOwner, string memberName)
        {
            this.memberName = memberName;
            this.varOwner = varOwner;
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            evalTy = EvalTy.Transform;
            Val evaledOwner = varOwner.Execute(ctx, out var _);
            return evaledOwner.GetIndex(this.memberName);
        }
    }
}