   M S B A M L   `   `   `  ����N  JFindAndRenameOrCopy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FindAndRenameOrCopyFindAndRenameOrCopy  5   	   $    FindAndRenameOrCopy.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:FindAndRenameOrCopy     5   	     � Title$;  5Работа с файлами изображений��5   	   $
��Auto��5	   	   $	��400��5
   	    � SizeToContent$ Height=�5   	    � 
ResizeMode$ NoResize=�5   	   
������� � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5         FindAndRenameOrCopy.MainVM  5   
    � 	Resources 5       �� 
TargetType   BtnBase �� BasedOn �� Property	 �� Value��%�   '��       7   �� 5   
   " ��6   8   .�5      ��  � ��
	 �����6+   �� 5       � ��$	 Verdana)�6+   �� 5       � ��$	 13(�6)   �� 5       � ��
	 �"�"�6+   5      5      .��5      � $
��Auto��6   $��5q�6   
 � RowDefinitions
 5   
   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   .+�5$   
   � $��0��6    � ColumnDefinitions 5%      �� 5&      $��* �6#   �� 5'      $��* �6#   .+�5)      �� $��0��6   $��Перемещать��5*      $��0,3,0,3q�5+      ��5,      �� *ActivateModeMove+�� 5-      $��1��6   $��Копировать��5.      
��� �����50      �� *ActivateModeCopy+51      � 53   
   $��1��6   
 54      �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6    .+�5<      �� $��0��6   $)��#Каталог для поиска:��6%   ]� 5>      $��1��6   .+�5?      �� $��
Обзор��6   $��Right=�5@      ��5A      �� *CurrentColor+��5B      �� *OpenDialgToFind+�� 5C      ��6   �� *FolderToFind+5D      �� 5F      $��2��6    �� Orientation$ 
Horizontal=�6&   .+�5G      �� $��Каталог для ��6   �� 5H      ��6   �� *
DopLblName+�� 5I      $��:��6   5J      ]� 5M      $��3��6   .+�5N      �� $��
Обзор��6   $��Right=�5O      ��5P      �� *CurrentColor+��5Q      �� *OpenDialgToMoveCopy+�� 5R      ��6   �� *FolderToMoveCopy+5S      ]� 5U      $��4��6   .+�5V      �� $��Right=�5X      ��5V      �� *ExecBtnName+��5W      �� *ExecuteCommand+��5Y      �� *CurrentColor+� 5Z      $��0,3,0,3q�6    � Value 5[      �� *CurrentPosition+ � Maximum 5\      �� *
CountItems+5]      5_      5`      5a      