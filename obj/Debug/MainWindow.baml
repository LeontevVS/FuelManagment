   M S B A M L   `   `   `  ����H  DFuelManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FuelManagmentFuelManagment  5   	       FuelManagment.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FuelManagment     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��31 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   .+�5      �� -   5         ��Name$ 
Btn_Create��5      $��Создать��6)   $��	15,3,15,3q�6;   6N   �� 5      -   5        $ 	btnDelete��5      $��Удалить��6(   $��0,3,15,3q�6:   6L   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridFillOnCards��5      $��0��6-      AutoGenerateColumns .     
IsReadOnly . ��5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Дата��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      `� 5       �� StringFormat$ {0}.{1}.{2} {3}:{4}��6'   .1�5      ��  �� Path$ Date.Day�6&   �� 5      $ 
Date.Month�6&   �� 5      $ 	Date.Year�6&   �� 5      $ 	Date.Hour�6&   �� 5       $ Date.Minute�6&   5!      5#        5$      $	 АЗС��6%   $
 * 6b    62   �� *GasStation.FuelCompany.Name+6b     5%      $	 Количество��6%   $
 * 6W    69   �� *	FuelCount+6W     5&      $	 Расход��6%   $
 * 6i    65   �� *!Waybill.Vehicle.FuelConsumption+6i     5'      $	 Цена��6%   $
 * 6R    63   �� *
DiselPrice+6R     5(      $	 Стоимость��6%   $
 * 6S    68   �� *Amount+6S   5*      5+      5,      