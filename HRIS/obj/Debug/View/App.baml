   M S B A M L   `   `   `  ����?  ;HRIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRIS.ControllerHRIS.Controller  5      -clr-namespace:HRIS.TeachingHRIS.Teaching  5      %clr-namespace:HRIS.View	HRIS.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          HRIS.Controller.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      4
controllerclr-namespace:HRIS.Controller     5      .entityclr-namespace:HRIS.Teaching     5      )localclr-namespace:HRIS.View     5      6sys&clr-namespace:System;assembly=mscorlib     5        �� 	Resources  5	      %   HRIS.Controller.StaffController   staffController  staffListKey S� ObjectInstance S� 
MethodName$   HRIS.Controller.UnitController  unitController  unitListKey  StaffListTemplate �� Orientation �� Path  UnitListTemplate  
x_Category S� 
ObjectType  System.Enum S� MethodParameters M� TypeName  x_Campus��%�  &	        &	      7   &	 O     &	 b     7  &	 �     &	 �    &	 |    &	 �      5   
   6%   S� 5   
   8   $ GetStaffViewList��5      5        5   
   6$   S� 5   
   8   $ GetUnitViewList��5      5      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5       �� ��6   �� $ 
FamilyName��� 5!      $��, ��6   �� 5"      ��6   �� $ 	GivenName��� 5#      $�� (��6   �� 5$      ��6   �� $ 
StaffTitle��� 5%      $��)��6   5&      5'      �� 5)   
   .R�5*      �� $ 
Horizontal=�6   .+�5+      �� ��6   �� $ UnitCode��� 5,      $�� ��6   �� 5-      ��6   �� $ 	UnitTitle�5.      5/      S� 52   
   "  53      $ 	GetValues��54       55      M� 56      $ controller:Category��6   58      S� 5:   
   "  5;      $ 	GetValues��5<       5=      M� 5>      $ controller:Campus��6   5@      5L      5M      