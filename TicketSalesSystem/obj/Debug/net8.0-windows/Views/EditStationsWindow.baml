   M S B A M L   `   `   `  ����  TicketSalesSystem0    *TicketSalesSystem.Views.EditStationsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Edit Stations��5   	   $	��450��6   $	��600��6,   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
lbStations��5      $��10q�6&    �� SelectionMode$ Single=�62    �� DisplayMemberPath$ Station.Name��6I   $��0��6j   ��6w   �� *UpdatedOrderedStations+�� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��1��6K   $��10q�6X   .+�5      �� -   5         ��Name$ cbAllStations��5      $	��200��6.   $
 Name��6:    �� SelectedValuePath$ Id��6S   $��5q�6j   ��6u   �� *AllStations+�� 5      -   5        $��Add Station��5      $��5q�6D   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��2��6K   $��10q�6X   .+�5      �� -   5        $��Up��5      $��5q�67   �� 5      -   5        $
��Down��5      $��5q�6;   5      �� 5   
   -   5        $
��Save��5      $��Right=�6    $��10q�6<   $	��100��6H   $��Bottom=�6T   $��2��6�   5      5      