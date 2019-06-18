using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double? numberEntry;
        private double? firstNumber;
        private double? secondNumber;
        private string operatorCalc = "";
        private double result = 0;
        private bool decimalActivate = false;
        private double? beforeDecimal;
        private double? afterDecimal;
        private bool calculated = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Méthode au click sur un boutton d'un nombre
        private void Button_number_Click(object sender, RoutedEventArgs e)
        {
            var thisElement = sender as Button;//On stock l'élément clické
            //Si on est en décimal
            if (decimalActivate)
            {
                //Si afterDecimal est 0 ou null il seras égale à la valeur du boutton, sinon il auras la valeur du boutton sur la dizaine suivante 
                if (afterDecimal == 0 || afterDecimal == null)
                {
                    afterDecimal = int.Parse(thisElement.Content.ToString());
                }
                else
                {
                    afterDecimal = afterDecimal * 10 + int.Parse(thisElement.Content.ToString());
                }
                //On concaténe tout les parties du nombre décimal dans numberEntry
                numberEntry = double.Parse(beforeDecimal.ToString() + "," + afterDecimal.ToString());
            }
            //Sinon (Si on est pas en décimal)
            else
            {
                //Si numberEntry est 0 ou null il seras égale à la valeur du boutton, sinon il auras la valeur du boutton sur la dizaine suivante 
                if (numberEntry == 0 || numberEntry == null)
                {
                    numberEntry = int.Parse(thisElement.Content.ToString());
                }
                else
                {
                    numberEntry = numberEntry * 10 + int.Parse(thisElement.Content.ToString());
                }
            }
            //On affiche dans TextBlock_DisplayResult la saisie
            TextBlock_DisplayResult.Text = numberEntry.ToString();
        }

        //Méthode au click sur le boutton de la décimale
        private void Button_decimal_Click(object sender, RoutedEventArgs e)
        {
            //Si je suis pas en décimale
            if (decimalActivate == false)
            {
                //Je passe en décimale, je stock le nombre saisie dans beforeDecimal si le nombre saisie est null il sera mit a 0 et j'affiche un vigule en plus dans la zone TextBlock_OldCalc
                decimalActivate = true;
                if (numberEntry == null)
                {
                    TextBlock_OldCalc.Text += "0";
                    numberEntry = 0;
                }
                beforeDecimal = numberEntry;
            }
        }

        //Méthode au click sur un boutton d'opérateur
        private void Button_operator_Click(object sender, RoutedEventArgs e)
        {
            //Si on a saisie un nombre
            if (numberEntry != null || secondNumber != null)
            {
                var thisElement = sender as Button;//On stock l'élément clické
                //Si on a pas de premier nombre
                if (firstNumber == null)
                {
                    //On stock l'opérateur, on l'affiche dans la zone TextBlock_OldCalc puis le nombre saisi sera la valeur de firstNumber
                    operatorCalc = thisElement.Content.ToString();
                    firstNumber = numberEntry;
                    TextBlock_OldCalc.Text += firstNumber + operatorCalc;

                }
                //Sinon 'si on a déjà un premier chiffre
                else
                {
                    if (numberEntry != null)
                    {
                        if (calculated)
                        {
                            TextBlock_OldCalc.Text += operatorCalc;
                            calculated = false;
                        }
                        secondNumber = numberEntry;
                        //On vérifie qu'ona pas une division par zéro
                        if (!(operatorCalc == "/" && secondNumber == 0))
                        {
                            //On calcule le firstName avec le nameEntry en fonction de l'opérateur(si on a un firstname on a forcément un opérateur), firstNumber sera égale au résultat, on stock l'opérateur et on l'ajoute dans la zone TextBlock_OldCalc
                            CalculatedByOperator(operatorCalc);
                            firstNumber = result;
                            operatorCalc = thisElement.Content.ToString();
                            TextBlock_OldCalc.Text += secondNumber + operatorCalc;
                        }
                    }
                }
                //On es plus en décimal, on reset le number et le text de la zone TextBlock_DisplayResult
                decimalActivate = false;
                beforeDecimal = null;
                afterDecimal = null;
                numberEntry = null;
                TextBlock_DisplayResult.Text = numberEntry.ToString();
            }
        }

        //Méthode au click sur un boutton d'égale
        private void Button_calculate_Click(object sender, RoutedEventArgs e)
        {
            if (numberEntry != null)
            {
                secondNumber = numberEntry;
            }
            //Si on a saisie unnombre
            if (secondNumber != null)
            {
                //Si on divise pas par Zéro on calcule
                if (!(operatorCalc == "/" && numberEntry == 0))
                {
                    CalculatedByOperator(operatorCalc);
                }
                calculated = true;
                //Ondésactive les dacimales
                decimalActivate = false;
                beforeDecimal = null;
                afterDecimal = null;
                numberEntry = null;
                //On affiche le calcule dans TextBlock_OldCalc
                TextBlock_OldCalc.Text = firstNumber.ToString() + operatorCalc + secondNumber;
                //Firstname égale au résultat
                firstNumber = result;
                TextBlock_DisplayResult.Text = result.ToString();
            }
        }

        //Méthode au click sur le boutton reset Total
        private void Button_reset_Click(object sender, RoutedEventArgs e)
        {
            numberEntry = null;
            firstNumber = null;
            secondNumber = null;
            decimalActivate = false;
            beforeDecimal = null;
            afterDecimal = null;
            operatorCalc = "";
            result = 0;
            TextBlock_OldCalc.Text = "";
            TextBlock_DisplayResult.Text = "";
        }

        //Méthode au click sur le boutton reset saisie
        private void Button_resetEntry_Click(object sender, RoutedEventArgs e)
        {
            decimalActivate = false;
            beforeDecimal = null;
            afterDecimal = null;
            numberEntry = null;
            TextBlock_DisplayResult.Text = "";
        }

        //Méthode du calcule en fontion de l'opérateur
        private void CalculatedByOperator(string operatorForCalc)
        {
            if (operatorForCalc == "+")
            {
                result = double.Parse(firstNumber.ToString()) + double.Parse(secondNumber.ToString());
            }
            else if (operatorForCalc == "-")
            {
                result = double.Parse(firstNumber.ToString()) - double.Parse(secondNumber.ToString());
            }
            else if (operatorForCalc == "*")
            {
                result = double.Parse(firstNumber.ToString()) * double.Parse(secondNumber.ToString());
            }
            else if (operatorForCalc == "/")
            {
                result = double.Parse(firstNumber.ToString()) / double.Parse(secondNumber.ToString());
            }
        }






        ////Quand on click sur 0
        //private void Button_number0_Click(object sender, RoutedEventArgs e)
        //{
        //    //Si le nombre saisie est différent de 0 on ajoute un zéro au text de l'élément textBlock_displayResult puis à numberEntry
        //    if (numberEntry != "0")
        //    {
        //        textBlock_displayResult.Text += 0;
        //        numberEntry += 0;
        //    }
        //}

        ////Quand on click sur 1
        //private void Button_number1_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "1";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 1;//On ajoute 1 au text de l'élément textBlock_displayResult
        //    }
        //    //Si numberEntry est égale à 0 numberEntry sera égale à 1 sinon on ajoute 1 à numberEntry (Pour éviter que numberEntry sois égale à 01 par exemple)
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "1";
        //    }
        //    else
        //    {
        //        numberEntry += 1;
        //    }
        //}

        ////Quand on click sur 2
        //private void Button_number2_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "2";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 2;
        //    }
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "2";
        //    }
        //    else
        //    {
        //        numberEntry += 2;
        //    }
        //}

        ////Quand on click sur 3
        //private void Button_number3_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "3";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 3;
        //    }
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "3";
        //    }
        //    else
        //    {
        //        numberEntry += 3;
        //    }
        //}

        ////Quand on click sur 4
        //private void Button_number4_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "4";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 4;
        //    }
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "4";
        //    }
        //    else
        //    {
        //        numberEntry += 4;
        //    }
        //}

        ////Quand on click sur 5
        //private void Button_number5_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "5";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 5;
        //    }
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "5";
        //    }
        //    else
        //    {
        //        numberEntry += 5;
        //    }
        //}

        ////Quand on click sur 6
        //private void Button_number6_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "6";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 6;
        //    }
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "6";
        //    }
        //    else
        //    {
        //        numberEntry += 6;
        //    }
        //}

        ////Quand on click sur 7
        //private void Button_number7_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "7";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 7;
        //    }
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "7";
        //    }
        //    else
        //    {
        //        numberEntry += 7;
        //    }
        //}

        ////Quand on click sur 8
        //private void Button_number8_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "8";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 8;
        //    }
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "8";
        //    }
        //    else
        //    {
        //        numberEntry += 8;
        //    }
        //}

        ////Quand on click sur 9
        //private void Button_number9_Click(object sender, RoutedEventArgs e)
        //{
        //    if (newCalc)
        //    {
        //        textBlock_displayResult.Text = "9";
        //        newCalc = false;
        //    }
        //    else
        //    {
        //        textBlock_displayResult.Text += 9;
        //    }
        //    if (numberEntry == "0")
        //    {
        //        numberEntry = "9";
        //    }
        //    else
        //    {
        //        numberEntry += 9;
        //    }
        //}

        ////Quand on click sur +
        //private void Button_operatorAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    if (textBlock_displayResult.Text != "" && newCalc == false)
        //    {
        //        //On stock le dernier caractère du text de textBlock_displayResult et on fais une condition si se caractère est différent de + - * ou /
        //        String displayResult = textBlock_displayResult.Text;
        //        char displayResultLastElement = displayResult[displayResult.Length - 1];
        //        if (displayResultLastElement.ToString() != "+" && displayResultLastElement.ToString() != "-" && displayResultLastElement.ToString() != "*" && displayResultLastElement.ToString() != "/" && numberEntry != "")
        //        {
        //            //Si on à pas d'opérateur
        //            if (operatorCalc == "")
        //            {
        //                operatorCalc = "+";//On stock l'opérateur +
        //                newCalc = false;
        //                if (result == null)
        //                {
        //                    result = float.Parse(numberEntry);//On attribut au resultat le nombre saisie                         
        //                }
        //                //Sinon (Si on a déjà un résultat)
        //                else
        //                {
        //                    calculatedByOperator(operatorCalc);//On lance notre méthode calculatedByOperator avec le paramètre operatorCalc
        //                }
        //            }
        //            //Sinon (si on à déjà un opérateur)
        //            else
        //            {
        //                calculatedByOperator(operatorCalc);//On lance notre méthode calculatedByOperator avec le paramètre operatorCalc
        //                operatorCalc = "+";//On stock l'opérateur +
        //            }
        //            textBlock_displayResult.Text += "+";//On ajoute + a la fin du text de textBlock_displayResult
        //            numberEntry = "0";//On réinitialize le nombre saisie
        //        }
        //    }
        //}

        ////Quand on click sur -
        //private void Button_operatorSubstract_Click(object sender, RoutedEventArgs e)
        //{
        //    if (textBlock_displayResult.Text != "" && newCalc == false)
        //    {
        //        String displayResult = textBlock_displayResult.Text;
        //        char displayResultLastElement = displayResult[displayResult.Length - 1];
        //        if (displayResultLastElement.ToString() != "+" && displayResultLastElement.ToString() != "-" && displayResultLastElement.ToString() != "*" && displayResultLastElement.ToString() != "/" && numberEntry != "")
        //        {
        //            if (operatorCalc == "")
        //            {
        //                operatorCalc = "-";
        //                newCalc = false;
        //                if (result == null)
        //                {
        //                    result = 0 + float.Parse(numberEntry);
        //                }
        //                else
        //                {
        //                    calculatedByOperator(operatorCalc);
        //                }
        //            }
        //            else
        //            {
        //                calculatedByOperator(operatorCalc);
        //                operatorCalc = "-";
        //            }
        //            textBlock_displayResult.Text += "-";
        //            numberEntry = "0";
        //        }
        //    }
        //}

        ////Quand on click sur *
        //private void Button_operatorMultiply_Click(object sender, RoutedEventArgs e)
        //{
        //    if (textBlock_displayResult.Text != "" && newCalc == false)
        //    {
        //        String displayResult = textBlock_displayResult.Text;
        //        char displayResultLastElement = displayResult[displayResult.Length - 1];
        //        if (displayResultLastElement.ToString() != "+" && displayResultLastElement.ToString() != "-" && displayResultLastElement.ToString() != "*" && displayResultLastElement.ToString() != "/" && numberEntry != "")
        //        {
        //            if (operatorCalc == "")
        //            {
        //                operatorCalc = "*";
        //                newCalc = false;
        //                if (result == null)
        //                {
        //                    result = 0 + float.Parse(numberEntry);
        //                }
        //                else
        //                {
        //                    calculatedByOperator(operatorCalc);
        //                }
        //            }
        //            else
        //            {
        //                calculatedByOperator(operatorCalc);
        //                operatorCalc = "*";
        //            }
        //            textBlock_displayResult.Text += "*";
        //            numberEntry = "0";
        //        }
        //    }
        //}

        ////Quand on click sur /
        //private void Button_operatorDivid_Click(object sender, RoutedEventArgs e)
        //{
        //    if (textBlock_displayResult.Text != "" && newCalc == false)
        //    {
        //        String displayResult = textBlock_displayResult.Text;
        //        char displayResultLastElement = displayResult[displayResult.Length - 1];
        //        if (displayResultLastElement.ToString() != "+" && displayResultLastElement.ToString() != "-" && displayResultLastElement.ToString() != "*" && displayResultLastElement.ToString() != "/" && numberEntry != "")
        //        {
        //            if (operatorCalc == "")
        //            {
        //                operatorCalc = "/";
        //                if (result == null)
        //                {
        //                    result = 0 + float.Parse(numberEntry);
        //                }
        //                else
        //                {
        //                    calculatedByOperator(operatorCalc);
        //                }
        //            }
        //            else
        //            {
        //                calculatedByOperator(operatorCalc);
        //                operatorCalc = "/";
        //            }
        //            textBlock_displayResult.Text += "/";
        //            numberEntry = "0";
        //        }
        //    }
        //}

        ////Quand on click sur =
        //private void Button_calculate_Click(object sender, RoutedEventArgs e)
        //{
        //    if (textBlock_displayResult.Text != "")
        //    {
        //        String displayResult = textBlock_displayResult.Text;
        //        char displayResultLastElement = displayResult[displayResult.Length - 1];
        //        if (displayResultLastElement.ToString() != "+" && displayResultLastElement.ToString() != "-" && displayResultLastElement.ToString() != "*" && displayResultLastElement.ToString() != "/" && operatorCalc != "")
        //        {
        //            calculatedByOperator(operatorCalc);
        //            operatorCalc = "";
        //            numberEntry = "0";
        //            result = null;
        //            newCalc = true;
        //        }
        //    }


        //}

        ////Quand on click sur reset
        //private void Button_reset_Click(object sender, RoutedEventArgs e)
        //{
        //    result = null;
        //    numberEntry = "0";
        //    operatorCalc = "";
        //    textBlock_oldCalc.Text = "";
        //    textBlock_displayResult.Text = "";
        //    newCalc = false;
        //}

        ////Méthode de calcule
        //public void calculatedByOperator(string operatorForCalc)
        //{
        //    if (operatorForCalc == "+")
        //    {
        //        result = result + float.Parse(numberEntry);
        //    }
        //    else if (operatorForCalc == "-")
        //    {
        //        result = result - float.Parse(numberEntry);
        //    }
        //    else if (operatorForCalc == "*")
        //    {
        //        result = result * float.Parse(numberEntry);
        //    }
        //    else if (operatorForCalc == "/")
        //    {
        //        result = result / float.Parse(numberEntry);
        //    }
        //    textBlock_oldCalc.Text = textBlock_displayResult.Text;
        //    textBlock_displayResult.Text = result.ToString();
        //}


    }

}
