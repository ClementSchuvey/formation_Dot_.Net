   M S B A M L   `   `   `  ����E  ARepertoire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Repertoire
Repertoire  5   	   "    Repertoire.ListContactWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Repertoire     5   	     � Title$  Liste contacts��5   	   $	��450��6    $	��800��6-   $	��800��69   $	��450��6H   $	��800��6X   ��5	      �� 5
   
    �� ImageSource$ Pictures/background.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $	��16* �6   �� 5      $	��40* �6   �� 5      $	��44* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $	��49* �6   �� 5      $	��50* �6   �� 5      $	��21* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      .+�5   
   �� $��1��6   ���	#EBEBEBEE$��4��65   $
��0,10q�6I   $��8��6W   �� 5!   
   $��Liste des contacts��6   
����������#4fc031$
��Bold"�6[   $��28(�6m    �� TextAlignment$ Center=�6{   $
��10,0q�6�   $��1��6�   $��4��6�   $��1��6�   &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ listContactDataGrid��5"         AutoGenerateColumns .     EnableRowVirtualization . $��
10,10,10,0q�6�   $��4��6�   $��2��6�   $��1��6�   $��4��6�   $	��283��6�   $	��Top=�6�   ��6k   ��    Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn	   Header$		 Nom��6B   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 SizeToCells 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
Lastname+6O     5%      $	 Prénom��6C   $
 SizeToCells 6S    6%   �� *	Firstname+6S     5&      $
	 Mail��6>   $
 SizeToCells 6L    6%   �� *Mail+6L     5'      $	 N° Tel��6E   $
 SizeToCells 6U    6%   �� *PhoneNumber+6U     5(      $	 Adress��6A   $
 SizeToCells 6Q    6%   �� *	Address+6Q   5*      �� 5+   
   -   5        $��Retour au profil��5+      ���#4fc031$
��Bold"�6b   $��15(�6t   $��6��6�   $��4��6�   $
��10,0q�6�   5,      5-      