   M S B A M L   `   `   `  ����  AdminApp_YchetSotrudnikovhJclr-namespace:AdminApp_YchetSotrudnikov;assembly=AdminApp_YchetSotrudnikovAdminApp_YchetSotrudnikov  5   	   4    .AdminApp_YchetSotrudnikov.AddEditWork_schedule   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   \localJclr-namespace:AdminApp_YchetSotrudnikov;assembly=AdminApp_YchetSotrudnikov     5   	   X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  AddEditWork_schedule��5	   	   $	��550��6&   $	��800��63   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� $��Дата��6   $��10,10,10,10q�6   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatePicker_Day��5      $��1��6-   $��10,10,10,10q�6=   �� 5   
   $*��$Начало рабочего дня��6   $��10,10,10,10q�6.   $��1��6C   "  Xceed.Wpf.Toolkit.TimePicker  5   
   -   5          Name$ TimePicker_Start��5      $��1��64   $��10,10,10,10q�6D   $��1��6Y   �� 5   
   $(��"Конец рабочего дня��6   $��10,10,10,10q�6-   $��2��6B     5    
   -   5        $ TimePicker_End��5       $��1��62   $��10,10,10,10q�6B   $��2��6W   �� 5"   
   $*��$Полный рабочий день��6   $��10,10,10,10q�6.   $��3��6C   �� 5#   
   -   5         ��Name$ CheckBox_FullTime��5#      $��1��6.   $��10,10,10,10q�6>   $��3��6S   �� 5%   
   $#��Доступные места��6   $��10,10,10,10q�6*   $��4��6?   �� 5&   
   -   5         ��Name$ TextBox_AvailablePlaces��5&      $��1��63   $��10,10,10,10q�6C   $��4��6X   �� 5(   
   $��Перерыв��6   $��10,10,10,10q�6"   $��5��67   $��2��6D   �� 5)   
   -   5        $ TextBox_Break��5)      $��1��6)   $��10,10,10,10q�69   $��5��6N   �� 5+   
   -   5        $��1��5+      $��Сохранить��6!   $
��Left=�65   $��
54,10,0,18q�6P   $��6��6~   $	��146��6�   5,      5-      