using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace RPNCalculator
{
  public class RPNCalculatorViewModel
  {
    private RPNEngine RpnEngine;

    private bool DecimalDigitPressed = false;
    private bool EnterPressed = false;

    // Used for GetArgs
    private decimal lhsArgument = 0;
    private decimal rhsArgument = 0;

    private ListBox Display;

    public RPNCalculatorViewModel( ListBox display )
    {
      this.RpnEngine = new RPNEngine();
      this.Display = display;
    }

    public RPNStack RpnStack
    {
      get { return RpnEngine.Stack; }
    }

    public void Copy( object sender, ExecutedRoutedEventArgs e )
    {
      System.Windows.Clipboard.SetData( System.Windows.DataFormats.Text, (object)this.RpnStack.Peek() );
    }

    public void Paste( object sender, ExecutedRoutedEventArgs e )
    {
      decimal valueToPaste;

      if ( decimal.TryParse( System.Windows.Clipboard.GetText(), out valueToPaste ) )
      {
        this.RpnEngine.Stack.Push( valueToPaste );
      }
    }

    //
    // Puts the arguments used in the last mathematical operation back onto the stack
    //
    public void GetArgsAndPushOntoStack( object sender, ExecutedRoutedEventArgs e )
    {
      this.RpnStack.Push( this.lhsArgument );
      this.RpnStack.Push( this.rhsArgument );

      this.ScrollBottomOfStackIntoView();
    }

    #region Math Event Handlers

    public void Add( object sender, ExecutedRoutedEventArgs e )
    {
      this.StoreArguments();
      this.RpnEngine.Add();
      this.PostMathOperationProcessing();
    }

    public void Subtract( object sender, ExecutedRoutedEventArgs e )
    {
      this.StoreArguments();
      this.RpnEngine.Subtract();
      this.PostMathOperationProcessing();
    }

    public void Multiply( object sender, ExecutedRoutedEventArgs e )
    {
      this.StoreArguments();
      this.RpnEngine.Multiply();
      this.PostMathOperationProcessing();
    }

    public void Divide( object sender, ExecutedRoutedEventArgs e )
    {
      this.StoreArguments();
      this.RpnEngine.Divide();
      this.PostMathOperationProcessing();
    }

    //
    // These things have to be done after every time a mathematical operation is executed.
    //
    private void PostMathOperationProcessing()
    {
      this.EnterPressed = true;
      this.DecimalDigitPressed = false;
    }

    // 
    // Gets the arguments and stores them locally to be used when the user issues the GetArgs command.
    //
    private void StoreArguments()
    {
      this.RpnStack.GetArgs( out this.rhsArgument, out this.lhsArgument );
    }

    public void AddDigit( object sender, ExecutedRoutedEventArgs e )
    {
      byte digit = System.Convert.ToByte( e.Parameter );

      if ( this.EnterPressed && !this.DecimalDigitPressed )
      {
        this.RpnEngine.Stack.Push( digit );
        this.EnterPressed = false;
      }
      else
      {
        decimal val = 0;

        if ( ( !this.EnterPressed || !this.DecimalDigitPressed ) && this.RpnEngine.Stack.Count > 0 )
        {
          val = this.RpnEngine.Stack.Pop();
        }

        string converter = val.ToString();

        if ( this.DecimalDigitPressed && !converter.Contains( "." ) )
        {
          converter += ".";
        }

        converter += digit.ToString();

        val = System.Convert.ToDecimal( converter );

        this.RpnEngine.Stack.Push( val );
        this.EnterPressed = false;
        this.DecimalDigitPressed = false;
      }

      this.ScrollBottomOfStackIntoView();
    }

    private void ScrollBottomOfStackIntoView()
    {
      this.Display.ScrollIntoView( this.Display.Items[ this.Display.Items.Count - 1 ] );
    }

    public void DecimalDigit( object sender, ExecutedRoutedEventArgs e )
    {
      this.DecimalDigitPressed = true;
    }

    public void Enter( object sender, ExecutedRoutedEventArgs e )
    {
      if ( this.EnterPressed )
      {
        this.RpnEngine.Stack.Push( this.RpnEngine.Stack.Peek() + 1 );
        this.RpnEngine.Stack.Pop();
        this.RpnEngine.Stack.Push( this.RpnEngine.Stack.Peek() );

      }
      else
      {
        this.EnterPressed = true;
        this.DecimalDigitPressed = false;
      }

      this.Display.ScrollIntoView( this.Display.Items[ this.Display.Items.Count - 1 ] );
    }

    public void AllClear( object sender, ExecutedRoutedEventArgs e )
    {
      this.RpnEngine.Stack.Clear();
      this.EnterPressed = false;
      this.DecimalDigitPressed = false;
    }

    public void Clear( object sender, ExecutedRoutedEventArgs e )
    {
      if ( this.RpnEngine.Stack.Count > 0 )
        this.RpnEngine.Stack.Pop();

      this.RpnEngine.Stack.Push( 0m );
      this.EnterPressed = false;
      this.DecimalDigitPressed = false;
    }

    public void Delete( object sender, ExecutedRoutedEventArgs e )
    {
      if ( this.RpnEngine.Stack.Count > 0 && this.EnterPressed == false )
      {
        decimal val = this.RpnEngine.Stack.Pop();

        string converter = val.ToString();

        if ( converter.Length == 1 )
        {
          converter = "0";
        }
        else
        {
          converter = converter.Substring( 0, converter.Length - 1 );
        }

        val = System.Convert.ToDecimal( converter );

        this.RpnEngine.Stack.Push( val );
      }
      else
      {
        this.Drop( null, null );
      }
    }

    public void Drop( object sender, ExecutedRoutedEventArgs e )
    {
      if ( this.RpnEngine.Stack.Count > 0 )
        this.RpnEngine.Stack.Pop();

      if ( this.RpnEngine.Stack.Count == 0 )
        this.RpnEngine.Stack.Clear();

      this.DecimalDigitPressed = false;
      this.EnterPressed = true;
    }

    public void InvertSign( object sender, ExecutedRoutedEventArgs e )
    {
      if ( this.RpnEngine.Stack.Count > 0 )
      {
        decimal val = this.RpnEngine.Stack.Pop();

        val *= -1;

        this.RpnEngine.Stack.Push( val );
      }

    }

    public void Swap( object sender, ExecutedRoutedEventArgs e )
    {
      if ( this.RpnStack.Count > 1 )
      {
        decimal bottom = this.RpnEngine.Stack.Pop();
        decimal top = this.RpnEngine.Stack.Pop();

        this.RpnEngine.Stack.Push( bottom );
        this.RpnEngine.Stack.Push( top );
      }

      this.DecimalDigitPressed = false;
      this.EnterPressed = true;
    }
    #endregion


  }
}
