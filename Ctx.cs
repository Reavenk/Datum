using System;
using System.Collections.Generic;

namespace PxPre.Datum
{
    public class Ctx
    {
        public enum Rule
        {
            None,
            MustExist,
            CannotExist
        }


        public readonly Ctx parent;
        public Dictionary<string, Val> members = new Dictionary<string, Val>();
        public Stack<Val> stack = new Stack<Val>();
        public List<Val> args = new List<Val>();
        public Val thisObj = null;

        public Ctx(Ctx parent)
        { 
            this.parent = parent;
        }


        public virtual Val Get(string name)
        {
            if (name == "this")
                return this.thisObj;

            if (this.thisObj != null)
            { 
                var findMember = this.thisObj.GetIndex(name);
                if(findMember != null)
                    return findMember;
            }

            if (members.TryGetValue(name, out var val))
                return val;

            return ValNone.Inst;
        }

        public virtual bool Set(string name, Val val, Rule rule)
        {
            if(this.thisObj != null)
            { 
                if(this.thisObj.SetIndex(name, val))
                    return true;
            }

            switch (rule)
            {
                case Rule.None:
                    members[name] = val;
                    break;
                case Rule.MustExist:
                    if(!members.ContainsKey(name))
                        return false;

                    members[name] = val;
                    break;

                case Rule.CannotExist:
                    if (members.ContainsKey(name))
                        return false;

                    members[name] = val;
                    break;

                default:
                    throw new NotImplementedException();
            }
            return true;
        }

        public Val GetInContextChain(string name)
        { 
            for(Ctx i = this; i != null; i = i.GetParent())
            { 
                Val g = i.Get(name);
                if(g != null)
                    return g;
            }
            return null;
        }

        public bool SetInContextChain(string name, Val v, bool fallbackTop)
        { 
            for(Ctx i = this; i != null; i = i.GetParent())
            {
                if(i.Set(name, v, Rule.MustExist))
                    return true;
                
            }
            if(fallbackTop)
            { 
                Set(name, v, Rule.None);
                return true;
            }
            return false;
        }

        public Ctx GetParent() => this.parent;

        public Ctx GetRoot()
        { 
            Ctx ret = this;
            while(true)
            { 
                Ctx parent = ret.GetParent();
                if(parent == null)
                    return ret;

                ret = parent;
            }
        }

        public void Push(Val v)
        { 
            this.stack.Push(v);
        }

        public void CopyStackTop()
        { 
            this.stack.Push(this.stack.Peek());
        }

        public Val Pop()
        { 
            return this.stack.Pop();
        }
    }
}