   M S B A M L   `   `   `  ����A  =Agenda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Agenda.ViewsAgenda.Views  5      -clr-namespace:Agenda.ModelsAgenda.Models  5      !    Agenda.Views.listBrokerPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Agenda.Views     5      .Modelsclr-namespace:Agenda.Models     5      -   5          N� Title$  liste des courtiers��5
       � 	Resources 5         brokersViewSource��%   &	        �� 5   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      $	��16* �6   �� 5      $��9* �6    � RowDefinitions 5   
   �� 5      $	��39* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��34* �6   �� 5      $	��27* �6   .+�5    
   �� ���	#EBEBEBEE$��8��6%   �� 5!   
   $��Liste des Courtiers��6   
�������
������$
��Bold"�6_   $��28(�6q    �� TextAlignment$ Center=�6   $��40��6�   $	��Top=�6�   $��2��6�   &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ brokersDataGrid��5"         AutoGenerateColumns .     EnableRowVirtualization . 	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�6   $��
10,7,10,10q�6�   $��7��6�   $��1��6�   ��6g   �� 
   Columns
 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      -   5        firstNameColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Prénom��5$   \      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *	firstName+6l     5%      -   5        lastNameColumn��$	 Nom��5%   Z   $ SizeToCells 6g    6=   �� *
lastName+6g     5&      -   5        
mailColumn��$
 Mail��5&   R   $ SizeToCells 6`    69   �� *mail+6`     5'      -   5        phoneNumberColumn��$ N° Tel��5'   `   $ SizeToCells 6p    6@   �� *phoneNumber+6p   5)      �� 5+   
   $��1��6   ���	#EB1E90FF$
��Left=�65   $	��450��6P   $	��Top=�6]   $	��288��6u   $��8��6�   �� 5,   
   $��Modifier��6   
�������
������$
��Bold"�6T   $��28(�6f   $ Center=�6t   $��1��6�   �� 5-   
   $
��Left=�6   $	��450��6,   $��8��69   $	��Top=�6J   $��5��6b   $��1��6l   ���	#FF0E40896|   �� 5.   
   -   5         ��Name$ TextBlock_idBroker��5.   k   $y�Hidden=�6W   ��6   ��  �� ElementName$ brokersDataGrid�� �� Path$ SelectedItem.id�6k   �� 50   
   $��1��6   $��1��6%   .+�51      �� $	��Nom��6   ���#333333$
��Bold"�67   $��12(�6I   $��Center=�6W   �� 52      -   5         ��Name$ TextBox_Lastname��52   _   $��12(�6y   $��	10,0,10,0q�6�   ��6   �� $ brokersDataGrid��$ SelectedItem.lastName�6�   �� 53      -	   5        $$ TextBlock_LastnameErrorMessage��53      
���<��$��11(�6U   $
��10,0q�6c   54      �� 56   
   $��1��6   $��2��6%   .+�57      �� $��Prénom��6   ���#333333$
��Bold"�6:   $��12(�6L   $��Center=�6Z   �� 58      -
   5        $ TextBox_Firstname��58   `   $��12(�6{   $��	10,0,10,0q�6�   ��6   �� $ brokersDataGrid��$ SelectedItem.firstName�6�   �� 59      -   5        $% TextBlock_FirstnameErrorMessage��59      
���<��$��11(�6V   $
��10,0q�6d   5:      �� 5<   
   $��1��6   $��3��6%   .+�5=      �� $
��Mail��6   ���#333333$
��Bold"�68   $��12(�6J   $��Center=�6X   �� 5>      -   5        $ TextBox_Mail��5>   [   $��12(�6q   $��	10,0,10,0q�6   ��6   �� $ brokersDataGrid��$ SelectedItem.mail�6�   �� 5?      -   5        $  TextBlock_MailErrorMessage��5?      
���<��$��11(�6Q   $
��10,0q�6_   5@      �� 5B   
   $��1��6   $��4��6%   .+�5C      �� $��N° Tel��6   ���#333333$
��Bold"�6:   $��12(�6L   $��Center=�6Z   �� 5D      -   5        $ TextBox_PhoneNumber��5D   b   $��12(�6   $��	10,0,10,0q�6�   ��6   �� $ brokersDataGrid��$ SelectedItem.phoneNumber�6�   �� 5E      -   5        $' !TextBlock_PhoneNumberErrorMessage��5E      
���<��$��11(�6X   $
��10,0q�6f   5F      �� 5H   
   -   5        $��
20,5,138,0q�5H      $��Enregistrer��6%   
���2͚�$��1��6t   $��6��6�   �� 5I   
   -   5        $��
155,5,10,0q�5I      $��	Supprimer��6%   
���<��$��1��6p   $��6��6�   �� 5J   
   -   5        $ TextBlock_SuccesMessage��5J      $ Center=�65   
���"�"�$
��Bold"�6e   $��Center=�6w   $��18(�6�   $��
10,33,10,0q�6�   $��28��6�   $��6��6�   $��1��6�   $��2��6�   5K      5L      