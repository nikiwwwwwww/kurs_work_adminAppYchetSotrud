   M S B A M L   `   `   `  ����T  PAdminApp_YchetSotrudnikov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AdminApp_YchetSotrudnikovAdminApp_YchetSotrudnikov  5   	   3    -AdminApp_YchetSotrudnikov.AuthorizationWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AdminApp_YchetSotrudnikov     5   	   -   5          � Title$  AuthorizationWindow��5   	   $	��450��6%   $	��800��62   
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� $��10,10,10,10q�6   $
��Wrap=�6)   $��30(�6=    �� TextAlignment$ Center=�6K   $��2��6b   $��1��6r   �� 6�    � Language$ ru-ru�6�   $�Авторизация��6�   6�   �� 5   
   -   5         ��Name$ TB_login��5      $��10,10,10,10q�6$    �� TextWrapping$
 Wrap=�69   $��2��6M   $��3��6]   �� 5   
   -   5        $��
Войти��5      $��10,10,10,10q�6"   $��1��6S   $��7��6c   �� 5   
   -   5        $*��$Зарегистрироваться��5      $��10,10,10,10q�6/   $��3��6_   $��7��6o   �� 5    
   -   5        $ TB_password��5       $��10,10,10,10q�6'   $
 Wrap=�6<   $��2��6P   $��5��6`   �� 5!   
   $��2��6   $��
Логин��6    $��	10,0,10,0q�60   $��2��6C   �� 5"   
   $��2��6   $��Пароль��6    $��	10,0,10,0q�61   $��4��6D   5#      5$      