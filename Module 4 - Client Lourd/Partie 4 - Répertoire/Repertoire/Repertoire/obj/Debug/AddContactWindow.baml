   M S B A M L   `   `   `  ����E  ARepertoire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Repertoire
Repertoire  5   	   !    Repertoire.AddContactWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Repertoire     5   	     � Title$  Ajouter un contact��5      $	��450��6(   $	��800��65   $	��450��6A   $	��800��6Q   $	��450��6`   $	��800��6p   ��5	      �� 5
   
    �� ImageSource$ Pictures/background.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $	��16* �6   �� 5      $	��42* �6   �� 5      $	��97* �6   �� 5      $	��97* �6   �� 5      $	��97* �6   �� 5      $	��20* �6   �� 5      $	��30* �6   �� 5      $	��21* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      .+�5   
   �� $��1��6   ���	#EBEBEBEE$��4��65   $
��0,10q�6I   $��8��6W   �� 5!   
   $��Ajouter un contact��6   
����������#4fc031$
��Bold"�6[   $��28(�6m    �� TextAlignment$ Center=�6{   $
��10,0q�6�   $��1��6�   $��4��6�   $��1��6�   �� 5#   
   $��	10,1,10,0q�6   $��2��6(   $��1��6<   $��2��6L   .+�5$      �� $	��Nom��6   ���#333333$
��Bold"�67   $��18(�6I   $
��10,0q�6W   $��30��6e   �� 5%      -   5         ��Name$ TextBox_Lastname��5%      $��18(�6O   $��	10,0,10,0q�6]   �� 5&      -   5         ��Name$$ TextBlock_LastnameErrorMessage��5&      
���<��$��15(�6U   $
��10,0q�6c   5'      �� 5)   
   $��	10,1,10,0q�6   $��2��6(   $��3��6<   $��2��6L   .+�5*      �� $��Prénom��6   ���#333333$
��Bold"�6:   $��18(�6L   $
��10,0q�6Z   $��30��6h   �� 5+      -   5        $ TextBox_Firstname��5+      $��18(�6Q   $��	10,0,10,0q�6_   �� 5,      -   5        $% TextBlock_FirstnameErrorMessage��5,      
���<��$��15(�6V   $
��10,0q�6d   5-      �� 5/   
   $
��10,0q�6   $��1��6#   $��3��63   $��2��6@   .+�50      �� $��N° Tel��6   ���#333333$
��Bold"�6:   $��18(�6L   $
��10,0q�6Z   $��30��6h   �� 51      -   5        $ TextBox_PhoneNumber��51      $��18(�6U   $��	10,0,10,0q�6c   �� 52      -   5        $' !TextBlock_PhoneNumberErrorMessage��52      
���<��$��15(�6X   $
��10,0q�6f   53      �� 55   
   $
��10,0q�6   $��3��6#   $��3��63   $��2��6@   .+�56      �� $
��Mail��6   ���#333333$
��Bold"�68   $��18(�6J   $
��10,0q�6X   $��30��6f   �� 57      -   5        $ TextBox_Mail��57      $��18(�6G   $
��10,0q�6U   �� 58      -   5        $  TextBlock_MailErrorMessage��58      $
��Wrap=�6<   
���<��$��15(�6e   $
��10,0q�6s   59      �� 5;   
   $
��10,0q�6   $��1��6#   $��4��63   $��4��6@   .+�5<      �� $��Adresse��6   ���#333333$
��Bold"�6;   $��18(�6M   $
��10,0q�6[   $��34��6i   �� 5=      -	   5        $ TextBox_Address��5=      $��18(�6/   $��	10,0,10,0q�6=   6P   �� 5>      -
   5        $# TextBlock_AddressErrorMessage��5>      
���<��$��15(�6T   $
��10,0q�6b   5?      �� 5A   
   -   5        $��Ajout Contact��5A      ���#4fc031$
��Bold"�6^   $��15(�6p   $��6��6~   $��1��6�   $��15,0,5,0q�6�   �� 5B   
   -   5        $ TextBlock_SuccesMessage��5B      $ Center=�65   
���"�"�$��2��6e   $
��Bold"�6y   $��18(�6�   $��6��6�   $��2��6�   �� 5C   
   -   5        $ TextBlock_FailureMessage��5C      $ Center=�66   
���<��$��2��6b   $��2��6v   $
��Bold"�6�   $��18(�6�   $��4��6�   $��0,87,0,0q�6�   $��2��6�   �� 5D   
   -   5        $��Retour au profil��5D      ���#4fc031$
��Bold"�6b   $��15(�6t   $��6��6�   $��4��6�   $
��10,0q�6�   5E      5F      