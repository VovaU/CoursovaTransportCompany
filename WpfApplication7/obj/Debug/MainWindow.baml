   M S B A M L   `   `   `  ����J  FWpfApplication7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication7WpfApplication7  5   	        WpfApplication7.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication7     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
MainWindow��5	   	   $	��700��6   $
��1500��6)    � 	Resources 5
         path E� IsClosed E� 
StartPoint �� Point  redPath  
storyboard �� 
TargetName �� TargetProperty T� PathGeometry	 T� Source
 g� Duration g� RepeatBehavior  storyboardRed��%�  &	        &	 a    &	 r    7   7   &	 e    7  7  B� 5   
   .��5      E�  . $ 450,60&�6)   .��5      �� $ 450,60&�6   �� 5      $ 450,1400&�6   �� 5      $ 615,1850&�6   �� 5      $ 885,2348&�6   �� 5      $ 	1150,2800&�6   �� 5      $ 	2068,2900&�6   �� 5      $ 	2938,2900&�6   �� 5      $ 	4060,2629&�6   �� 5      $ 	4565,2090&�6   �� 5      $ 	5130,1540&�6   �� 5      $ 5770,875&�6   �� 5      $ 5720,875&�6   �� 5      $ 	5070,1530&�6   �� 5      $ 	4505,2090&�6   �� 5      $ 	3993,2629&�6   �� 5      $ 	2920,2850&�6   �� 5      $ 	2068,2850&�6   �� 5       $ 	1205,2785&�6   �� 5!      $ 935,2348&�6   �� 5"      $ 665,1850&�6   �� 5#      $ 500,1400&�6   �� 5$      $ 500,60&�6   �� 5%      $ 450,60&�6   5&      5'      B� 5(   
   .��5)      E�  . $ 930,250&�6)   .��5*      �� $ 1424,670&�6   �� 5+      $ 	2145,1130&�6   �� 5,      $ 	2145,2290&�6   �� 5-      $ 	3500,2290&�6   �� 5.      $ 	3500,1210&�6   �� 5/      $ 	2690,1210&�6   �� 50      $ 	2690,1255&�6   �� 51      $ 	3460,1250&�6   �� 52      $ 	3460,2250&�6   �� 53      $ 	2185,2245&�6   �� 54      $ 	2195,1120&�6   �� 55      $ 1424,615&�6   �� 56      $ 960,225&�6   5;      5<      �� 5=   
   $
 rect��5>      .��5?      T� $ (Canvas.Left)�5@      8   $	 X=�5B      $	
 0:2D�6   $ Forever��6!   T� 5C      $ (Canvas.Top)�5D      8  $	 Y=�5F      $	
 0:2D�6   $ Forever��6!   5G      �� 5H   
   $ rect121��5I      .��5J      T� $ (Canvas.Left)�5K      8   $	 X=�5M      $	
 0:2D�6   $ Forever��6!   T� 5N      $ (Canvas.Top)�5O      8  $	 Y=�5Q      $	
 0:2D�6   $ Forever��6!   5R      5S      .��5T      � $��2,0,-2.4,0.4q�6    � ColumnDefinitions 5U   
   �� 5V      $
��320* �6   �� 5W      $
��427* �6   .+�5Y   
   �� -   5        $��ScrollViewer��5Y      $
��Auto=�6-   $
��Auto=�6R   $��2��6�   |�.  .��5[      �� -   5         ��Name$ 
MainCanvas��5[      $
��6200��6)   $
��3210��66   
�������z�5\      T� 5]      -   5        canvasTransform��5]   )   .+�5_      F� #��[  6   $��2��5`      
���   � �� Left$ 50��5a      F� 5b      #��[ 6   $��2��5c      
���   �$ 50��5d      � 5e      -   5        $
��rect��5e      $y�Visible=�6#   $	��215��68   $	��125��6E   $ 75��6Q   
 �� Top$	 165��6b   .+�5f      �� -   5         ��Name$ rect11��5f      $	 335��6,   $ 84��6>   $��Resources/tralleybus.png��6N    J� RenderTransformOrigin$ 0.5,0.5&�6p   $��-20,-2,-22,70q�6�   z�5g      V� 5h      .~�5i   "   ��  �� ScaleY$ -1Q�61   �� 5j   "   �� 5k   "    �� Angle$ 90.029Q�62   T� 5l   "   5m      5o      �� 5p      -   5         ��Name$ 
Transport1��5p   U   
���   �$	 555��63   $ 45��6E   $��Title��6i   $ 0.625,5.842&�6v   $��Segoe UI Semibold)�6�   $��18(�6�   $��0,161,10,23q�6�   �� 5q      -   5        $ Transport12��5q   U   
���   �$	 555��63   $ 45��6E   $��Title222��6j   $ 0.625,5.842&�6z   $��Segoe UI Semibold)�6�   $��18(�6�   $��
0,192,55,0q�6�   5s      � 5t      -   5        $��rect121��5t      $y�Visible=�6&   $	��215��6;   $	��125��6H   $	 220��6T   $	 165��6f   .+�5u      �� -	   5        $ rect1221��5u      $	 335��6.   $ 84��6@   $��Resources/tram.png��6P   $ 0.5,0.5&�6l   $��-14,10,-15,60q�6�   z�5v      V� 5w      .~�5x   "   �� $ -1Q�61   �� 5y   "   �� 5z   "   $ 90.029Q�62   T� 5{   "   5|      5~      �� 5      -
   5        $ Transport11��5   U   
���   �$	 555��63   $ 45��6E   $��Title��6j   $ 0.625,5.842&�6w   $��Segoe UI Semibold)�6�   $��18(�6�   $��0,161,10,23q�6�   �� 5�      -   5        $ Transport122��5�   U   
���   �$	 555��63   $ 45��6E   $��Title222��6k   $ 0.625,5.842&�6{   $��Segoe UI Semibold)�6�   $��18(�6�   $��
0,192,55,0q�6�   5�      A� 5�      -   5        $
��Red0��5�      $	 985��6&   $	 225��68   $��50��6I   $��50��6T   
���  ��6`   A� 5�      -   5        $
��Red1��5�      $
 1470��6&   $	 635��69   $��50��6J   $��50��6U   
���  ��6a   A� 5�      -   5        $
��Red2��5�      $
 2196��6&   $
 1105��69   $��50��6K   $��50��6V   
���  ��6b   A� 5�      -   5        $
��Red3��5�      $
 2195��6&   $
 2240��69   $��50��6K   $��50��6V   
���  ��6b   A� 5�      -   5        $
��Red4��5�      $
 3505��6&   $
 2240��69   $��50��6K   $��50��6V   
���  ��6b   A� 5�      -   5        $
��Red5��5�      $
 3505��6&   $
 1205��69   $��50��6K   $��50��6V   
���  ��6b   A� 5�      -   5        $
��Red6��5�      $
 2725��6&   $
 1205��69   $��50��6K   $��50��6V   
���  ��6b   A� 5�      -   5        $��Green0��5�      $	 500��6(   $ 35��6:   $��50��6J   $��50��6U   
��� � �6a   A� 5�      -   5        $��Green1��5�      $	 500��6(   $	 430��6:   $��50��6K   $��50��6V   
��� � �6b   A� 5�      -   5        $��Green2��5�      $	 500��6(   $	 850��6:   $��50��6K   $��50��6V   
��� � �6b   A� 5�      -   5        $��Green3��5�      $	 500��6(   $
 1370��6:   $��50��6L   $��50��6W   
��� � �6c   A� 5�      -   5        $��Green4��5�      $	 660��6(   $
 1810��6:   $��50��6L   $��50��6W   
��� � �6c   A� 5�      -   5        $��Green5��5�      $	 930��6(   $
 2310��6:   $��50��6L   $��50��6W   
��� � �6c   A� 5�      -   5        $��Green6��5�      $
 1200��6(   $
 2755��6;   $��50��6M   $��50��6X   
��� � �6d   A� 5�      -   5        $��Green7��5�      $
 2095��6(   $
 2845��6;   $��50��6M   $��50��6X   
��� � �6d   A� 5�      -   5        $��Green8��5�      $
 2960��6(   $
 2845��6;   $��50��6M   $��50��6X   
��� � �6d   A� 5�      -   5        $��Green9��5�      $
 4060��6(   $
 2595��6;   $��50��6M   $��50��6X   
��� � �6d   A� 5�      -   5        $��Green10��5�      $
 4565��6)   $
 2065��6<   $��50��6N   $��50��6Y   
��� � �6e   A� 5�      -   5        $��Green11��5�      $
 5125��6)   $
 1510��6<   $��50��6N   $��50��6Y   
��� � �6e   A� 5�      -   5        $��Green12��5�      $
 5770��6)   $	 850��6<   $��50��6M   $��50��6X   
��� � �6d   �� 5�      -    5        $ _0Green��5�   ]   
��� � �$	 570��6/   $ 35��6A   $��55��6Q   $��25��6o   $��0��6z   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -!   5        $ _1Green��5�   K   $	 570��6   $	 430��6.   $��55��6?   $��40��6]   $��1��6h   $ 0.625,5.842&�6q   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -"   5        $ _2Green��5�   K   $	 570��6   $	 850��6.   $��55��6?   $��40��6]   $��2��6h   $ 0.625,5.842&�6q   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -#   5        $ _3Green��5�   L   $	 585��6   $
 1370��6.   $��50��6@   $��40��6^   $��3��6i   $ 0.625,5.842&�6r   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -$   5        $ _4Green��5�   L   $	 740��6   $
 1810��6.   $��54��6@   $��30��6^   $��4��6i   $ 0.625,5.842&�6r   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -%   5        $ _5Green��5�   M   $
 1000��6   $
 2305��6/   $��55��6A   $��35��6_   $��5��6j   $ 0.625,5.842&�6s   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -&   5        $ _6Green��5�   M   $
 1280��6   $
 2716��6/   $��50��6A   $��33��6_   $��6��6j   $ 0.625,5.842&�6s   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -'   5        $ _8Green��5�   M   $
 2115��6   $
 2780��6/   $��46��6A   $��30��6_   $��7��6j   $ 0.625,5.842&�6s   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -(   5        $ _9Green��5�   M   $
 2960��6   $
 2780��6/   $��46��6A   $��35��6_   $��8��6j   $ 0.625,5.842&�6s   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -)   5        $ _11Green��5�   M   $
 4115��6   $
 2635��6/   $��55��6A   $��35��6`   $��9��6k   $ 0.625,5.842&�6t   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -*   5        $ _12Green��5�   M   $
 4620��6   $
 2095��6/   $��55��6A   $��40��6`   $��10��6k   $ 0.625,5.842&�6u   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -+   5        $ _13Green��5�   M   $
 5180��6   $
 1545��6/   $��55��6A   $��35��6`   $��11��6k   $ 0.625,5.842&�6u   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -,   5        $ _14Green��5�   _   
��� � �$
 5827��6/   $	 861��6B   $��41��6S   $��40��6r   $��12��6}   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      --   5        $ _0Red��5�   ]   
���  ��$
 1055��6-   $	 205��6@   $��41��6Q   $��40��6m   $��0��6x   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -.   5        $ _1Red��5�   _   
���   �$
 1525��6/   $	 596��6B   $��41��6S   $��40��6o   $��1��6z   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -/   5        $ _2Red��5�   `   
���   �$
 2251��6/   $
 1066��6B   $��41��6T   $��40��6p   $��2��6{   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -0   5        $ _3Red��5�   `   
���   �$
 2251��6/   $
 2174��6B   $��41��6T   $��40��6p   $��3��6{   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -1   5        $ _4Red��5�   `   
���   �$
 3445��6/   $
 2189��6B   $��41��6T   $��40��6p   $��4��6{   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -2   5        $ _5Red��5�   `   
���   �$
 3555��6/   $
 1139��6B   $��41��6T   $��40��6p   $��5��6{   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   �� 5�      -3   5        $ _6Red��5�   `   
���   �$
 2725��6/   $
 1141��6B   $��41��6T   $��40��6p   $��6��6{   $ 0.625,5.842&�6�   $��Segoe UI Semibold)�6�   $��36(�6�   5�      5�      (� 5�   
   -4   5        $
��Left=�5�      $	��500��60   $��269,-85,0,345q�6@   $	��575��6W   $��1��6c   .��5�      �� -5   5        $��miniMap��5�   D   
�������$
��6000��6)   $
��2910��66   $��10,425,158.6,20q�6S   5�      5�      �� 5�   
   -6   5        $	��ggg��5�      .+�5�      �� -7   5         ��Name$ textBox��5�       �� 
IsReadOnly . $ 10��69    �� TextWrapping$
 Wrap=�6J   $	 465��6^   $	��175��6o   $	��160��6|   5�      ]� 5�   
   $
��Auto��6   ��.  $	 125��68   $ 20��6J   $
��Auto��6Z   $��0,0,549,638.6q�6g   .+�5�      o� $	��Top=�6   $��0,0,40,0q�6(   .@�5�      m� $��_File��6   .@�5�      m� -8   5        $��_Save��5�      6.   m� 5�      -9   5        $��_Load��5�      6.   m� 5�      -:   5        $��_Exit��5�      6.   5�      5�      �� 5�       �� AcceptsReturn . $��0,0,0,82q�6+   $��95��6=   5�      5�      5�      