   M S B A M L   `   `   `  ����L  HTicketSalesSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TicketSalesSystem.ViewsTicketSalesSystem.Views  5      C&clr-namespace:TicketSalesSystem.ModelsTicketSalesSystem.Models  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      0    *TicketSalesSystem.Views.ManageUsersControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      7local%clr-namespace:TicketSalesSystem.Views     5      9models&clr-namespace:TicketSalesSystem.Models     5      6sys&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5         UserRoleEnum S� 
MethodName S� 
ObjectTypeU QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Enum S� MethodParameters M� TypeName��%v   &	        S� 5   
   $ 	GetValues��62   "  6I    5      M� 5      $ models:UserRole��6   5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgUsers��5         AutoGenerateColumns$ False��6$   $��20q�6@      SelectionMode$ Single=�6L      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6H      
IsReadOnly$
 True��6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6S     5      $	 Username��6%   $	
 100 6y    67   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6y     5      $	 Password��6%   $	
 100 6y    67   �� *
Password+$ PropertyChanged=�6y     5      $	 Email��6%   $	
 150 6s    64   �� *Email+$ PropertyChanged=�6s   4  .System.Windows.Controls.DataGridComboBoxColumn  5      $	 	User Role��6)   $	
 100 6�      SelectedItemBinding 6<   �� *
UserRole+$ PropertyChanged=�   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value 6<   ��  �� Source# [  5         EditingElementStyle 5!      �� 5"      " ��6    .�5#      ��  � �� 6<   �� # [  5$      5&      4  .System.Windows.Controls.DataGridTemplateColumn  5'      $

 Auto 6)      CellTemplate 5(      �� 5)      .R�5*      �� -   5        $
��Save��5*   %   64   5+      5-        5.      $	
 100 6)    5/      �� 50      .R�51      �� -   5        $��Delete��51   %   $��80��66   $��Center=�6Z   $��Center=�6w   
 � Tag 6�   �� *Id+52      54      56      57      58      