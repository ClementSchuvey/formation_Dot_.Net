   M S B A M L   `   `   `  ����A  =Agenda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Agenda.ViewsAgenda.Views  5      -clr-namespace:Agenda.ModelsAgenda.Models  5      #    Agenda.Views.listCustomerPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Agenda.Views     5      .Modelsclr-namespace:Agenda.Models     5      -   5          N� Title$  Liste des clients��5
       � 	Resources 5         customersViewSource��%   &	        �� 5   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      $	��16* �6   �� 5      $��9* �6    � RowDefinitions 5   
   �� 5      $	��39* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��34* �6   �� 5      $	��27* �6   .+�5    
   �� ���	#EBEBEBEE$��8��6%   �� 5!   
   $��Liste des clients��6   
����������#4fc031$
��Bold"�6Z   $��28(�6l    �� TextAlignment$ Center=�6z   $��40��6�   $	��Top=�6�   $��2��6�   &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ customersDataGrid��5"         AutoGenerateColumns .     EnableRowVirtualization . 	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�6�   $��
10,7,10,10q�6�   $��7��6�   $��1��6�   ��6i   �� 
   Columns
 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      -   5        firstNameColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Prénom��5$   \      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *	firstName+6l     5%      -   5        lastNameColumn��$	 Nom��5%   Z   $ SizeToCells 6g    6=   �� *
lastName+6g     5&      -   5        
mailColumn��$
 Mail��5&   R   $ SizeToCells 6`    69   �� *mail+6`     5'      -   5        phoneNumberColumn��$ n° Tel��5'   `   $ SizeToCells 6p    6@   �� *phoneNumber+6p     5(      -   5        budgetColumn��$ Budget��5(   V   $ SizeToCells 6f    6;   �� *budget+6f   5*      �� 5,   
   $��1��6   ���	#EB4fc031$
��Left=�65   $	��450��6P   $	��Top=�6]   $	��288��6u   $��8��6�   �� 5-   
   $��Modifier��6   
����������#4fc031$
��Bold"�6Q   $��28(�6c   $ Center=�6q   $��1��6�   �� 5.   
   $
��Left=�6   $	��450��6,   $��8��69   $	��Top=�6J   $��5��6b   $��1��6l   ���	#FF0E89196|   �� 5/   
   -   5         ��Name$ TextBlock_idCustomer��5/   m   $y�Hidden=�6Y   ��6   ��  �� ElementName$ customersDataGrid�� �� Path$ SelectedItem.id�6m   �� 51   
   $��1��6   $��1��6%   .+�52      �� $	��Nom��6   ���#333333$
��Bold"�67   $��12(�6I   $��Center=�6W   �� 53      -	   5         ��Name$ TextBox_Lastname��53   a   $��12(�6{   $��	10,0,10,0q�6�   ��6   �� $ customersDataGrid��$ SelectedItem.lastName�6�   �� 54      -
   5        $$ TextBlock_LastnameErrorMessage��54      
���<��$��11(�6U   $
��10,0q�6c   55      �� 57   
   $��1��6   $��2��6%   .+�58      �� $��Prénom��6   ���#333333$
��Bold"�6:   $��12(�6L   $��Center=�6Z   �� 59      -   5        $ TextBox_Firstname��59   b   $��12(�6}   $��	10,0,10,0q�6�   ��6   �� $ customersDataGrid��$ SelectedItem.firstName�6�   �� 5:      -   5        $% TextBlock_FirstnameErrorMessage��5:      
���<��$��11(�6V   $
��10,0q�6d   5;      �� 5=   
   $��1��6   $��3��6%   .+�5>      �� $
��Mail��6   ���#333333$
��Bold"�68   $��12(�6J   $��Center=�6X   �� 5?      -   5        $ TextBox_Mail��5?   ]   $��12(�6s   $��	10,0,10,0q�6�   ��6   �� $ customersDataGrid��$ SelectedItem.mail�6�   �� 5@      -   5        $  TextBlock_MailErrorMessage��5@      
���<��$��11(�6Q   $
��10,0q�6_   5A      �� 5C   
   $��1��6   $��4��6%   .+�5D      �� $��N° Tel��6   ���#333333$
��Bold"�6:   $��12(�6L   $��Center=�6Z   �� 5E      -   5        $ TextBox_PhoneNumber��5E   d   $��12(�6�   $��	10,0,10,0q�6�   ��6   �� $ customersDataGrid��$ SelectedItem.phoneNumber�6�   �� 5F      -   5        $' !TextBlock_PhoneNumberErrorMessage��5F      
���<��$��11(�6X   $
��10,0q�6f   5G      �� 5I   
   $��1��6   $��5��6%   .+�5J      �� $��Budget��6   ���#333333$
��Bold"�6:   $��12(�6L   $��Center=�6Z   �� 5K      -   5        $ TextBox_Budget��5K   Z   $��12(�6r   $
��10,0q�6�   ��6   �� *SelectedItem.budget+$ customersDataGrid��6�   �� 5L      -   5        $" TextBlock_BudgetErrorMessage��5L      
���<��$��11(�6S   $
��10,0q�6a   5M      �� 5O   
   -   5        $��
20,5,138,0q�5O      $��Enregistrer��6%   
���2͚�$��1��6v   $��6��6�   �� 5P   
   -   5        $��
155,5,10,0q�5P      $��	Supprimer��6%   
���<��$��1��6r   $��6��6�   �� 5Q   
   -   5        $ TextBlock_SuccesMessage��5Q      $ Center=�65   
���"�"�$
��Bold"�6e   $��Center=�6w   $��18(�6�   $��
10,33,10,0q�6�   $��28��6�   $��6��6�   $��1��6�   $��2��6�   5T      5U      