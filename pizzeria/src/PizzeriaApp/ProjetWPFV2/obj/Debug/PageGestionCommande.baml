   M S B A M L   `   `   `  ����F  BProjetWPFV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjetWPFV2ProjetWPFV2  5      %    ProjetWPFV2.PageGestionCommande   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ProjetWPFV2     5        N� Title$  PageGestionCommande��5	      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63    �� Opacity$
 0.42Q�6F   .��5      �  � Color$ 	#FFD0DBFA��6    � Offset$ 0.491Q�61   � 5      $ 	#FFD6B7FF��6   $ 1Q�61   � 5      $ 	#FFE0BFEC��6   $ 0.103Q�61   � 5      $ 	#FFCC87E3��6   $ 0.006Q�61   5       � ColumnDefinitions 5   
   �� 5      $��40 �6   �� 5      $	��26* �6   �� 5      $
��Auto �6   �� 5      $	��57* �6   �� 5      $
��Auto �6   �� 5      $��80 �6   �� 5      $��40 �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $��80 �6   �� 5!      $��50 �6   �� 5"      $	��94* �6   �� 5#      $	��61* �6   .+�5&   
   �� -   5        $��4��5&      $��Right=�6!   $��82��6=   $��5��6I   $	��125��6V   $��0q�6�   $	��Top=�6�   ��6b   Z� ��6y   Z� ��5'      �� 5(      $ 0.5,1&�6&   $ 0.5,0&�67    �� RelativeTransform 5)      V� 5*      .~�5+      �� 	 �� CenterY$		 0.5Q�6-   
 �� CenterX$	
 0.5Q�6;   �� 5,       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5-       �� Angle$ -34.046Q�6.    �� CenterY$	 0.5Q�6>    �� CenterX$	 0.5Q�6L   T� 5.      5/      .��51      � $ 	#FFD2D6D5��6#   $ 0.818Q�65   � 52      $ 	#FFF33A11��6#   $ 1Q�65   � 53      $ 	#FF5ED818��6#   $ 0.641Q�65   � 54      $ 	#FFC1C2C2��6#   $ 0.443Q�65   � 55      $ 	#FF11E3C3��6#   $ 0.237Q�65   � 56      $ 	#FFA7AAAA��6#   57      .��59      ��  �� CornerRadius$ 15��6   $	��120��6'    �� Padding$ 10q�63   $��2q�6@   ��6T   Z� ��5:      �� 5;      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5<      � $ 	#FF3F4418��6'   $ 0Q�69   � 5=      $ 	#FF145918��6'   $ 1Q�69   5>      ._�5@      �� $��Rockwell Condensed)�6   $��16(�6<   $��Italic$�6J   $
��Wrap=�6]    �� TextAlignment$ Center=�6q   $	��Top=�6�   ��5A      �� 5B      $ 0.5,1&�6.   $ 0.5,0&�6?    5C      V� 5D   "   .~�5E   &   �� $		 0.5Q�65   $	
 0.5Q�6C   �� 5F   &   $	 0.5Q�64   $	 0.5Q�6B   �� 5G   &   $ -34.046Q�66   $	 0.5Q�6F   $	 0.5Q�6T   T� 5H   &   5I   #   .��5K      � $ 	#FF986C6C��6+   $ 0.263Q�6=   � 5L      $ 	#FF3B3A3A��6+   $
 0.78Q�6=   � 5M      $ 	#FF5E5D5D��6+   5N      Modifier une commande5Q      5R      5T      (  "System.Windows.Controls.DatePicker  5U   
   -   5        $��datefin��5U      $��4��6$   $
��Left=�64   $��28��6O   $��3��6[   $	��Top=�6h   $	��150��6�   $��0q�6�     5V   
   -   5        $��	datedebut��5V      $��2��6&   $
��Left=�66   $��28��6Q   $��3��6]   $	��Top=�6j   $	��150��6�   $��0q�6�   �� 5W   
   -   5        $��lstviewcommande��5W      $��2��6+   $��3��6;   $
��Left=�6O   $	��192��6j   $��4��6w   $	��Top=�6�   $	��488��6�   $��0,15,0,0q�6�    �� View 5X      �� 5Y      .P�5Z      �� $	��N°��6I    �� DisplayMemberBinding 6%   �� *Id+6I   �� 5[      $��N° du client��6P    6%   �� *	NumClient+6P   �� 5\      $��Commis��6P    6%   �� *	NomCommis+6P   �� 5]      $��Livreur��6Q    6%   �� *
NomLivreur+6Q   �� 5^      $��Total��6Q    6%   �� *
PrixActuel+6Q   �� 5_      $
��Etat��6K    6%   �� *Etat+6K   �� 5`      $��	Livrée ?��6P    6%   �� *	Encaisser+6P   �� 5a      $
��Date��6K    6%   �� *Date+6K   5b      5d      �� 5e   
   $��8��6   $��1��6$   $	��0,3q�61   $��Center=�6G   $��Times New Roman)�6k   $��36(�6�   $��0,0,0,0.333q�6�   ���	#1EB7B7B7$
��Bold"�6�   $��Italic$�6�   ��5f      �� 5g      $ 0.5,1&�6&   $ 0.5,0&�67    5h      V� 5i      .~�5j      �� $		 0.5Q�6-   $	
 0.5Q�6;   �� 5k      $	 0.5Q�6,   $	 0.5Q�6:   �� 5l      $ -98.616Q�6.   $	 0.5Q�6>   $	 0.5Q�6L   T� 5m      5n      .��5p      � $ 	#FF0F2144��6#   � 5q      $ 	#FF0B174D��6#   $ 1Q�65   � 5r      $ 	#FF626C95��6#   $ 0.491Q�65   5s      ��5u      �� 5v      $ 0.5,1&�6&   $ 0.5,0&�67   $	 0.7Q�6J    5w      V� 5x      .~�5y      �� $		 0.5Q�6-   $	
 0.5Q�6;   �� 5z      $	 0.5Q�6,   $	 0.5Q�6:   �� 5{      $ 63.925Q�6.   $	 0.5Q�6=   $	 0.5Q�6K   T� 5|      5}      .��5      � $ Black��6#   $ 0Q�61   � 5�      $ White��6#   $ 0.154Q�61   � 5�      $ White��6#   $ 0.683Q�61   � 5�      $ 	#FF090909��6#   $ 0.374Q�65   � 5�      $ 	#FF161616��6#   $ 0.886Q�65   5�      .��5�   !   Gestion des commandes5�      �� 5�   
   $��ID Commande :��6   $��3��6(   $��Center=�68   $��30��6U   $��0q�6a   $��2��6l   $��Bottom=�6y   $	��125��6�   $��Sitka Small)�6�   �� 5�   
   -   5        $��	boxsearch��5�      $��Center=�6#   $��3��6E   $��Center=�6U   $��30��6r   $��3��6    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��125��6�   $��Sitka Small)�6�   $��14(�6�   $��0q�6  �� 5�   
   -   5        $��	btngoback��5�      $��0��6#   $��0��63   ��6@   Z� ��6W   Z� ��6�   Z� .��5�      �� $��
fleche.png��6   5�      �� 5�   
   $��Date de Début :��6   $��2��6*   $
��Left=�6:   $��30��6U   $��0q�6a   $��2��6l   $��Bottom=�6y   $��Sitka Small)�6�   �� 5�   
   $��Date de Fin :��6   $��4��6(   $��Center=�68   $��30��6U   $��0q�6a   $��2��6l   $��Bottom=�6y   $	��150��6�   $��Sitka Small)�6�   �� 5�   
   -   5        $��3��5�      $��Right=�6!   $��82��6=   $��5��6I   $	��125��6V   $	��Top=�6�   ��6b   Z� ��6y   Z� ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67    5�      V� 5�      .~�5�      �� $		 0.5Q�6-   $	
 0.5Q�6;   �� 5�      $	 0.5Q�6,   $	 0.5Q�6:   �� 5�      $ -34.046Q�6.   $	 0.5Q�6>   $	 0.5Q�6L   T� 5�      5�      .��5�      � $ 	#FFD2D6D5��6#   $ 0.818Q�65   � 5�      $ 	#FFF33A11��6#   $ 1Q�65   � 5�      $ 	#FF5ED818��6#   $ 0.641Q�65   � 5�      $ 	#FFC1C2C2��6#   $ 0.443Q�65   � 5�      $ 	#FF11E3C3��6#   $ 0.237Q�65   � 5�      $ 	#FFA7AAAA��6#   5�      .��5�      �� $ 15��6   $	��120��6'   $ 10q�63   $��2q�6@   ��6T   Z� ��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ 	#FF3F4418��6'   $ 0Q�69   � 5�      $ 	#FF145918��6'   $ 1Q�69   5�      ._�5�      �� -   5         ��Name$ Facturebutton��5�      $��Rockwell Condensed)�63   $��16(�6S   $��Italic$�6a   $
��Wrap=�6t   $ Center=�6�   $	��Top=�6�   $��Afficher une facture��6�   ��5�      �� 5�      $ 0.5,1&�6.   $ 0.5,0&�6?    5�      V� 5�   "   .~�5�   &   �� $		 0.5Q�65   $	
 0.5Q�6C   �� 5�   &   $	 0.5Q�64   $	 0.5Q�6B   �� 5�   &   $ -34.046Q�66   $	 0.5Q�6F   $	 0.5Q�6T   T� 5�   &   5�   #   .��5�      � $ 	#FF986C6C��6+   $ 0.263Q�6=   � 5�      $ 	#FF3B3A3A��6+   $
 0.78Q�6=   � 5�      $ 	#FF5E5D5D��6+   5�      5�   .   5�      5�      5�      5�      