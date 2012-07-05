using System;
using System.Windows.Input;

namespace RPNCalculator
{
  public class CalculatorCommands
  {
    private static RoutedUICommand add;
    private static RoutedUICommand subtract;
    private static RoutedUICommand multiply;
    private static RoutedUICommand divide;
    private static RoutedUICommand addDigit;
    private static RoutedUICommand decimalDigit;
    private static RoutedUICommand enter;
    private static RoutedUICommand clear;
    private static RoutedUICommand allClear;
    private static RoutedUICommand delete;
    private static RoutedUICommand drop;
    private static RoutedUICommand invertsign;
    private static RoutedUICommand swap;
    private static RoutedCommand copy;
    private static RoutedCommand paste;
    private static RoutedCommand getArgs;


    static CalculatorCommands()
    {
      add = new RoutedUICommand( "Add", "Add", typeof( CalculatorCommands ) );
      subtract = new RoutedUICommand( "Subtract", "Subtract", typeof( CalculatorCommands ) );
      multiply = new RoutedUICommand( "Multiply", "Multiply", typeof( CalculatorCommands ) );
      divide = new RoutedUICommand( "Divide", "Divide", typeof( CalculatorCommands ) );
      addDigit = new RoutedUICommand( "AddDigit", "AddDigit", typeof( CalculatorCommands ) );
      decimalDigit = new RoutedUICommand( "PressDecimalDigit", "PressDecimalDigit", typeof( CalculatorCommands ) );
      enter = new RoutedUICommand( "Enter", "Enter", typeof( CalculatorCommands ) );
      clear = new RoutedUICommand( "Clear", "Clear", typeof( CalculatorCommands ) );
      allClear = new RoutedUICommand( "AllClear", "AllClear", typeof( CalculatorCommands ) );
      delete = new RoutedUICommand( "Delete", "Delete", typeof( CalculatorCommands ) );
      drop = new RoutedUICommand( "Drop", "Drop", typeof( CalculatorCommands ) );
      invertsign = new RoutedUICommand( "InvertSign", "InvertSign", typeof( CalculatorCommands ) );
      swap = new RoutedUICommand( "Swap", "Swap", typeof( CalculatorCommands ) );
      copy = new RoutedCommand( "Copy", typeof( CalculatorCommands ) );
      paste = new RoutedCommand( "Paste", typeof( CalculatorCommands ) );
      getArgs = new RoutedCommand( "GetArgs", typeof( CalculatorCommands ) );
    }

    public static RoutedUICommand Add
    {
      get { return add; }
    }

    public static RoutedUICommand Subtract
    {
      get { return subtract; }
    }

    public static RoutedUICommand Multiply
    {
      get { return multiply; }
    }

    public static RoutedUICommand Divide
    {
      get { return divide; }
    }

    public static RoutedUICommand AddDigit
    {
      get { return addDigit; }
    }

    public static RoutedUICommand DecimalDigit
    {
      get { return decimalDigit; }
    }

    public static RoutedUICommand Enter
    {
      get { return enter; }
    }

    public static RoutedUICommand Clear
    {
      get { return clear; }
    }

    public static RoutedUICommand AllClear
    {
      get { return allClear; }
    }

    public static RoutedUICommand Delete
    {
      get { return delete; }
    }

    public static RoutedUICommand Drop
    {
      get { return drop; }
    }

    public static RoutedUICommand InvertSign
    {
      get { return invertsign; }
    }

    public static RoutedUICommand Swap
    {
      get { return swap; }
    }

    public static RoutedCommand Copy
    {
      get { return copy; }
    }

    public static RoutedCommand Paste
    {
      get { return paste; }
    }

    public static RoutedCommand GetArgs
    {
      get { return getArgs; }
    }

  }
}