using System;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace RPNCalculator
{
  public partial class RPNEngine
  {
    private RPNStack internalStack;

    public RPNEngine()
    {
      this.internalStack = new RPNStack();
    }

    #region Properties

    public RPNStack Stack
    {
      get { return this.internalStack; }
    }

    #endregion

    #region Math Operators

    public void Add()
    {
      if ( this.Stack.Count >= 2 )
      {
        decimal rhs = this.Stack.Pop();
        decimal lhs = this.Stack.Pop();

        decimal result = lhs + rhs;
        this.Stack.Push( result );
      }
    }

    public void Subtract()
    {
      if ( this.Stack.Count >= 2 )
      {
        decimal rhs = this.Stack.Pop();
        decimal lhs = this.Stack.Pop();

        decimal result = lhs - rhs;
        this.Stack.Push( result );
      }
    }

    public void Multiply()
    {
      if ( this.Stack.Count >= 2 )
      {
        decimal rhs = this.Stack.Pop();
        decimal lhs = this.Stack.Pop();

        decimal result = lhs * rhs;
        this.Stack.Push( result );
      }
    }

    public void Divide()
    {
      if ( this.Stack.Count >= 2 && !this.Stack.Peek().Equals( 0m ) )
      {
        decimal rhs = this.Stack.Pop();
        decimal lhs = this.Stack.Pop();

        decimal result = lhs / rhs;
        this.Stack.Push( result );
      }
    }

    #endregion
  }
}
