   M S B A M L   `   `   `  ���� D  @Tires1.01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Tires1._01
Tires1._01      Tires1._01.FavoriteView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:Tires1._01     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� .+�� .+��� -     ��Name$  lv��$��10q����� *Tires+ �� SelectedItem �� *SelectedTire+���� .R�A�  A� Columns$ 3��$��Stretch=�$	��Top=�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ Stretch=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �@��
IsSelected . ���� .R�� .+�#  MaterialDesignThemes.Wpf.Card  $	��220��$	��320��.��� 	 � RowDefinitions	 �� �� $��2* ��� .+��� $��/Resources/Cont.jpg��$	��185��$	��190��$��UniformToFill=��� $��0�� 0  ,MaterialDesignFloatingActionMiniAccentButton#��[  $��Right=�$��Bottom=�$��
0 0 16 -20q����� 
 �� ElementName$
 lv�� �� Path$" DataContext.WebSearchCommand�.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	SearchWeb=��� $��1��$��8 24 8 0q�.+��� $
��Bold"����� *Name+�� $
��Wrap=�$��Center=��� $�	Цена:�� �� ��� *Price+�� $
��Wrap=�$��Center=��� $�Ширина:�� �� ��� *Width+�� $
��Wrap=�$��Center=��� $�Профиль:�� �� ��� *
SideWall+�� $
��Wrap=�$��Center=��� $�Диаметр:�� �� ��� *
Diameter+�� $
��Wrap=�$��Center=��� $�Сезон:�� �� ��� *Season+��  � DataContext$ MainPageViewModel��$��Right=�$��2�� �� Orientation$ 
Horizontal=�$��8q�.+�d�  d� 	IsChecked$
 TrueY� ) %MaterialDesignFlatPrimaryToggleButton#��[  � ToolTip$+ %MaterialDesignFlatPrimaryToggleButton������ $
 lv��$ DataContext.AddCommand�.��  $ Heart=�$��18��$��18��