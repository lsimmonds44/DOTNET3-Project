   M S B A M L   `   `   `  ����L  HNativeGardenerWeb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ZombieVeggieTalesZombieVeggieTales  5   	   "    ZombieVeggieTales.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ZombieVeggieTales     5   	     � Title$$  Welcome to the Native Gardener��5   	   $	��625��60   $	��875��6=   .��5      � #��� ��6    � RowDefinitions 5   
   �� 5	      $
��auto �6   �� 5
      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � $��1��6   #��� ��6    5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      5      �� 5   
   -   5         ��Name$ 
tabconMain��5      $��2��6)   $��	0,55,0,10q�66   $��2��6I   .@�5      �� -   5        $��tabViewPlants��5      $��View Plants��6+   $
��Left=�6@   $
��Auto��6[   $	��5 3q�6i   $��0q�6w   $��Center=�6�   $	��100��6�   .��5      �� .+�5       � ���	#FFE5E5E5.+�5!      &   System.Windows.Controls.DataGrid  -   5        $��dgViewPlants��5!   #      GridLinesVisibility$ 
Horizontal=�67      AlternatingRowBackground �	#FFE5E37F   RowBackground �	#FFBAABE8$ �� IsSynchronizedWithCurrentItem$
 TrueY�5$         SelectionMode$ Single=�6D   	   CanUserReorderColumns	 .  
   CanUserDeleteRows
 .     
IsReadOnly . ��5&      �� 6Q   5'      5)      5*      �� 5+      -   5        $��tabViewInsects��5+      $��View Insects��6,   $
��Left=�6B   $
��Auto��6]   $	��5 3q�6k   $��0q�6y   $��Center=�6�   $	��100��6�   .��5,      �� -   5         ��Name$ btnViewInsects��5,      $��View Insects��61   $
��Left=�6H   $��728,426,0,23q�6c   $	��100��6y   $��25��6�   $��12(�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.53,0.6&�6�   5-      �� 5.      -   5        $��tabAddPlant��5.      $��Add a Plant��6)   $
��Left=�6>   $
��Auto��6Y   $	��5 3q�6g   $��0q�6u   $��Center=�6�   $	��100��6�   .��5/      �� .+�50        -   5        $��
dgAddPlant��50         AutoGenerateColumns .  $ Single=�6e    . ��61   ��    Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ ContributorID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6j   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *Commercial_Id+6j     53      $ Common Name��61   $	 110 6b    6F   �� *	User_Id+6b     54      $ Scientific Name��61   $	 120 6i    6J   �� *
IsApproved+6i     55      $ 	Soil Type��61   $	 100 6c    6D   �� *
ApprovedBy+6c     56      $ Growing Zone��61   $	 110 6d    6G   �� *
FedTaxId+6d     57      $ Description��61   $	 110 6a    6F   �� *Active+6a   59      5;      5<      �� 5=      -   5        $��tabAddInsect��5=      $��Add an Insect��6*   $
��Left=�6A   $
��Auto��6\   $	��5 3q�6j   $��0q�6x   $��Center=�6�   $	��100��6�   .��5>      �  5?      �� 5@      $	��57* �6+   �� 5A      $
��194* �6+   �� 5B      $
��610* �6+   5E      5F      5G      �� 5H   
   $��3��6   .@�5I      �  5J      �� 5K      $��* �6'   �� 5L      $��* �6'   5N      �� 5O      -	   5        $��statusMessage��5O   ,   $��0��6   $ ��Please log in to continue.��6A   $
��10 4q�6f   $	��Top=�6u   $��11(�6�   $��Segoe UI Semibold)�6�   $
��Bold"�6�   6�   5P      �� 5Q   
   -
   5         ��Name$ txtUsername��5Q      $
��Left=�6'   $��20��6B   $��
618,20,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��140��6�   $��2��6�   �� 5R   
   -   5        $ txtPassword��5R      $
��Left=�6'   $��20��6B   $��
618,45,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��140��6�   $��2��6�   �� 5S   
   -   5         ��Name$ lblUsername��5S      $��Username��6%   $
��Left=�68   $��
553,14,0,0q�6S   $	��Top=�6g   $��3��6   �� 5T   
   -   5        $ lblPassword��5T      $��Password��6%   $
��Left=�68   $��
553,40,0,0q�6S   $	��Top=�6g   $��2��6   �� 5U   
   -   5        $ btnLogin��5U      $��Log In��6#   $
��Left=�64   $��
763,20,0,0q�6O   $	��Top=�6c   $��75��6{   $��3��6�   5V      5W      