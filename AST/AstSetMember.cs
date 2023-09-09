namespace PxPre.Datum
{
    public class AstSetMember : Ast
    {
        public Val varOwner;
        public string memberName;

        public Val valueExpr;

        public AstSetMember(Val varOwner, string memberName, Val valueExpr)
        {
            this.memberName = memberName;
            this.varOwner = varOwner;
            this.valueExpr = valueExpr;
        }

        public override Val Execute(Ctx ctx, out EvalTy evalTy)
        {
            evalTy = EvalTy.Transform;
            Val evaledOwner = this.varOwner.Execute(ctx, out var _);
            Val evaledValue = this.valueExpr.Execute(ctx, out var _);
            evaledOwner.SetIndex(this.memberName, evaledValue);
            return evaledValue;
        }
    }
}