using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RPNCalculator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private RPNCalculatorViewModel RpnCalcViewModel;

    public MainWindow()
    {
      InitializeComponent();

      RpnCalcViewModel = new RPNCalculatorViewModel( this.DisplayListBox );
      mainDockPanel.DataContext = RpnCalcViewModel;

      SetupCommandBindings();
    }

    private void SetupCommandBindings()
    {
      CommandBinding cbAddDigit = new CommandBinding( CalculatorCommands.AddDigit );
      cbAddDigit.Executed += RpnCalcViewModel.AddDigit;
      this.CommandBindings.Add( cbAddDigit );

      CommandBinding cbDecimalDigit = new CommandBinding( CalculatorCommands.DecimalDigit );
      cbDecimalDigit.Executed += RpnCalcViewModel.DecimalDigit;
      this.CommandBindings.Add( cbDecimalDigit );

      CommandBinding cbAdd = new CommandBinding( CalculatorCommands.Add );
      cbAdd.Executed += RpnCalcViewModel.Add;
      this.CommandBindings.Add( cbAdd );

      CommandBinding cbSubtract = new CommandBinding( CalculatorCommands.Subtract );
      cbSubtract.Executed += RpnCalcViewModel.Subtract;
      this.CommandBindings.Add( cbSubtract );

      CommandBinding cbMultiply = new CommandBinding( CalculatorCommands.Multiply );
      cbMultiply.Executed += RpnCalcViewModel.Multiply;
      this.CommandBindings.Add( cbMultiply );

      CommandBinding cbDivide = new CommandBinding( CalculatorCommands.Divide );
      cbDivide.Executed += RpnCalcViewModel.Divide;
      this.CommandBindings.Add( cbDivide );

      CommandBinding cbEnter = new CommandBinding( CalculatorCommands.Enter );
      cbEnter.Executed += RpnCalcViewModel.Enter;
      this.CommandBindings.Add( cbEnter );

      CommandBinding cbAllClear = new CommandBinding( CalculatorCommands.AllClear );
      cbAllClear.Executed += RpnCalcViewModel.AllClear;
      this.CommandBindings.Add( cbAllClear );

      CommandBinding cbClear = new CommandBinding( CalculatorCommands.Clear );
      cbClear.Executed += RpnCalcViewModel.Clear;
      this.CommandBindings.Add( cbClear );

      CommandBinding cbDelete = new CommandBinding( CalculatorCommands.Delete );
      cbDelete.Executed += RpnCalcViewModel.Delete;
      this.CommandBindings.Add( cbDelete );

      CommandBinding cbDrop = new CommandBinding( CalculatorCommands.Drop );
      cbDrop.Executed += RpnCalcViewModel.Drop;
      this.CommandBindings.Add( cbDrop );

      CommandBinding cbInvertSign = new CommandBinding( CalculatorCommands.InvertSign );
      cbInvertSign.Executed += RpnCalcViewModel.InvertSign;
      this.CommandBindings.Add( cbInvertSign );

      CommandBinding cbSwap = new CommandBinding( CalculatorCommands.Swap );
      cbSwap.Executed += RpnCalcViewModel.Swap;
      this.CommandBindings.Add( cbSwap );

      CommandBinding cbCopy = new CommandBinding( CalculatorCommands.Copy );
      cbCopy.Executed += RpnCalcViewModel.Copy;
      this.CommandBindings.Add( cbCopy );

      CommandBinding cbPaste = new CommandBinding( CalculatorCommands.Paste );
      cbPaste.Executed += RpnCalcViewModel.Paste;
      this.CommandBindings.Add( cbPaste );

      CommandBinding cbGetArgs = new CommandBinding( CalculatorCommands.GetArgs );
      cbGetArgs.Executed += RpnCalcViewModel.GetArgsAndPushOntoStack;
      this.CommandBindings.Add( cbGetArgs );
    }
  }
}
