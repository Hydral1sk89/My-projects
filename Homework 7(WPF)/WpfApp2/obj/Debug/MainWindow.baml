   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	   -   5          � Title$  Todo Scheduler��5   	   $	��450��6    $��1722.688��6-   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      .+�5   
   o� $��2��6   .@�5      m� $��16(�6   $
��File��6%   $
��Bold"�63   .@�5      m� -   5        $	��New��5      $��30��6(   $��	0,0,-10,0q�64   6G   m� 5      -   5        $
��Open��5      $��30��6)   $��	0,0,-10,0q�65   6H   m� 5      -   5        $��Import��5      $��30��6+   $��	0,0,-10,0q�67   6J   m� 5      -   5        $��Import range��5      $��30��61   $��	0,0,-10,0q�6=   6P   m� 5      -   5        $
��Save��5      $��30��6)   $��	0,0,-10,0q�65   6H   m� 5      -   5        $
��Exit��5      $��30��6)   $��	0,0,-10,0q�65   6H   5      m� 5      -   5        $��16(�5      $
��Bold"�6%   $��	Add event��67   6J   m� 5      $��16(�6   $
��Sort��6%   $
��Bold"�63   .@�5      m� -	   5        $ ��Date of creation ascending��5      $��30��6?   $��	0,0,-10,0q�6K   6^   m� 5      -
   5        $"��Date of creation decreasing ��5      $��30��6A   $��	0,0,-10,0q�6M   6`   m� 5      -   5        $��Deadline date ascending��5      $��30��6<   $��	0,0,-10,0q�6H   6[   m� 5      -   5        $��Deadline date decreasing��5      $��30��6=   $��	0,0,-10,0q�6I   6\   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgTodoList��5      $��16(�6'   $
��Bold"�65   $��10,30,10,10q�6G      AutoGenerateColumns .  $��2��6x      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ CreationDate��6]      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6s   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� 	 �� Path$	 CreationDate�6s   4  .System.Windows.Controls.DataGridCheckBoxColumn  5"       .  $
 Done��6\   $ 70 6j    6)   �� $	 IsDone�6j     5#       .  $
 Todo��6V   $	 250 6d    6%   �� $
	 Todo�6d     5$       .  $ Deadline��6Z   $	 180 6l    6%   �� $	 Deadline�6l     5%       .  $ Description��6]   $ 1000* 6r    6%   �� $	 Description�6r   5'      5(      5)      