   M S B A M L   `   `   `  ���� D  @Tires1.01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Tires1._01.View.ResourcesTires1._01.View.Resources  (    "Tires1._01.View.Resources.MainView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9local'clr-namespace:Tires1._01.View.Resources     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .���   � ColumnDefinitions  �� $��2* ��� $��3* �.+�� $��0�� � RowDefinitions �� �� �� $
��0.5* �.+�� $��0�� � DataContext �� *SelectorViewModel+.+��� .+��� Ширина�� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ width������ *SearchParams.ListWidth+ �� SelectedValue �� *InputParams.SelectWidth+���� .R�$� �� Профиль�� $ sidewall������ *SearchParams.ListSideWall+ �� *InputParams.SelectSideWall+���� .R�$� �� Диаметр�� $ diameter������ *SearchParams.ListDiameter+ �� *InputParams.SelectDiameter+���� .R�$� � $��1�� �� *SelectorViewModel+.+��� .+��� 
Сезон�� $ season������ *SearchParams.ListSeason+ �� *InputParams.SelectSeason+���� .R�$� �� 
Бренд�� $ brand������ *SearchParams.ListBrand+ �� *InputParams.SelectBrand+���� .R�$� � $��2��.+��� ���� *SelectCommand+.��
Поиск� $��1�� �� $
��Auto ��� $��* �.+�o� $��30��.@�m� $
��Auto��$��Sort by price��$��Stretch=�.@��� $��Stretch=�$A��;Сортировать по возростанию цены��   MaterialDesignFlatButton#��[   � ToolTip$ MaterialDesignFlatButton������ *SortByPriceLow+�� $��Stretch=�$;��5Сортировать по убыванию цены��#��[  $ MaterialDesignFlatButton������ *SortByPriceHigh+�� -    ��Name$ lv��$��1��$��10q����� *Tires+ �� SelectedItem �� *SelectedTire+ J� InputBindings �� 
	 �� Key$	 Enter��
 �� Command
 �� *SelectCommand+���� .R�A�  A� Columns$ 2��$��Stretch=�$	��Top=�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ Stretch=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �@��
IsSelected . ���� .R�� .+�#  MaterialDesignThemes.Wpf.Card  $	��220��$	��320��.���  �� �� $��2* ��� .+��� $��/Resources/Cont.jpg��$	��150��$	��190��$��UniformToFill=��� $��0�� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $��Right=�$��Bottom=�$��
0 0 16 -20q�����  �� ElementName$ lv�� �� Path$" DataContext.WebSearchCommand�.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	SearchWeb=��� $��1��$��8 24 8 0q�.+��� $
��Bold"����� *Name+�� $
��Wrap=�$��Center=��� $�	Цена:�� �� ��� *Price+�� $
��Wrap=�$��Center=��� $�Ширина:�� �� ��� *Width+�� $
��Wrap=�$��Center=��� $�Профиль:�� �� ��� *
SideWall+�� $
��Wrap=�$��Center=��� $�Диаметр:�� �� ��� *
Diameter+�� $
��Wrap=�$��Center=��� $�Сезон:�� �� ��� *Season+�� $ MainPageViewModel��$��Right=�$��2�� �� Orientation$ 
Horizontal=�$��8q�.+�d�  ) %MaterialDesignFlatPrimaryToggleButton#��[ $+ %MaterialDesignFlatPrimaryToggleButton������ $ lv��$ DataContext.AddCommand�.��  $ Heart=�$��18��$��18��