   M S B A M L   `   `   `  ����T  PAdminApp_YchetSotrudnikov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AdminApp_YchetSotrudnikovAdminApp_YchetSotrudnikov  5   	   ,    &AdminApp_YchetSotrudnikov.AddEditTasks   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AdminApp_YchetSotrudnikov     5   	     � Title$  AddEditTasks��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� $��Тема задачи��6   $��10,10,10,10q�6&   �� 5   
   -   5         ��Name$ TB_Topic��5      $��1��6;   $��10,10,10,10q�6K   ��6$   �� *Topic+6K   �� 5   
   $#��Описание задачи��6   $��10,10,10,10q�6*   $��1��6?   �� 5   
   -   5        $ TB_Description��5      $��1��6G   $��10,10,10,10q�6W   $��1��6l   ��6*   �� *Description+6l   �� 5   
   $%��Сложность задачи��6   $��10,10,10,10q�6+   $��2��6@   �� 5   
   -   5        $ TB_Complexity��5      $��1��6E   $��10,10,10,10q�6U   $��2��6j   ��6)   �� *
Complexity+6j   �� 5    
   $��Дата начала��6   $��10,10,10,10q�6&   $��3��6;   (  "System.Windows.Controls.DatePicker  5!   
   -   5          Name$ DatePicker_Start��5!      $��1��6V   $��10,10,10,10q�6f   $��3��6{      SelectedDate 6/   �� *Date_of_issue+6{   �� 5#   
   $!��Дата окончания��6   $��10,10,10,10q�6)   $��4��6>   $��2��6K     5$   
   -   5        $ DatePicker_End��5$      $��1��6R   $��10,10,10,10q�6b   $��4��6w    6-   �� *Date_of_end+6w   �� 5&   
   -   5        $��5��5&      $��1��6   $��Сохранить��6.   $
��Left=�6B   $��
41,16,0,16q�6]   $��97��6�   5'      5(      