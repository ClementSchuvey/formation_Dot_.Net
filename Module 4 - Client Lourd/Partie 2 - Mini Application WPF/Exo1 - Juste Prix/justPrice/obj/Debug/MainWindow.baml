   M S B A M L   `   `   `  ����D  @justPrice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:justPrice	justPrice  5   	       justPrice.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   #localclr-namespace:justPrice  5   	     � Title$  
Juste Prix��5	   	   $	��600��6   $
��1000��6)   $	��600��66   $
��1000��6F   $	��600��6V   $
��1000��6f    � Icon$ Pictures/WindowsIcon.ico��6v   .��5
      � $	��982��6   .+�5   
   �� "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ Pictures/Background.jpg��6   �� 5   
   -   5         ��Name$ StackPanel_Home��5      $��2��6/   .+�5      � $	��570��6    � RowDefinitions 5      �� 5      $	��10* �6$   �� 5      $	��20* �6$   �� 5      $��8* �6$   �� 5      $	��19* �6$   .+�5      �� $��
Juste Prix��6    �� TextAlignment$ Center=�6.   
����� �
�������$��1��6x   $	��130(�6�    �� 
LineHeight$ 36��6�   �� 5      -   5         ��Name$ Button_Play��5      $��JOUER��6H   $��1��6X      Button_Play#��[  6e   $��	0,192,0,0q�6�   $��2��6�   5      5      �� 5   
   -   5        $! StackPanel_ChoiceDifficulty��5      $y�Hidden=�6:   $��2��6N   .+�5      � $	��570��6   .+�5      �� $��Choisir la difficulté��6   $��	0,0,0,502q�69   $��50(�6L   $ Center=�6Z   
�������$
��Bold"�6�   
����� �6�   �� 5      -   5        $ Button_DifficultyEasy��5      
 � Tag$ 1��6^   $��Facile��6f   $��10,134,815,375q�6w     Button_Validate#��[ 6�   �� 5      -   5        $ Button_DifficultyNormal��5      $ 2��6`   $��Normal��6h   $��172,134,653,375q�6y   #��[ 6�   �� 5      -   5        $ Button_DifficultyHard��5      $ 3��6^   $��	Difficile��6f   $��334,134,491,375q�6z   #��[ 6�   �� 5       -   5        $ Button_DifficultyExtrem��5       $ 4��6`   $��Extrême��6h   $��496,134,329,375q�6z   #��[ 6�   �� 5!      -   5        $ Button_DifficultyLucky��5!      $ 5��6_   $��Chanceux��6g   $��658,133,167,375q�6z   #��[ 6�   �� 5"      -	   5        $ Button_DifficultyCustom��5"      $ 6��6`   $��Personnalié��6h   $��820,134,10,374q�6~   #��[ 6�   �� 5#      -
   5        	 ��Name$$	 TextBlock_NameDifficultyChoice��5#      $��45(�6D   $��0,217,10,283q�6R   $ Center=�6h   $
��Bold"�6   �� 5$      $��Nombre d'essais��6   $��30(�63   $��0,287,10,233q�6A   $ Center=�6W   �� 5%      -   5        $	 TextBlock_NumberTryChoice��5%      $��0��6?   $��30(�6H   $��10,329,10,191q�6V   $ Center=�6m   �� 5&      -   5        
 ��Name$
 TextBox_NumberTryChoice��5&      $y�Hidden=�6;   $��0��6O   $��30(�6X   $��10,329,10,191q�6f    �� TextAlignment$ Center=�6}   �� 5'      $��Prix comprit entre 1 et ��6   $��30(�6<   $��10,384,10,136q�6J   $ Center=�6a   �� 5(      -   5        $	 TextBlock_MaxPriceChoice��5(      $��0��6>   $��30(�6G   $��10,425,10,95q�6U   $ Center=�6k   �� 5)      -   5        $
 TextBox_MaxPriceChoice��5)      $y�Hidden=�6:   $��0��6N   $��30(�6W   $ Center=�6e   $��10,422,10,98q�6|   �� 5*      -   5        $$ Button_ValidateChoiceDificulty��5*      $��Valider��6n   #��[ 6�   $��300,472,300,42q�6�   �� 5+      -   5        $&	  TextBlock_ErrorChoiceDiffictulty��5+      $��10,528,10,0q�6F   $ Center=�6[   $��25(�6r   
���<��6�   5,      5-      �� 5/   
   -   5        $ StackPanel_Game��5/      $y�Hidden=�6.   .+�50      � $	��570��6    � ColumnDefinitions 51      �� 52      $��3* �6'   �� 53      .+�56      �� $��1��6   
����� �6,   �� 57      
����� �$
��Left=�6+   $	��570��6F   $��	726,0,0,0q�6S   $	��Top=�6f   $��11��6~   $��2��6�   �� 58      $��10,10,10,480q�6   $��1��63   .+�59      �� $��VICTOIRE��6    
�������$��25(�6H   $ Center=�6V   $
��Bold"�6m   �� 5:      -   5        $	 TextBlock_NumberVictory��5:       $��0��6A   
�������$��25(�6b   $ Center=�6p   $��	0,-10,0,0q�6�   5;      �� 5<      $��10,75,10,431q�6   $��1��63   .+�5=      �� $��DEFAITE��6    
�������$��25(�6G   $ Center=�6U   $
��Bold"�6l   �� 5>      -   5        $	 TextBlock_NumberDefeat��5>       $��0��6@   
�������$��25(�6a   $ Center=�6o   $��	0,-10,0,0q�6�   5?      �� 5@      
�������$��10,144,10,416q�62   $��1��6I   �� 5A      $��10,178,10,310q�6   $��1��64   .+�5B      �� $��ESSAIS RESTANT��6    
�������$��25(�6N   $ Center=�6\   $
��Bold"�6s   �� 5C      -   5        $	 TextBlock_NumberTry��5C       $��0��6>   
�������$��30(�6_   $ Center=�6m   $��	0,-10,0,0q�6�   5D      �� 5E      -   5        $ Button_ChangeDifficulty��5E      $y�Hidden=�6`   $��Changer la Difficulté��6t   $��1��6�   $��10,455,10,65q�6�   $��50��6�     Button_NewGame#��[ 6�   �� 5F      -   5        $ Button_NewGame��5F      $y�Hidden=�6N   $��Rejouer��6b   $��1��6t   $��10,510,10,10q�6�   $��50��6�   #��[ 6�   � 5H      $��	2,0,0,525q�6   .+�5I      �� $&��  Indiquez un montant entre 1 et ��6    
����� �$��30(�6c   $
��Bold"�6q   �� 5J      -   5        $	 TextBlock_MaxPriceDisplay��5J       
����� �$��30(�6_   $
��Bold"�6m   �� 5K      $	��€��6    
����� �$��30(�6E   $
��Bold"�6S   5L      �� 5M      -   5        $
 TextBox_PriceEntry��5M       �� TextWrapping$
 Wrap=�66   $��200,44,200,480q�6J   $��30(�6b   $ Center=�6p   �� 5N      -   5        $	 TextBlock_ErrorEntry��5N      $��-5,90,5,446q�6:   $ Center=�6O   
���<��$��25(�6{   �� 5O      -   5        $ Button_Validate��5O      $��250,124,250,397q�6P   $��Valider��6i   #��[ 6{   �� 5Q      -   5        $	 TextBlock_TextResultTry��5Q      $��0,178,0,296q�6=   $ Center=�6R   $��70(�6i   $
��Bold"�6w   
����� �6�   �� 5R      -   5         ��Name$ Image_MorePrice��5R      $y�Hidden=�61   $��Pictures/More.png��6E   $��150,274,150,10q�6`   �� 5S      -   5        $ Image_LessPrice��5S      $y�Hidden=�61   $��Pictures/Less.png��6E   $��150,274,150,10q�6`   �� 5T      -   5        $#	 TextBlock_TextVictoryOrDefeat��5T      $y�Hidden=�6C   $
��Wrap=�6W   $ Center=�6k   $��70(�6�   $
��Bold"�6�   
����� �$��200,274,200,-14q�6�   �� 5U      -   5        $ Image_CupOne��5U      $y�Hidden=�6.   $��Pictures/VictoryCup.png��6B   $��0,218,406,0q�6c   �� 5V      -    5        $ Image_CupTwo��5V      $y�Hidden=�6.   $��Pictures/victoryCup.png��6B   $��406,218,0,0q�6c   �� 5W      -!   5        $ Image_DefeatOne��5W      $y�Hidden=�61   $��Pictures/LostLogo.png��6E   $��541,284,45,10q�6d   �� 5X      -"   5        $ Image_DefeatTwo��5X      $y�Hidden=�61   $��Pictures/LostLogo.png��6E   $��45,284,541,10q�6d   5Y      5Z      5[      5\      