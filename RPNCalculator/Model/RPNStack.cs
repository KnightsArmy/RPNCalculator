using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RPNCalculator
{
  public class RPNStack : ObservableCollection<Decimal>
  {
    public RPNStack()
    {
      this.Add( 0m );
    }

    public void Push( decimal var )
    {
      this.Add( var );
    }

    public decimal Pop()
    {
      if ( this.Count == 0 )
      {
        throw new System.IndexOutOfRangeException();
      }

      decimal PoppedValue = this[ this.Count - 1 ];
      this.RemoveAt( this.Count - 1 );
      return PoppedValue;
    }

    public decimal Peek()
    {
      if ( this.Count == 0 )
      {
        throw new System.IndexOutOfRangeException();
      }

      return this[ this.Count - 1 ];
    }

    public new void Clear()
    {
      base.Clear();
      this.Add( 0m );
    }

    public void GetArgs( out decimal rhs, out decimal lhs )
    {
      if ( this.Count <= 1 )
      {
        throw new System.IndexOutOfRangeException();
      }

      rhs = this[ this.Count - 1 ];
      lhs = this[ this.Count - 2 ];
    }
  }
}
