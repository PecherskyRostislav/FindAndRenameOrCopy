   M S B A M L   `   `   `  ����N  JFindAndRenameOrCopy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FindAndRenameOrCopyFindAndRenameOrCopy  5          FindAndRenameOrCopy.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      3local!clr-namespace:FindAndRenameOrCopy     5        �� 	Resources  5       �� 
TargetType �� Property �� Value   TextBox.Static.Border �� Color  TextBox.MouseOver.Border  TextBox.Focus.Border-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name J� SnapsToDevicePixels ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value  FocusVisual �� StrokeDashArray  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background 	 Button.Pressed.Border 
 Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  BtnBase ��Name��%�  '��       &	  �     &	 �     &	     '�� .    7   7  7  &	 �    &	 F    &	 i    &	 �    &	 �    &	 �    &		 �    &	
     &	 7    &	 Z    &	 }    7  7  7  7  7  7  7 	 7 
 7  7  �� 5   
   " ��6   .�5	      ��  � ��$ NoWrap=�6-   �� 5
       � ��$
 None=�6-   �� 5       � ��$ TimesNewRoman)�6+   �� 5       � ��$ 14(�6)   5      �� 5   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6;   �� 5   
   $ 	#FF569DE5��67   �� 5   
   " ��6   .�5      ��  � ��$ Verdana)�6+   �� 5       � ��$ 12(�6)   �� 5       � ��$ 0,3,0,3q�6'   �� 5       � ��# � ��6+   �� 5       � ��8   6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$
 Left=�6;   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@J�	AllowDrop . 6*   �� 5        �@��PanningMode$ VerticalFirst=�69   �� 5!       �@��IsFlicksEnabled .  67   �� 5"       � �� 5#      �� 5$      " ��6&   .R�5%      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5&      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5'      	 5(      P� 5)      
 � {� .  . �5*   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5+      P� 5,      
 �@J�IsMouseOver . . �5-   "   �� $ border��6@   8   � ��6T   5.      P� 5/      
 �@J�IsKeyboardFocused . . �50   "   �� $ border��6@   8   � ��6T   51      53      55       56      ]� 57       58      �� 59      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 5:       �@��IsSelectionActive .  6A   ./�5<      ��  �@��SelectionBrush# � /�67   5=      5?      �� 5E   
   .�5F      ��  � �� 5G      �� 5H      .R�5I      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5J      5L      5M      �� 5N   
   $ 	#FFDDDDDD��6;   �� 5O   
   $ 	#FF707070��67   �� 5P   
   $ Black��6>   �� 5Q   
   $ 	#FF3C7FB1��6:   �� 5R   
   $ 	#FFC4E5F6��6<   �� 5S   
   $ 	#FF2C628B��68   �� 5T   
   $ 	#FFF4F4F4��6=   �� 5U   
   $ 	#FFADB2B5��69   �� 5V   
   $ 	#FF838383��6=   �� 5W   
   " ��6   .�5X      ��  � ��$ Center=�6;   �� 5Y       � ��$ Center=�69   �� 5Z       � ��$ 5,3,0,3q�6'   �� 5[       �@�FocusVisualStyle8   61   �� 5\       � ��8  6+   �� 5]       � ��8  6,   �� 5^       � ��# � ��6+   �� 5_       � ��$ 1q�60   �� 5`       � ��$ Center=�6;   �� 5a       � ��$ Center=�69   �� 5b       � ��$ 	10,1,10,1q�6(   �� 5c       � �� 5d      �� 5e      " ��6&   .R�5f      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5g      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5h      	 5i      P� 5j      
 �@��IsDefaulted . . �5k   "   �� $ border��6@   # � ��6T    � ��5l      P� 5m      
 �@J�IsMouseOver . . �5n   "   �� $ border��6?   8   � ��6S   �� 5o   "   $ border��6@   8   � ��6T   5p      P� 5q      
 � �� . . �5r   "   �� $ border��6?   8   � ��6S   �� 5s   "   $ border��6@   8   � ��6T   5t      P� 5u      
 � {� .  . �5v   "   �� $ border��6?   8   � ��6S   �� 5w   "   $ border��6@   8   � ��6T   �� 5x   "   $ contentPresenter��6K   8 	  � ��6i   5y      5{      5}      5~      5�      5�      