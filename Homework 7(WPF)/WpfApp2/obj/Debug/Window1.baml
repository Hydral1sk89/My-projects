   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  Import range��5   	   $	��250��6   $	��300��6+   .��5	      � $��0,0,2,1q�6    � RowDefinitions 5
   
   �� 5      $	��20* �6   �� 5      $��35 �6   �� 5      $	��25* �6   �� 5      $	��35* �6   �� 5      $	��25* �6   �� 5      $	��35* �6   �� 5      $	��35* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��	10,0,0,10q�6   $��2��6'   $��0��64   $��2��6D   $	��300��6X   $��30��6d   $9��3Select date range by creation date or deadline date��6p   	� 5   
   -   5        $��	25,5,0,10q�5      $��0��6)   $��3��69    	� 	GroupName$ Import_date��6F   $��Creation date��6^    d� 	IsChecked$
 trueY�6v   6�   	� 5   
   -   5        $��	25,5,0,10q�5      $��1��6)   $��3��69   $ Import_date��6F   $��Deadline date��6^   6v   �� 5   
   $��	60,0,0,10q�6   $	��For��6'   $��0��62   $��4��6B   �� 5   
   $��	60,0,0,10q�6   $��To��6'   $��1��61   $��4��6A   �� 5   
   -   5         ��Name$	 For��5      $��0��6   $��5��6/   �� 5   
   -   5        $ To��5      $��1��6   $��5��6.   �� 5   
   -   5        $ textpath��5      $��0��6$   $��1��64   �� 5   
   $��0��6   $��2��6!   $��
File path:��65   �� 5    
   -   5        $��	200,0,0,0q�5       $��30��6%   $��80��61   $��2��6<   $��1��6P   .��6z   File explorer6�   �� 5!   
   -   5        $��30��5!      $	��100��6   $��2��6)   $��6��6=   .��6g   Import6o   5"      5#      