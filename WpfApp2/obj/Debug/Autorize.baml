   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.Autorize   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  Autorize��5   	    � AllowsTransparency . $��423.442��64   $��424.224��6E    � WindowStartupLocation$ CenterScreen=�6U    � 
ResizeMode$ NoResize=�6z    � Icon$, &attachment_28155896-e1496071165740.png��6�    � WindowStyle$
 None=�6�   ��6�   Z� ��6�   Z� .��5	      � -   5         �Name$ Grid1��5	      $	��423��6   $��Bottom=�6'   $
��Left=�6B   $	��424��6]    � RowDefinitions 5
   
   �� 5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"   	 �� 
StartPoint$	 0.5,0&�63   
 �� RelativeTransform
 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6)    �� CenterX$	 0.5Q�67   �� 5       �� CenterY$	 0.5Q�6(    �� CenterX$	 0.5Q�66   �� 5       �� Angle$ -34.624Q�6*    �� CenterY$	 0.5Q�6:    �� CenterX$	 0.5Q�6H   T� 5      5      .��5      �  � Color$ 	#FF040436��6   � 5      $ 	#FF280546��6    � Offset$ 1Q�61   � 5      $ 	#FF0B084D��6   $ 0.637Q�61   5      .+�5   
   �� -   5        $��3q�5       �� CornerRadius$ 2��6&   $
��Left=�67   $	��416��6R   $��	4,3,0,392q�6�   ��5      �� 5       �� Color$ 	#FF111142��6"    �� Opacity$	 0.8Q�64   ��5!      �� 5"      $ 	#FF111142��6"   $	 0.8Q�64    J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Color$ 	#FF474646��6#      
BlurRadius$ 7Q�65      ShadowDepth$ 3Q�6D   ._�5'      �� $
��Left=�6   $��32��64   $��
2,-1,-2,-9q�6@   $	��Top=�6T   $	��410��6l    J� RenderTransformOrigin$ 0.5,0.5&�6x   z�5(      V� 5)      .~�5*      �� �� 5+       �� AngleX$ 0.749Q�6(   �� 5,      T� 5-       T� X$ 0.654Q�6-   5.      .+�50      �� $��Chemistry apt��6   $	��Top=�60   $	��Top=�6O   
�������$��Franklin Gothic Demi)�6�   $��20(�6�   $
��Left=�6�   $	��138��6�   $��0,-4,0,0q�6�   ��6g   Z� 6�   �� 51      -   5         ��Name$ ButClose��51      $	��Top=�6+   $��X��6J   $��384,-30,4,0q�6V   ���	#FFFDFDFD
�������$ 0.775,0.353&�6�   $	��Top=�6�   $��Center=�6  $��22��6  $��26��6)  $��Franklin Gothic Demi)�65  $��17(�6W  ��6k   Z� 6W  52      53      �� 54   
   -   5         ��Name$ 
LabelLogin��54      $�� ��6$   $��Center=�6/   $��Center=�6S   $
��Left=�6u   $��
55,131,0,0q�6�   $	��Top=�6�   
�������$��Franklin Gothic Demi)�6�   $	��332��6�   $��40(�6�   $	��205��6  �� 55   
   -   5          ��Name$  	CaptchBox��55      $��Center=�6%   $��Center=�6I   $
��Left=�6k   $��39��6�   $��275,304,0,0q�6�   ! �� TextWrapping$
! Wrap=�6�   $	��Top=�6�   $	��120��6�   $ 0.269,0.797&�6�   
����������	#FF81858F$��Franklin Gothic Demi)�6.  $��25(�6P  .��6^   56        57      .��58      ��59      �� 5:      $ 	#FF0A083E��6"   $	 0.3Q�64   .��5;   "   5<      �� 5=   
   -   5        $ LabelCaptch��5=      $��
Капча��6%   $
��Left=�65   $��
90,274,0,0q�6P   $	��Top=�6d   
�������$��Franklin Gothic Demi)�6�   $��18(�6�   �� 5>   
   -   5        $  CapthGenBox��5>      $��Center=�6'   $��Center=�6I   $
��Left=�6m   $��39��6�   $��
62,305,0,0q�6�   $
! Wrap=�6�   $	��Top=�6�   $	��120��6�   $ 0.269,0.797&�6�   
����������	#FF81858F$��25(�6/  $��Kristen ITC)�6=  .��6V   5?        5@      .��5A      ��5B      �� 5C      $ 	#FF0A083E��6"   $ 0.285Q�64   .��5D   "   5E      �� 5F   
   -   5        $ 	LabelVvod��5F      $��Ввод капчи��6#   $
��Left=�68   $��285,274,0,0q�6S   $	��Top=�6h   
�������$��Franklin Gothic Demi)�6�   $��18(�6�   �� 5G   
   -	   5        " ��Name$" 
ImageBlock��5G      $y�Hidden=�6$   $
��Left=�68   $��72��6S   $��
190,36,0,0q�6_   $	��Top=�6s   $��73��6�   $!��password--v1 копия.png��6�   �� 5H   
   -
   5        # ��Name$# BorderZachem��5H      $ 7��6'   $��1q�68   $
��Left=�6L   $��30��6g   $��162,374,0,0q�6s   $	��Top=�6�   $	��113��6�   ��5I      �� 5J      $ 	#FF040146��6"   $	 0.8Q�64   ��5L      �� 5M      $ 	#FF0A083E��6"   $	 0.8Q�64   ._�5P      �� -   5        $ LoginButton��5P   8   $��Bottom=�6   $��
Войти��6M   $	��Top=�6]   $��Franklin Gothic Demi)�6u   
�������$��28��6�   $��20(�6�   $	��3,0q�6�   ��6�   Z� ��6  Z� 5Q      �� 5R   
   -   5        $# BorderCaptch��5R      $ 3��6'   $��1q�68   $
��Left=�6L   $��28��6g   $��
24,311,0,0q�6s   $	��Top=�6�   $��34��6�   ��5S      �� 5T      $ 	#FF0A083E��6"   $	 0.8Q�64   ��5V      �� 5W      $ 	#FF0A083E��6"   $	 0.8Q�64   ._�5Y      �� -   5        $ ButNewCaptch��5Y      $��Center=�6+   
�������$��Franklin Gothic Demi)�6�   $��15(�6�   ��6P   Z� .��5Z      �� $��redresh.png��6   $��24��6-   $��30��69   5[      5\      �� 5]   
   $
��Left=�6   $	��180��60   $��	46,40,0,0q�6=   $	��Top=�6P   $	��309��6h   �� 5^   
   -   5        $# BorderLogin��5^      $ 7��6&   $��1q�67   $
��Left=�6K   $��95��6f   $��	52,51,0,0q�6r   $	��Top=�6�   $	��320��6�    5_        5`      $ 20Q�6#   $ 	#FF191919��63   $ 3Q�6E   ��5b      �� 5c      $ 	#FF0E0E38��6"   $	 0.8Q�64   ._�5e      �� $
��Left=�6   $��88��64   $	��Top=�6@   $	��305��6X   $��3,3,0,0q�6d   .+�5f      �� -   5        $  LoginBox��5f      $��Center=�6,   $
��Left=�6P   $��34��6k   $��	54,37,0,0q�6w   $
! Wrap=�6�   $	��Top=�6�   $	��244��6�   ���	#FF81858F$ �� SelectionBrush$ �	#FFE4E4E4
�������$��25(�6  $��Franklin Gothic Demi)�6  .��6|   5g        5h      .��5i   &   ��5j      �� 5k      $ 	#FF0A083E��6*   $	 0.3Q�6<   .��5l   *   5m      �� 5n      -   5        $ LabelLogin2��5n      $��Center=�6-   $��
Логин��6Q   $
��Left=�6a   $��
54,-69,0,0q�6|   $	��Top=�6�   
�������$��Franklin Gothic Demi)�6�   $��20(�6�   $	��241��6�   �� 5o      -   5        $" 
ImageLogin��5o      $
��Left=�6,   $��34��6G   $	��Top=�6S   $��33��6k   $��Sample_User_Icon.png��6v   $��
10,-34,0,0q�6�   5p      5q      �� 5r   
   -   5        $# 
BorderPass��5r      $ 7��6%   $��1q�66   $
��Left=�6J   $	��103��6e   $��
52,162,0,0q�6r   $	��Top=�6�   $	��320��6�    5s        5t      $ 20Q�6#   $ 	#FF191919��63   $ 3Q�6E   ��5v      �� 5w      $ 	#FF0E0E38��6"   $	 0.8Q�64   ._�5y      ]� $
��Left=�6   $��98��63   ��.  $	��Top=�6U   $	��314��6m   $��2,2,0,0q�6y   .+�5z      �� -   5        $ 	LabelPass��5z      $��Center=�6+   $��Center=�6O   $��Пароль��6q   $	��Top=�6�   
�������$��Franklin Gothic Demi)�6�   $��20(�6�   $��Right=�6�   $��
-296,3,0,0q�6�   $	��240��6  G� 5{      -   5        % G�Name$% PassBox��5{      $��Center=�6/   $��-298,-3,0,-16q�6T   $	��244��6l   $��34��6x   ���	#FF81858F
�������$��25(�6�   $��Franklin Gothic Demi)�6�   $��Right=�6�    5|        5}      ��5      �� 5�      $ 	#FF0A083E��6*   $	 0.3Q�6<   5�      �� 5�      -   5        $ ButShowPass��5�      $��Center=�6/   $��Center=�6S   $
��Left=�6v   $��
1.9,38,0,0q�6�   $	��Top=�6�   $��25��6�   $��34��6�   
�������$��24(�6  $��Franklin Gothic Demi)�67  $��Right=�6Y  $��
2147483646��6p  ��6�   Z� ��6�   Z� .��5�      �� -   5        $" ImageBox��5�      $��eye_open.png��6.   5�      �� 5�      -   5        $  TextPassBox��5�      $y�Hidden=�6/   $��Center=�6C   $
��Left=�6g   $��34��6�   $��
4.8,38,0,0q�6�   $
! Wrap=�6�   $	��Top=�6�   $	��244��6�   ���	#FF81858F$ �	#FFE4E4E4
�������$��25(�6   $��Franklin Gothic Demi)�6.  $��Right=�6P  .��6g   5�        5�      .��5�   &   ��5�      �� 5�      $ 	#FF0A083E��6*   $	 0.3Q�6<   .��5�   *   5�      �� 5�      -   5        $" 	ImagePass��5�      $
��Left=�6+   $��32��6F   $��0,39,0,0q�6R   $	��Top=�6d   $��31��6|   $!��password--v1 копия.png��6�   $��Right=�6�   5�      5�      �� 5�   
   -   5        $# ForgotBorder��5�      $ 7��6'   $��27��69   $��
10,386,0,0q�6E   $	��Top=�6Y   $��99��6q   $��1q�6|   $
��Left=�6�   ��5�      �� 5�      $ 	#FF0A083E��6"   $	 0.8Q�64   ��5�      �� 5�      $ 	#FF040146��6"   $	 0.8Q�64   ._�5�      �� -   5        $ 
ForogtPass��5�      $��Забыл пароль��6)   $��-1q�6@   $��Franklin Gothic Demi)�6L   
�������$��14(�6�   ��6�   Z� ��6�   Z� 6�   5�      �� 5�   
   -   5        $# BorderClickForg��5�   6   $ 7��6   $y�Hidden=�6"   $��1q�6O   $
��Left=�6c   $	��159��6~   $��
55,109,0,0q�6�   $	��Top=�6�   $	��318��6�    5�        5�      $ 20Q�6#   $ 	#FF191919��63   $ 3Q�6E   ��5�      �� 5�      $ 	#FF0E0E38��6"   $	 0.9Q�64   ._�5�      �� -   5        $ LabelForgotPass��5�      $y�Hidden=�6-   $����Если вы забыли пароль, обрати-
тесь к администратору для полу-
чения новых данных для даль-
нейшей авторизации.��6A   $
��Left=�6�   $	��Top=�6�   $��9,9,0,0q�6	  
�������$	��139��6-  $	��300��6:  $��Franklin Gothic Demi)�6F  $��20(�6h  ��6v  Z� 5�      �� 5�   
   -   5        $# BoderButForg��5�   "   $ 7��6   $y�Hidden=�68   $��1q�6L   $
��Left=�6`   $��35��6{   $��161,320,0,0q�6�   $	��Top=�6�   $	��114��6�   ��5�      �� 5�      $ 	#FF0E0E38��6"   $
 0.95Q�64   ._�5�      �� -   5        $ ButtobForgotWindow��5�      $y�Hidden=�61   $&��           ОК                  ��6E   $
��Left=�6n   $	��Top=�6�   $	��107��6�   $��3,1,0,0q�6�   $��31��6�   $��Franklin Gothic Demi)�6�   $��17(�6�   
���������6�   Z� ��6  Z� 6:  5�      5�      5�      