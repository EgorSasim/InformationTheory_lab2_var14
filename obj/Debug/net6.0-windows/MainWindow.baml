   M S B A M L   `   `   `  ����?  ;lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab2lab2  5   	       lab2.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:lab2     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1200��6)   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��3��6-   $��Center=�6A   $��20(�6^   .��6l   LFSR6r   �� 5   
   $��1��6   $��0��6   .��6-   Polynome: X^36 + X^11 + 16H   �� 5   
   -   5         ��Name$ lbText��5      $��1��6    $��1��6-   .��6=   Text6C   �� 5   
   -   5        $ lbCipherText��5      $��1��6&   $��2��63   .��6C   Cipher Text6P   �� 5   
   $��2��6   $��0��6"   $��5q�62   .+�5      �� -   5         ��Name$ btnOpenFile��5      $	��100��6D   $
��Left=�6P   $��5q�6k   .��6v   	Open File6�   �� 5      .��6   Key:6   �� 5       -   5         ��Name$ 	txtBoxKey��5       
���   �6?   �� 5!      -   5        $ 	btnSubmit��5!      $	��100��6@   $��5q�6L   $
��Left=�6W   .��6r   Submit6z   �� 5"      -   5        $ 
btnReverse��5"      $	��100��6B   $��5q�6N   $
��Left=�6Y   .��6t   	Reverse6}   �� 5#      -   5        $ btnReset��5#      $	��100��6>   $��5q�6J   $
��Left=�6U   .��6p   Reset6w   �� 5$      .��6   Register state:6%   �� 5%      -   5        $ txtBoxRegState��5%      $	��480��6.   6=   5&      �� 5(   
   -	   5        $ 
txtBoxText��5(      $��2��6&   $��1��63   
���   �6Y   �� 5)   
   -
   5        $ txtBoxCipherText��5)      $��2��6,   $��2��69   
���   �6_   5*      5+      