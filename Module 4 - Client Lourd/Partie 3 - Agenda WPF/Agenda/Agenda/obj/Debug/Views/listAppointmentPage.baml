   M S B A M L   `   `   `  ����A  =Agenda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Agenda.ViewsAgenda.Views  5      -clr-namespace:Agenda.ModelsAgenda.Models  5      &     Agenda.Views.listAppointmentPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Agenda.Views     5      .Modelsclr-namespace:Agenda.Models     5      -   5          N� Title$  Liste des RDV��5
       � 	Resources 5         appointmentsViewSource��%   &	        �� 5   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      $	��32* �6   �� 5      $��9* �6   �� 5      $��9* �6    � RowDefinitions 5   
   �� 5      $	��39* �6   �� 5      $	��80* �6   �� 5      $	��80* �6   �� 5      $
��100* �6   �� 5      $	��80* �6   �� 5      $	��44* �6   �� 5      $	��27* �6   .+�5!   
   �� ���	#EBEBEBEE$��7��6%   �� 5"   
   $��Liste des Rendez-vous��6   
�������
��� ���$
��Bold"�6]   $��28(�6o    �� TextAlignment$ Center=�6}   $��40��6�   $	��Top=�6�   $��2��6�   &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ appointmentDataGrid��5#         AutoGenerateColumns .     EnableRowVirtualization . 	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�6�   $��
10,7,10,10q�6�   $��6��6�   $��1��6�   ��6k   �� 
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      -   5        customerColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Client��5%   d      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *customers.fullName+6t     5&      -   5        brokerColumn��$ Courtier��5&   `   $ SizeToCells 6r    6;   �� *brokers.fullName+6r     5'      -   5        
dateColumn��$
 Date��5'   u   $ SizeToCells 6�    69   �� *
dateHour+ �� StringFormat$ dd/MM/yyyy HH:mm��6�     5(      -   5        subjectColumn��$ Sujet��5(   X   $ SizeToCells 6g    6<   �� *	subject+6g   5*      �� 5-   
   $��1��6   ���	#EBFFA500$
��Left=�65   $	��450��6P   $	��Top=�6]   $	��288��6u   $��7��6�   $��2��6�   �� 5.   
   $��Modifier��6   
�������
��� ���$
��Bold"�6P   $��28(�6b   $ Center=�6p   $��1��6�   $��2��6�   �� 5/   
   $
��Left=�6   $	��450��6,   $��7��69   $	��Top=�6J   $��5��6b   $��1��6l   ���	#FFB477086|   �� 50   
   -   5         ��Name$ TextBlock_idAppointment��50   j   $y�Hidden=�6V   ��6   �� *SelectedItem.id+ �� ElementName$ appointmentDataGrid��6j   �� 52   
   $��5,0,0,0q�6   $��1��6&   $��1��66   .+�53      �� $��Client��6   ���#333333$
��Bold"�6:   $��15(�6L   $
��10,0q�6Z   $��30��6h   �� 54      -   5         ��Name$ ComboBox_Customer��54       �� DisplayMemberPath$ fullName��6�   $��12(�6�   $��	10,0,10,0q�6�    �� SelectedValue 6   �� $ appointmentDataGrid�� �� Path$  SelectedValue.id_customers� �� Mode$ TwoWay=���6�   �� 6�   �� 55      -	   5        $$ TextBlock_CustomerErrorMessage��55      
���<��$��11(�6U   $
��10,0q�6c   56      �� 58   
   $��2��6   $��1��6%   .+�59      �� $��Courtier��6   ���#333333$
��Bold"�6<   $��15(�6N   $
��10,0q�6\   $��30��6j   �� 5:      -
   5        $ ComboBox_Broker��5:   p   $ fullName��6�   $��12(�6�   $��	10,0,10,0q�6�    6   �� $ appointmentDataGrid��$ SelectedValue.id_brokers���6�   �� 6�   �� 5;      -   5        $" TextBlock_BrokerErrorMessage��5;      
���<��$��11(�6S   $
��10,0q�6a   5<      �� 5>   
   $��5,0,0,0q�6   $��1��6&   $��2��66   $��2��6C   .+�5?      �� $��Date du RDV��6   ���#333333$
��Bold"�6?   $��15(�6Q   $
��10,0q�6_   $��30��6m   (  "System.Windows.Controls.DatePicker  5@      -   5          Name$ DatePicker_Date��5@   o   $��12(�6�   $��	10,0,10,0q�6�      SelectedDate 6   �� $ appointmentDataGrid��$ SelectedValue.dateHour�6�   �� 5A      -   5        $  TextBlock_DateErrorMessage��5A      
���<��$��11(�6Q   $
��10,0q�6_   5B      �� 5D   
   $
��10,0q�6   $��1��6#   $��3��63   $��2��6@   .+�5E      �� $��Heure du RDV��6   ���#333333$
��Bold"�6@   $��15(�6R   $
��10,0q�6`   $��30��6n   � 5F      .+�5G      �� -   5         ��Name$ TextBox_Hour��5G   �   $��12(�6�   $	��100��6�   ��6   �� $ appointmentDataGrid��$ SelectedValue.dateHour�$ OneWay=�$ HH��6�   �� 5H      $��H��6   $��12(�6%   �� 5I      -   5        $ TextBox_Minute��5I   {   $��12(�6�   $	��100��6�   $��	40, 0,0,0q�6�   ��6   �� $ appointmentDataGrid��$" SelectedValue.timeSlotMinute�$ OneWay=�6�   �� 5J      $��m��6   $��12(�6%   5K      �� 5L      -   5        $  TextBlock_HourErrorMessage��5L      $
��Wrap=�6<   
���<��$��11(�6e   $
��10,0q�6s   �� 5M      -   5        $" TextBlock_MinuteErrorMessage��5M      $
��Wrap=�6>   
���<��$��11(�6g   $
��10,0q�6u   5N      �� 5P   
   $
��10,0q�6   $��1��6#   $��4��63   $��2��6@   .+�5Q      �� $��Sujet��6   ���#333333$
��Bold"�69   $��15(�6K   $
��10,0q�6Y   $��34��6g   �� 5R      -   5        $ TextBox_Subject��5R   b   $��12(�6{   $��	10,0,10,0q�6�   ��6   �� $ appointmentDataGrid��$ SelectedItem.subject�6�   �� 5S      -   5        $# TextBlock_SubjectErrorMessage��5S      
���<��$��11(�6T   $
��10,0q�6b   5T      �� 5V   
   -   5        $��10,4,4,1q�5V   1   $��Enregistrer��6C   
���2͚�$��1��6r   $��5��6�   �� 5W   
   -   5        $��	10,5,12,0q�5W   3   $��	Supprimer��6F   
���<��$��2��6o   $��5��6   �� 5X   
   -   5        $ TextBlock_SuccesMessage��5X      $ Center=�65   
���"�"�$
��Bold"�6e   $��Center=�6w   $��18(�6�   $��
10,43,10,0q�6�   $��28��6�   $��5��6�   $��1��6�   $��2��6�   $��2��6�   5Y      5Z      